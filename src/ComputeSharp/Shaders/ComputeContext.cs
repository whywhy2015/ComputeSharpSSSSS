﻿using System;
using System.Runtime.CompilerServices;
using ComputeSharp.__Internals;
using ComputeSharp.Graphics.Commands;
using ComputeSharp.Shaders;
using ComputeSharp.Shaders.Dispatching;
using Microsoft.Toolkit.Diagnostics;
using TerraFX.Interop.DirectX;

#pragma warning disable CS0618

namespace ComputeSharp;

/// <summary>
/// A context to batch compute operations in a single invocation, minimizing GPU overhead.
/// </summary>
public ref struct ComputeContext
{
    /// <summary>
    /// The <see cref="GraphicsDevice"/> instance owning the current context.
    /// </summary>
    private readonly GraphicsDevice device;

    /// <summary>
    /// The current <see cref="CommandList"/> instance used to dispatch shaders.
    /// </summary>
    private CommandList commandList;

    /// <summary>
    /// Creates a new <see cref="ComputeContext"/> instance with the specified parameters.
    /// </summary>
    /// <param name="device">The <see cref="GraphicsDevice"/> instance owning the current context.</param>
    internal ComputeContext(GraphicsDevice device)
    {
        this.device = device;
        this.commandList = default;
    }

    /// <summary>
    /// Runs the input shader with the specified parameters.
    /// </summary>
    /// <param name="x">The number of iterations to run on the X axis.</param>
    /// <param name="y">The number of iterations to run on the Y axis.</param>
    /// <param name="z">The number of iterations to run on the Z axis.</param>
    /// <param name="shader">The input <typeparamref name="T"/> instance representing the compute shader to run.</param>
    internal readonly unsafe void Run<T>(int x, int y, int z, ref T shader)
        where T : struct, IComputeShader
    {
        bool xIs1 = x == 1;
        bool yIs1 = y == 1;
        bool zIs1 = z == 1;
        int mask = *(byte*)&xIs1 << 2 | *(byte*)&yIs1 << 1 | *(byte*)&zIs1;
        int threadsX;
        int threadsY;
        int threadsZ;

        switch (mask - 1)
        {
            case 0: // (_, _, 1)
                threadsX = threadsY = 8;
                threadsZ = 1;
                break;
            case 1: // (_, 1, _)
                threadsX = threadsZ = 8;
                threadsY = 1;
                break;
            case 2: // (_, 1, 1)
                threadsX = (int)this.device.WavefrontSize;
                threadsY = threadsZ = 1;
                break;
            case 3: // (1, _, _)
                threadsX = 1;
                threadsY = threadsZ = 8;
                break;
            case 4: // (1, _, 1)
                threadsX = threadsZ = 1;
                threadsY = (int)this.device.WavefrontSize;
                break;
            case 5: // (1, 1, _)
                threadsX = threadsY = 1;
                threadsZ = (int)this.device.WavefrontSize;
                break;
            default: // (_, _, _)
                threadsX = threadsY = threadsZ = 4;
                break;
        }

        Run(x, y, z, threadsX, threadsY, threadsZ, ref shader);
    }

    /// <summary>
    /// Runs the input shader with the specified parameters.
    /// </summary>
    /// <typeparam name="T">The type of compute shader to run.</typeparam>
    /// <param name="x">The number of iterations to run on the X axis.</param>
    /// <param name="y">The number of iterations to run on the Y axis.</param>
    /// <param name="z">The number of iterations to run on the Z axis.</param>
    /// <param name="threadsX">The number of threads in each thread group for the X axis.</param>
    /// <param name="threadsY">The number of threads in each thread group for the Y axis.</param>
    /// <param name="threadsZ">The number of threads in each thread group for the Z axis.</param>
    /// <param name="shader">The input <typeparamref name="T"/> instance representing the compute shader to run.</param>
    internal readonly unsafe void Run<T>(
        int x,
        int y,
        int z,
        int threadsX,
        int threadsY,
        int threadsZ,
        ref T shader)
        where T : struct, IComputeShader
    {
        ThrowInvalidOperationExceptionIfDeviceIsNull();

        Guard.IsGreaterThan(x, 0, nameof(x));
        Guard.IsGreaterThan(y, 0, nameof(y));
        Guard.IsGreaterThan(z, 0, nameof(z));
        Guard.IsBetweenOrEqualTo(threadsX, 1, 1024, nameof(threadsX));
        Guard.IsBetweenOrEqualTo(threadsY, 1, 1024, nameof(threadsY));
        Guard.IsBetweenOrEqualTo(threadsZ, 1, 64, nameof(threadsZ));
        Guard.IsLessThanOrEqualTo(threadsX * threadsY * threadsZ, 1024, "threadsXYZ");

        int groupsX = Math.DivRem(x, threadsX, out int modX) + (modX == 0 ? 0 : 1);
        int groupsY = Math.DivRem(y, threadsY, out int modY) + (modY == 0 ? 0 : 1);
        int groupsZ = Math.DivRem(z, threadsZ, out int modZ) + (modZ == 0 ? 0 : 1);

        Guard.IsBetweenOrEqualTo(groupsX, 1, D3D11.D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION, nameof(groupsX));
        Guard.IsBetweenOrEqualTo(groupsY, 1, D3D11.D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION, nameof(groupsX));
        Guard.IsBetweenOrEqualTo(groupsZ, 1, D3D11.D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION, nameof(groupsX));

        PipelineData pipelineData = ShaderRunner<T>.GetPipelineData(this.device, threadsX, threadsY, threadsZ, ref shader);

        ref CommandList commandList = ref GetCommandList(in this, pipelineData.D3D12PipelineState);

        commandList.D3D12GraphicsCommandList->SetComputeRootSignature(pipelineData.D3D12RootSignature);

        ComputeShaderDispatchDataLoader dataLoader = new(commandList.D3D12GraphicsCommandList);

        shader.LoadDispatchData(ref dataLoader, this.device, x, y, z);

        commandList.D3D12GraphicsCommandList->Dispatch((uint)groupsX, (uint)groupsY, (uint)groupsZ);
    }

    /// <summary>
    /// Runs the input shader with the specified parameters.
    /// </summary>
    /// <typeparam name="T">The type of pixel shader to run.</typeparam>
    /// <typeparam name="TPixel">The type of pixel to work on.</typeparam>
    /// <param name="texture">The target texture to invoke the pixel shader upon.</param>
    /// <param name="shader">The input <typeparamref name="T"/> instance representing the pixel shader to run.</param>
    internal readonly unsafe void Run<T, TPixel>(IReadWriteTexture2D<TPixel> texture, ref T shader)
        where T : struct, IPixelShader<TPixel>
        where TPixel : unmanaged
    {
        ThrowInvalidOperationExceptionIfDeviceIsNull();

        int x = texture.Width;
        int y = texture.Height;
        const int threadsX = 8;
        const int threadsY = 8;
        const int threadsZ = 1;
        int groupsX = Math.DivRem(x, threadsX, out int modX) + (modX == 0 ? 0 : 1);
        int groupsY = Math.DivRem(y, threadsY, out int modY) + (modY == 0 ? 0 : 1);

        Guard.IsBetweenOrEqualTo(groupsX, 1, D3D11.D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION, nameof(groupsX));
        Guard.IsBetweenOrEqualTo(groupsY, 1, D3D11.D3D11_CS_DISPATCH_MAX_THREAD_GROUPS_PER_DIMENSION, nameof(groupsX));

        PipelineData pipelineData = ShaderRunner<T>.GetPipelineData(this.device, threadsX, threadsY, threadsZ, ref shader);

        ref CommandList commandList = ref GetCommandList(in this, pipelineData.D3D12PipelineState);

        commandList.D3D12GraphicsCommandList->SetComputeRootSignature(pipelineData.D3D12RootSignature);

        PixelShaderDispatchDataLoader dataLoader = new(commandList.D3D12GraphicsCommandList);

        shader.LoadDispatchData(ref dataLoader, this.device, x, y, 1);

        // Load the implicit output texture
        commandList.D3D12GraphicsCommandList->SetComputeRootDescriptorTable(
            1,
            ((GraphicsResourceHelper.IGraphicsResource)texture).ValidateAndGetGpuDescriptorHandle(this.device));

        commandList.D3D12GraphicsCommandList->Dispatch((uint)groupsX, (uint)groupsY, 1);
    }

    /// <inheritdoc cref="IDisposable.Dispose"/>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Dispose()
    {
        ThrowInvalidOperationExceptionIfDeviceIsNull();

        if (!this.commandList.IsAllocated)
        {
            return;
        }

        this.commandList.ExecuteAndWaitForCompletion();
    }

    /// <summary>
    /// Gets the current <see cref="CommandList"/> instance, and initializes it as needed.
    /// </summary>
    /// <param name="this">The current <see cref="ComputeContext"/> instance.</param>
    /// <param name="pipelineState">The input <see cref="ID3D12PipelineState"/> to load.</param>
    /// <returns>A reference to the <see cref="CommandList"/> instance to use.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static unsafe ref CommandList GetCommandList(in ComputeContext @this, ID3D12PipelineState* pipelineState)
    {
        // This method has to take the context by readonly reference to allow callers to be marked as readonly.
        // This is needed to skip the hidden copies done by Roslyn, which would break the dispatching, as the
        // original context would not see the changes done by the following queued dispatches. This delegate
        // cast is necessary to work around the fact that ref structs cannot currently be used as type arguments.
        ref ComputeContext context = ref ((delegate*<in ComputeContext, ref ComputeContext>)(delegate*<in byte, ref byte>)&Unsafe.AsRef<byte>)(in @this);

        if (context.commandList.IsAllocated)
        {
            context.commandList.D3D12GraphicsCommandList->SetPipelineState(pipelineState);
        }
        else
        {
            context.commandList = new CommandList(context.device, pipelineState);
        }

        return ref context.commandList;
    }

    /// <summary>
    /// Throws an <see cref="InvalidOperationException"/> if <see cref="device"/> is <see langword="null"/>.
    /// </summary>
    /// <exception cref="InvalidOperationException">Thrown if <see cref="device"/> is <see langword="null"/>.</exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private readonly void ThrowInvalidOperationExceptionIfDeviceIsNull()
    {
        if (this.device is null)
        {
            ThrowHelper.ThrowInvalidOperationException("The current compute context has not been initialized correctly.");
        }
    }
}
