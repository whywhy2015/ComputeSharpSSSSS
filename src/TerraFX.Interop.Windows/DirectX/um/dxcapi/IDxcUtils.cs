// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um/dxcapi.h in the Windows SDK for Windows 10.0.20348.0
// Original source is Copyright © Microsoft. All rights reserved. Licensed under the University of Illinois Open Source License.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using TerraFX.Interop.Windows;

namespace TerraFX.Interop.DirectX
{
    [Guid("4605C4CB-2019-492A-ADA4-65F20BB7D67F")]
    [NativeTypeName("struct IDxcUtils : IUnknown")]
    [NativeInheritance("IUnknown")]
    internal unsafe partial struct IDxcUtils : IDxcUtils.Interface
    {
        public void** lpVtbl;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(0)]
        public HRESULT QueryInterface([NativeTypeName("const IID &")] Guid* riid, void** ppvObject)
        {
            return ((delegate* unmanaged[Stdcall]<IDxcUtils*, Guid*, void**, int>)(lpVtbl[0]))((IDxcUtils*)Unsafe.AsPointer(ref this), riid, ppvObject);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(1)]
        [return: NativeTypeName("ULONG")]
        public uint AddRef()
        {
            return ((delegate* unmanaged[Stdcall]<IDxcUtils*, uint>)(lpVtbl[1]))((IDxcUtils*)Unsafe.AsPointer(ref this));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(2)]
        [return: NativeTypeName("ULONG")]
        public uint Release()
        {
            return ((delegate* unmanaged[Stdcall]<IDxcUtils*, uint>)(lpVtbl[2]))((IDxcUtils*)Unsafe.AsPointer(ref this));
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(3)]
        public HRESULT CreateBlobFromBlob(IDxcBlob* pBlob, [NativeTypeName("UINT32")] uint offset, [NativeTypeName("UINT32")] uint length, IDxcBlob** ppResult)
        {
            return ((delegate* unmanaged[Stdcall]<IDxcUtils*, IDxcBlob*, uint, uint, IDxcBlob**, int>)(lpVtbl[3]))((IDxcUtils*)Unsafe.AsPointer(ref this), pBlob, offset, length, ppResult);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(4)]
        public HRESULT CreateBlobFromPinned([NativeTypeName("LPCVOID")] void* pData, [NativeTypeName("UINT32")] uint size, [NativeTypeName("UINT32")] uint codePage, IDxcBlobEncoding** pBlobEncoding)
        {
            return ((delegate* unmanaged[Stdcall]<IDxcUtils*, void*, uint, uint, IDxcBlobEncoding**, int>)(lpVtbl[4]))((IDxcUtils*)Unsafe.AsPointer(ref this), pData, size, codePage, pBlobEncoding);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(5)]
        public HRESULT MoveToBlob([NativeTypeName("LPCVOID")] void* pData, IMalloc* pIMalloc, [NativeTypeName("UINT32")] uint size, [NativeTypeName("UINT32")] uint codePage, IDxcBlobEncoding** pBlobEncoding)
        {
            return ((delegate* unmanaged[Stdcall]<IDxcUtils*, void*, IMalloc*, uint, uint, IDxcBlobEncoding**, int>)(lpVtbl[5]))((IDxcUtils*)Unsafe.AsPointer(ref this), pData, pIMalloc, size, codePage, pBlobEncoding);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(6)]
        public HRESULT CreateBlob([NativeTypeName("LPCVOID")] void* pData, [NativeTypeName("UINT32")] uint size, [NativeTypeName("UINT32")] uint codePage, IDxcBlobEncoding** pBlobEncoding)
        {
            return ((delegate* unmanaged[Stdcall]<IDxcUtils*, void*, uint, uint, IDxcBlobEncoding**, int>)(lpVtbl[6]))((IDxcUtils*)Unsafe.AsPointer(ref this), pData, size, codePage, pBlobEncoding);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(7)]
        public HRESULT LoadFile([NativeTypeName("LPCWSTR")] ushort* pFileName, [NativeTypeName("UINT32 *")] uint* pCodePage, IDxcBlobEncoding** pBlobEncoding)
        {
            return ((delegate* unmanaged[Stdcall]<IDxcUtils*, ushort*, uint*, IDxcBlobEncoding**, int>)(lpVtbl[7]))((IDxcUtils*)Unsafe.AsPointer(ref this), pFileName, pCodePage, pBlobEncoding);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(8)]
        public HRESULT CreateReadOnlyStreamFromBlob(IDxcBlob* pBlob, IStream** ppStream)
        {
            return ((delegate* unmanaged[Stdcall]<IDxcUtils*, IDxcBlob*, IStream**, int>)(lpVtbl[8]))((IDxcUtils*)Unsafe.AsPointer(ref this), pBlob, ppStream);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(9)]
        public HRESULT CreateDefaultIncludeHandler(IDxcIncludeHandler** ppResult)
        {
            return ((delegate* unmanaged[Stdcall]<IDxcUtils*, IDxcIncludeHandler**, int>)(lpVtbl[9]))((IDxcUtils*)Unsafe.AsPointer(ref this), ppResult);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(10)]
        public HRESULT GetBlobAsUtf8(IDxcBlob* pBlob, IDxcBlobUtf8** pBlobEncoding)
        {
            return ((delegate* unmanaged[Stdcall]<IDxcUtils*, IDxcBlob*, IDxcBlobUtf8**, int>)(lpVtbl[10]))((IDxcUtils*)Unsafe.AsPointer(ref this), pBlob, pBlobEncoding);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(11)]
        public HRESULT GetBlobAsUtf16(IDxcBlob* pBlob, IDxcBlobUtf16** pBlobEncoding)
        {
            return ((delegate* unmanaged[Stdcall]<IDxcUtils*, IDxcBlob*, IDxcBlobUtf16**, int>)(lpVtbl[11]))((IDxcUtils*)Unsafe.AsPointer(ref this), pBlob, pBlobEncoding);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(12)]
        public HRESULT GetDxilContainerPart([NativeTypeName("const DxcBuffer *")] DxcBuffer* pShader, [NativeTypeName("UINT32")] uint DxcPart, void** ppPartData, [NativeTypeName("UINT32 *")] uint* pPartSizeInBytes)
        {
            return ((delegate* unmanaged[Stdcall]<IDxcUtils*, DxcBuffer*, uint, void**, uint*, int>)(lpVtbl[12]))((IDxcUtils*)Unsafe.AsPointer(ref this), pShader, DxcPart, ppPartData, pPartSizeInBytes);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(13)]
        public HRESULT CreateReflection([NativeTypeName("const DxcBuffer *")] DxcBuffer* pData, [NativeTypeName("const IID &")] Guid* iid, void** ppvReflection)
        {
            return ((delegate* unmanaged[Stdcall]<IDxcUtils*, DxcBuffer*, Guid*, void**, int>)(lpVtbl[13]))((IDxcUtils*)Unsafe.AsPointer(ref this), pData, iid, ppvReflection);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(14)]
        public HRESULT BuildArguments([NativeTypeName("LPCWSTR")] ushort* pSourceName, [NativeTypeName("LPCWSTR")] ushort* pEntryPoint, [NativeTypeName("LPCWSTR")] ushort* pTargetProfile, [NativeTypeName("LPCWSTR *")] ushort** pArguments, [NativeTypeName("UINT32")] uint argCount, [NativeTypeName("const DxcDefine *")] DxcDefine* pDefines, [NativeTypeName("UINT32")] uint defineCount, IDxcCompilerArgs** ppArgs)
        {
            return ((delegate* unmanaged[Stdcall]<IDxcUtils*, ushort*, ushort*, ushort*, ushort**, uint, DxcDefine*, uint, IDxcCompilerArgs**, int>)(lpVtbl[14]))((IDxcUtils*)Unsafe.AsPointer(ref this), pSourceName, pEntryPoint, pTargetProfile, pArguments, argCount, pDefines, defineCount, ppArgs);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        [VtblIndex(15)]
        public HRESULT GetPDBContents(IDxcBlob* pPDBBlob, IDxcBlob** ppHash, IDxcBlob** ppContainer)
        {
            return ((delegate* unmanaged[Stdcall]<IDxcUtils*, IDxcBlob*, IDxcBlob**, IDxcBlob**, int>)(lpVtbl[15]))((IDxcUtils*)Unsafe.AsPointer(ref this), pPDBBlob, ppHash, ppContainer);
        }

        public interface Interface : IUnknown.Interface
        {
            [VtblIndex(3)]
            HRESULT CreateBlobFromBlob(IDxcBlob* pBlob, [NativeTypeName("UINT32")] uint offset, [NativeTypeName("UINT32")] uint length, IDxcBlob** ppResult);

            [VtblIndex(4)]
            HRESULT CreateBlobFromPinned([NativeTypeName("LPCVOID")] void* pData, [NativeTypeName("UINT32")] uint size, [NativeTypeName("UINT32")] uint codePage, IDxcBlobEncoding** pBlobEncoding);

            [VtblIndex(5)]
            HRESULT MoveToBlob([NativeTypeName("LPCVOID")] void* pData, IMalloc* pIMalloc, [NativeTypeName("UINT32")] uint size, [NativeTypeName("UINT32")] uint codePage, IDxcBlobEncoding** pBlobEncoding);

            [VtblIndex(6)]
            HRESULT CreateBlob([NativeTypeName("LPCVOID")] void* pData, [NativeTypeName("UINT32")] uint size, [NativeTypeName("UINT32")] uint codePage, IDxcBlobEncoding** pBlobEncoding);

            [VtblIndex(7)]
            HRESULT LoadFile([NativeTypeName("LPCWSTR")] ushort* pFileName, [NativeTypeName("UINT32 *")] uint* pCodePage, IDxcBlobEncoding** pBlobEncoding);

            [VtblIndex(8)]
            HRESULT CreateReadOnlyStreamFromBlob(IDxcBlob* pBlob, IStream** ppStream);

            [VtblIndex(9)]
            HRESULT CreateDefaultIncludeHandler(IDxcIncludeHandler** ppResult);

            [VtblIndex(10)]
            HRESULT GetBlobAsUtf8(IDxcBlob* pBlob, IDxcBlobUtf8** pBlobEncoding);

            [VtblIndex(11)]
            HRESULT GetBlobAsUtf16(IDxcBlob* pBlob, IDxcBlobUtf16** pBlobEncoding);

            [VtblIndex(12)]
            HRESULT GetDxilContainerPart([NativeTypeName("const DxcBuffer *")] DxcBuffer* pShader, [NativeTypeName("UINT32")] uint DxcPart, void** ppPartData, [NativeTypeName("UINT32 *")] uint* pPartSizeInBytes);

            [VtblIndex(13)]
            HRESULT CreateReflection([NativeTypeName("const DxcBuffer *")] DxcBuffer* pData, [NativeTypeName("const IID &")] Guid* iid, void** ppvReflection);

            [VtblIndex(14)]
            HRESULT BuildArguments([NativeTypeName("LPCWSTR")] ushort* pSourceName, [NativeTypeName("LPCWSTR")] ushort* pEntryPoint, [NativeTypeName("LPCWSTR")] ushort* pTargetProfile, [NativeTypeName("LPCWSTR *")] ushort** pArguments, [NativeTypeName("UINT32")] uint argCount, [NativeTypeName("const DxcDefine *")] DxcDefine* pDefines, [NativeTypeName("UINT32")] uint defineCount, IDxcCompilerArgs** ppArgs);

            [VtblIndex(15)]
            HRESULT GetPDBContents(IDxcBlob* pPDBBlob, IDxcBlob** ppHash, IDxcBlob** ppContainer);
        }

        internal partial struct Vtbl
        {
            [NativeTypeName("HRESULT (const IID &, void **) __attribute__((stdcall))")]
            public delegate* unmanaged[Stdcall]<IDxcUtils*, Guid*, void**, int> QueryInterface;

            [NativeTypeName("ULONG () __attribute__((stdcall))")]
            public delegate* unmanaged[Stdcall]<IDxcUtils*, uint> AddRef;

            [NativeTypeName("ULONG () __attribute__((stdcall))")]
            public delegate* unmanaged[Stdcall]<IDxcUtils*, uint> Release;

            [NativeTypeName("HRESULT (IDxcBlob *, UINT32, UINT32, IDxcBlob **) __attribute__((stdcall))")]
            public delegate* unmanaged[Stdcall]<IDxcUtils*, IDxcBlob*, uint, uint, IDxcBlob**, int> CreateBlobFromBlob;

            [NativeTypeName("HRESULT (LPCVOID, UINT32, UINT32, IDxcBlobEncoding **) __attribute__((stdcall))")]
            public delegate* unmanaged[Stdcall]<IDxcUtils*, void*, uint, uint, IDxcBlobEncoding**, int> CreateBlobFromPinned;

            [NativeTypeName("HRESULT (LPCVOID, IMalloc *, UINT32, UINT32, IDxcBlobEncoding **) __attribute__((stdcall))")]
            public delegate* unmanaged[Stdcall]<IDxcUtils*, void*, IMalloc*, uint, uint, IDxcBlobEncoding**, int> MoveToBlob;

            [NativeTypeName("HRESULT (LPCVOID, UINT32, UINT32, IDxcBlobEncoding **) __attribute__((stdcall))")]
            public delegate* unmanaged[Stdcall]<IDxcUtils*, void*, uint, uint, IDxcBlobEncoding**, int> CreateBlob;

            [NativeTypeName("HRESULT (LPCWSTR, UINT32 *, IDxcBlobEncoding **) __attribute__((stdcall))")]
            public delegate* unmanaged[Stdcall]<IDxcUtils*, ushort*, uint*, IDxcBlobEncoding**, int> LoadFile;

            [NativeTypeName("HRESULT (IDxcBlob *, IStream **) __attribute__((stdcall))")]
            public delegate* unmanaged[Stdcall]<IDxcUtils*, IDxcBlob*, IStream**, int> CreateReadOnlyStreamFromBlob;

            [NativeTypeName("HRESULT (IDxcIncludeHandler **) __attribute__((stdcall))")]
            public delegate* unmanaged[Stdcall]<IDxcUtils*, IDxcIncludeHandler**, int> CreateDefaultIncludeHandler;

            [NativeTypeName("HRESULT (IDxcBlob *, IDxcBlobUtf8 **) __attribute__((stdcall))")]
            public delegate* unmanaged[Stdcall]<IDxcUtils*, IDxcBlob*, IDxcBlobUtf8**, int> GetBlobAsUtf8;

            [NativeTypeName("HRESULT (IDxcBlob *, IDxcBlobUtf16 **) __attribute__((stdcall))")]
            public delegate* unmanaged[Stdcall]<IDxcUtils*, IDxcBlob*, IDxcBlobUtf16**, int> GetBlobAsUtf16;

            [NativeTypeName("HRESULT (const DxcBuffer *, UINT32, void **, UINT32 *) __attribute__((stdcall))")]
            public delegate* unmanaged[Stdcall]<IDxcUtils*, DxcBuffer*, uint, void**, uint*, int> GetDxilContainerPart;

            [NativeTypeName("HRESULT (const DxcBuffer *, const IID &, void **) __attribute__((stdcall))")]
            public delegate* unmanaged[Stdcall]<IDxcUtils*, DxcBuffer*, Guid*, void**, int> CreateReflection;

            [NativeTypeName("HRESULT (LPCWSTR, LPCWSTR, LPCWSTR, LPCWSTR *, UINT32, const DxcDefine *, UINT32, IDxcCompilerArgs **) __attribute__((stdcall))")]
            public delegate* unmanaged[Stdcall]<IDxcUtils*, ushort*, ushort*, ushort*, ushort**, uint, DxcDefine*, uint, IDxcCompilerArgs**, int> BuildArguments;

            [NativeTypeName("HRESULT (IDxcBlob *, IDxcBlob **, IDxcBlob **) __attribute__((stdcall))")]
            public delegate* unmanaged[Stdcall]<IDxcUtils*, IDxcBlob*, IDxcBlob**, IDxcBlob**, int> GetPDBContents;
        }
    }
}
