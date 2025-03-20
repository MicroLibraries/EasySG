using EasySG.Abstracts.Generators;
using Microsoft.CodeAnalysis;

namespace EasySG.GeneratorApp
{
    public class EasyGeneratorApp : IIncrementalGenerator
    {
        private readonly List<GeneratorPackage> packages = new();
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            throw new NotImplementedException();
        }
    }
}
