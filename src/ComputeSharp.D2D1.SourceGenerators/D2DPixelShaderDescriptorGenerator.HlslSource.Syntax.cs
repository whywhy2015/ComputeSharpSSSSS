using ComputeSharp.D2D1.SourceGenerators.Models;
using ComputeSharp.SourceGeneration.Extensions;
using ComputeSharp.SourceGeneration.Helpers;

namespace ComputeSharp.D2D1.SourceGenerators;

/// <inheritdoc/>
partial class D2DPixelShaderDescriptorGenerator
{
    /// <inheritdoc/>
    partial class HlslSource
    {
        /// <summary>
        /// Writes the <c>HlslSource</c> property.
        /// </summary>
        /// <param name="info">The input <see cref="D2D1ShaderInfo"/> instance with gathered shader info.</param>
        /// <param name="writer">The <see cref="IndentedTextWriter"/> instance to write into.</param>
        public static void WriteSyntax(D2D1ShaderInfo info, IndentedTextWriter writer)
        {
            writer.WriteLine("/// <inheritdoc/>");
            writer.WriteGeneratedAttributes(GeneratorName);
            writer.WriteLine($"static string global::ComputeSharp.D2D1.Descriptors.ID2D1PixelShaderDescriptor<{info.Hierarchy.Hierarchy[0].QualifiedName}>.HlslSource =>");
            writer.IncreaseIndent();
            writer.WriteLine("\"\"\"");
            writer.Write(info.HlslInfoKey.HlslSource, isMultiline: true);
            writer.WriteLine("\"\"\";");
            writer.DecreaseIndent();
        }
    }
}