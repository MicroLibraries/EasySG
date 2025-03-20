using EasySG.Abstracts.Models.Interfaces;
using Microsoft.CodeAnalysis.CSharp;
using System.Linq.Expressions;

namespace EasySG.Abstracts.Models.CSharp
{

    public class CSharpMethod : IModelSyntax
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
        public DataType? ReturnType { get; set; }
        public string? Accessibility { get; set; }
        public List<Parameter>? Parameters { get; set; }
        public List<string>? Attributes { get; set; }
        public BlockExpression? Body { get; set; }
    }
}
