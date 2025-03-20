using EasySG.Abstracts.Generators.Interfaces;
using EasySG.Abstracts.Packages.Interfaces;

namespace EasyGenerator.Builder.Options
{
    public class GeneratorOptions : IGeneratorOptions
    {
        private readonly List<IGeneratorPackage> _generators;
        public GeneratorOptions(List<IGeneratorPackage> generators)
        {
            _generators = generators;
        }
        public IEnumerable<IGeneratorPackage> GetPackages() => _generators;
    }
}
