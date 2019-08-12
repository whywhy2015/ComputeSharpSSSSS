﻿using System;
using ComputeSharp.Graphics;
using ComputeSharp.Shaders;

namespace ComputeSharp
{
    /// <summary>
    /// A <see langword="class"/> that contains extension methods for the <see cref="GraphicsDevice"/> type, used to run compute shaders
    /// </summary>
    public static class GraphicsDeviceExtensions
    {
        /// <summary>
        /// The default number of threads in a thead froup
        /// </summary>
        public const int DefaultThreadGroupCount = 64;

        /// <summary>
        /// Compiles and runs the input shader on a target <see cref="GraphicsDevice"/> instance, with the specified parameters
        /// </summary>
        /// <param name="device">The <see cref="GraphicsDevice"/> to use to run the shader</param>
        /// <param name="x">The number of threads to run on the X axis</param>
        /// <param name="action">The input <see cref="Action{T}"/> representing the compute shader to run</param>
        public static void For(this GraphicsDevice device, int x, Action<ThreadIds> action)
        {
            int groupsX = (x - 1) / DefaultThreadGroupCount + 1;

            ShaderRunner.Run(device, (DefaultThreadGroupCount, 1), (groupsX, 1), action);
        }

        /// <summary>
        /// Compiles and runs the input shader on a target <see cref="GraphicsDevice"/> instance, with the specified parameters
        /// </summary>
        /// <param name="device">The <see cref="GraphicsDevice"/> to use to run the shader</param>
        /// <param name="x">The number of threads to run on the X axis</param>
        /// <param name="y">The number of threads to run on the Y axis</param>
        /// <param name="action">The input <see cref="Action{T}"/> representing the compute shader to run</param>
        public static void For(this GraphicsDevice device, int x, int y, Action<ThreadIds> action)
        {
            int
                groupsX = (x - 1) / DefaultThreadGroupCount + 1,
                groupsY = (y - 1) / DefaultThreadGroupCount + 1;

            ShaderRunner.Run(device, (DefaultThreadGroupCount, DefaultThreadGroupCount), (groupsX, groupsY), action);
        }

        /// <summary>
        /// Compiles and runs the input shader on a target <see cref="GraphicsDevice"/> instance, with the specified parameters
        /// </summary>
        /// <param name="device">The <see cref="GraphicsDevice"/> to use to run the shader</param>
        /// <param name="x">The number of threads to run on the X axis</param>
        /// <param name="y">The number of threads to run on the Y axis</param>
        /// <param name="z">The number of threads to run on the Z axis</param>
        /// <param name="action">The input <see cref="Action{T}"/> representing the compute shader to run</param>
        public static void For(this GraphicsDevice device, int x, int y, int z, Action<ThreadIds> action)
        {
            int
                groupsX = (x - 1) / DefaultThreadGroupCount + 1,
                groupsY = (y - 1) / DefaultThreadGroupCount + 1,
                groupsZ = (z - 1) / DefaultThreadGroupCount + 1;

            ShaderRunner.Run(device, (DefaultThreadGroupCount, DefaultThreadGroupCount, DefaultThreadGroupCount), (groupsX, groupsY, groupsZ), action);
        }

        /// <summary>
        /// Compiles and runs the input shader on a target <see cref="GraphicsDevice"/> instance, with the specified parameters
        /// </summary>
        /// <param name="device">The <see cref="GraphicsDevice"/> to use to run the shader</param>
        /// <param name="numThreads">The <see cref="NumThreads"/> value that indicates the number of threads to run in each thread group</param>
        /// <param name="numGroups">The <see cref="NumThreads"/> value that indicates the number of thread groups to dispatch</param>
        /// <param name="action">The input <see cref="Action{T}"/> representing the compute shader to run</param>
        public static void For(this GraphicsDevice device, NumThreads numThreads, NumThreads numGroups, Action<ThreadIds> action)
        {
            ShaderRunner.Run(device, numThreads, numGroups, action);
        }
    }
}
