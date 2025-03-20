using EasyGenerator.Builder.Simulates;
using EasySG.Abstracts.Builder.Interfaces;
using EasySG.Abstracts.Generators;
using EasySG.Abstracts.Generators.Interfaces;
using EasySG.Abstracts.Models.CSharp;
using EasySG.Abstracts.Packages;
using EasySG.Abstracts.Packages.Interfaces;
using System.Reflection.Emit;

namespace EasyGenerator.Builder.Package
{
    public class GeneratorPackageBuilder : IGeneratorPackageRegistration
    {
        private readonly List<IGeneratorRule> selectors = [];
        private readonly List<IEGenerator> generators = [];
        public IGeneratorPackage Build()
        {
            return new GeneratorPackage(generators, selectors);
        }

        public IGeneratorPackageRegistration SetGenerator<TGenerator>(TGenerator generator) where TGenerator : IEGenerator
        {
            generators.Add(generator);
            return this;
        }

        public IGeneratorPackageRegistration SetSelector<TSelector>(TSelector selector) where TSelector : IGeneratorRule
        {
            selectors.Add(selector);
            return this;
        }

        public IGeneratorPackageRegistration SetSelector(Func<CSharpClass, bool> selector)
        {
            selectors.Add(new GeneratorRule(selector));
            return this;
        }
    }
}
