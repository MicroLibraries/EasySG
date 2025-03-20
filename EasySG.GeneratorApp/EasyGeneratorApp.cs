using EasySG.Abstracts;
using EasySG.Abstracts.Generators.Interfaces;
using EasySG.Abstracts.Models.CSharp;
using EasySG.Abstracts.Packages.Interfaces;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace EasySG.GeneratorApp
{
    public class EasyGeneratorApp : IGeneratorApp
    {
        private readonly IGeneratorOptions Options;

        public EasyGeneratorApp(IGeneratorOptions options)
        {
            Options = options;
        }

        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            List<IResult> result = new();
            foreach (var item in Options.GetPackages())
            {
                var dbContextClasses = context.SyntaxProvider
                    .CreateSyntaxProvider(
                        predicate: (node, _) => node is ClassDeclarationSyntax and CSharpSyntaxNode,
                        transform: static (ctx, _) => new CSharpClass().DeCompile((CSharpSyntaxNode)ctx.Node)
                    )
                    .Where(classNode => item.NeedToGenerate((CSharpClass)classNode)).Collect();
                //context.RegisterSourceOutput(dbContextClasses, );
                //#TODO : NEED TO CREATE A PROXY TO EXECUTE GENERATORS
            }
        }
    }
}
