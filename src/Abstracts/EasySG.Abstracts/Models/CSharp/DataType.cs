using EasySG.Abstracts.Models.Interfaces;
using Microsoft.CodeAnalysis.CSharp;

namespace EasySG.Abstracts.Models.CSharp
{
    public class DataType : IModelSyntax
    {
        public string Compile()
        {
            throw new NotImplementedException();
        }

        public IModelSyntax DeCompile(CSharpSyntaxNode declaration)
        {
            throw new NotImplementedException();
        }
        public string? Name { get; set; }
        public bool? IsPrimitive { get; set; }
        public CSharpClass? CustomType { get; set; }
    }
}
