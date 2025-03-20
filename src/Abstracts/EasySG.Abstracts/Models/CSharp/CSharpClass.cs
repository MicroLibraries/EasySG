using EasySG.Abstracts.Models.Interfaces;
using Microsoft.CodeAnalysis.CSharp;
using System.Linq.Expressions;

namespace EasySG.Abstracts.Models.CSharp
{
    public class CSharpClass : IModelSyntax
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
        public string? Accessibility { get; set; }
        public List<string>? Attributes { get; set; }
        public CSharpClass? BaseClass { get; set; }
        public List<CSharpClass>? ImplementedInterfaces { get; set; }
        public List<CSharpProperty>? Properties { get; set; }
        public List<CSharpMethod>? Methods { get; set; }
        public List<CSharpClass>? NestedClasses { get; set; }
        public bool IsStatic { get; set; }
        public bool IsPartial { get; set; }
    }

}
