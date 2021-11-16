// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um/d3d12.h in the Windows SDK for Windows 10.0.20348.0
// Original source is Copyright © Microsoft. All rights reserved.

namespace TerraFX.Interop.DirectX
{
    internal enum D3D12_PRIMITIVE_TOPOLOGY_TYPE
    {
        D3D12_PRIMITIVE_TOPOLOGY_TYPE_UNDEFINED = 0,
        D3D12_PRIMITIVE_TOPOLOGY_TYPE_POINT = 1,
        D3D12_PRIMITIVE_TOPOLOGY_TYPE_LINE = 2,
        D3D12_PRIMITIVE_TOPOLOGY_TYPE_TRIANGLE = 3,
        D3D12_PRIMITIVE_TOPOLOGY_TYPE_PATCH = 4,
    }
}
