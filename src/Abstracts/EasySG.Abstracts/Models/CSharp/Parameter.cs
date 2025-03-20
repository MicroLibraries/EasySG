using EasySG.Abstracts.Models.Interfaces;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EasySG.Abstracts.Models.CSharp
{
    public class Parameter : IModelSyntax
    {
        public string? Name { get; set; }
        public DataType? Type { get; set; }
        public string? DefaultValue { get; set; }

        public string Compile()
        {
            string result = "";
            result += (Type != null ? Type.Name : "object") + " " + Name;
            if (!string.IsNullOrEmpty(DefaultValue))
                result += " = " + DefaultValue;
            return result;
        }

        public IModelSyntax DeCompile(CSharpSyntaxNode declaration)
        {
            if (declaration is ParameterSyntax parameterSyntax)
            {
                Name = parameterSyntax.Identifier.Text;
                Type = new DataType() { Name = parameterSyntax.Type?.ToString() };
                if (parameterSyntax.Default != null)
                    DefaultValue = parameterSyntax.Default.Value.ToString();
            }
            return this;
        }
    }
}
