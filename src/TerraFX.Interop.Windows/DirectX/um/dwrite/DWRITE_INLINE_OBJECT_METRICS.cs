// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um/dwrite.h in the Windows SDK for Windows 10.0.20348.0
// Original source is Copyright © Microsoft. All rights reserved.

using TerraFX.Interop.Windows;

namespace TerraFX.Interop.DirectX
{
    internal partial struct DWRITE_INLINE_OBJECT_METRICS
    {
        public float width;

        public float height;

        public float baseline;

        public BOOL supportsSideways;
    }
}
