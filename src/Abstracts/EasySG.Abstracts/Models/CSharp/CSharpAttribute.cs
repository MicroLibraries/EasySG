using EasySG.Abstracts.Models.Interfaces;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EasySG.Abstracts.Models.CSharp
{
    public class CSharpAttribute : IModelSyntax
    {
        public string? Name { get; set; }
        public List<AttributeArgument>? Arguments { get; set; }

        public string Compile()
        {
            string args = "";
            if (Arguments != null && Arguments.Any())
                args = string.Join(", ", Arguments.Select(arg => arg.Compile()));
            return $"[{Name}{(string.IsNullOrEmpty(args) ? "" : $"({args})")}]";
        }

        public IModelSyntax DeCompile(CSharpSyntaxNode declaration)
        {
            if (declaration is AttributeSyntax attributeSyntax)
            {
                Name = attributeSyntax.Name.ToString();
                if (attributeSyntax.ArgumentList != null)
                {
                    Arguments = new List<AttributeArgument>();
                    foreach (var arg in attributeSyntax.ArgumentList.Arguments)
                    {
                        var attributeArg = new AttributeArgument();
                        attributeArg.DeCompile(arg);
                        Arguments.Add(attributeArg);
                    }
                }
            }
            return this;
        }
    }
}
