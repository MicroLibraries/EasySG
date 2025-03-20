using Microsoft.CodeAnalysis.CSharp;

namespace EasySG.Abstracts.Models.Interfaces
{
    public interface IModelSyntax
    {
        string Compile();
        IModelSyntax DeCompile(CSharpSyntaxNode declaration);
    }
}
