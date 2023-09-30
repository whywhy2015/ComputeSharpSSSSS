using ComputeSharp.D2D1.SourceGenerators.Models;
using ComputeSharp.SourceGeneration.Extensions;
using ComputeSharp.SourceGeneration.Helpers;

namespace ComputeSharp.D2D1.SourceGenerators;

/// <inheritdoc/>
partial class ID2D1ShaderGenerator
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
            writer.WriteGeneratedAttributes(typeof(ID2D1ShaderGenerator));
            writer.WriteLine("readonly string global::ComputeSharp.D2D1.__Internals.ID2D1Shader.HlslSource =>");
            writer.IncreaseIndent();
            writer.WriteLine("\"\"\"");
            writer.Write(info.HlslInfoKey.HlslSource, isMultiline: true);
            writer.WriteLine("\"\"\";");
            writer.DecreaseIndent();
        }
    }
}