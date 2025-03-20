using EasyGenerator.Builder.Options;
using EasyGenerator.Builder.Package;
using EasySG.Abstracts.Builder.Interfaces;
using EasySG.Abstracts.Generators;
using EasySG.Abstracts.Generators.Interfaces;
using EasySG.Abstracts.Models.CSharp;
using EasySG.Abstracts.Models.Intermediate;
using EasySG.Abstracts.Packages;
using EasySG.Abstracts.Packages.Interfaces;

namespace EasyGenerator.Builder
{
    public class EasyGeneratorBuilder : IGeneratorBuilder
    {
        private readonly List<IGeneratorPackageRegistration> packageBuilders;
        public EasyGeneratorBuilder()
        {

            packageBuilders = new();
        }

        public IGeneratorOptions Build()
        {
            return new GeneratorOptions(packageBuilders.Select(a => a.Build()).ToList());
        }

        public IGeneratorPackageRegistration RegisterPackage()
        {
            var packageBuilder = new GeneratorPackageBuilder();
            packageBuilders.Add(packageBuilder);
            return packageBuilder;
        }
    }
}
