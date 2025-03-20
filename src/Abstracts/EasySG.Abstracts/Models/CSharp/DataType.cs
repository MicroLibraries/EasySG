using EasySG.Abstracts.Models.Interfaces;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace EasySG.Abstracts.Models.CSharp
{
    public class DataType : IModelSyntax
    {
        public string? Name { get; set; }
        public bool? IsPrimitive { get; set; }
        public CSharpClass? CustomType { get; set; }

        public string Compile()
        {
            return Name!;
        }

        public IModelSyntax DeCompile(CSharpSyntaxNode declaration)
        {
            Name = declaration.ToString();
            var primitives = new[] { "int", "string", "bool", "float", "double", "decimal", "char" };
            IsPrimitive = primitives.Contains(Name);
            return this;
        }
    }
}
