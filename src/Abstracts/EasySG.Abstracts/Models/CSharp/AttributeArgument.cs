using EasySG.Abstracts.Models.Interfaces;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EasySG.Abstracts.Models.CSharp
{
    public class AttributeArgument : IModelSyntax
    {
        public string? Name { get; set; }
        public string? Value { get; set; }

        public string Compile()
        {
            if (!string.IsNullOrEmpty(Name))
                return $"{Name} = {Value}";
            else
                return $"{Value}";
        }

        public IModelSyntax DeCompile(CSharpSyntaxNode declaration)
        {
            if (declaration is AttributeArgumentSyntax argSyntax)
            {
                if (argSyntax.NameEquals != null)
                    Name = argSyntax.NameEquals.Name.Identifier.Text;
                Value = argSyntax.Expression.ToString();
            }
            return this;
        }
    }
}
