namespace CnSharp.CodeGenerator
{
    /// <summary>
    /// Interface for code generators.
    /// </summary>
    public interface IGenerator
    {
        /// <summary>
        /// Generates code from a template file and data.
        /// </summary>
        /// <param name="templateFile">The path to the template file.</param>
        /// <param name="data">The data to use for code generation.</param>
        /// <returns>The generated code as a string.</returns>
        string GenerateFromFile(string templateFile, object data);

        /// <summary>
        /// Generates code from a template text and data.
        /// </summary>
        /// <param name="templateText">The template text to use for code generation.</param>
        /// <param name="data">The data to use for code generation.</param>
        /// <returns>The generated code as a string.</returns>
        string GenerateFromText(string templateText, object data);
    }
}