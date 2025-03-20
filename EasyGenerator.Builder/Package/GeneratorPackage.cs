using EasySG.Abstracts.Generators;
using EasySG.Abstracts.Generators.Interfaces;
using EasySG.Abstracts.Generators.State;
using EasySG.Abstracts.Models.CSharp;
using EasySG.Abstracts.Packages.Interfaces;

namespace EasySG.Abstracts.Packages
{
    internal class GeneratorPackage : IGeneratorPackage
    {
        public GeneratorPackage(List<IEGenerator> easyGenerators, List<IGeneratorRule> rules)
        {
            _state = new();
            this.easyGenerators = easyGenerators;
            this.rules = rules;
        }

        private readonly GeneratorState _state = null!;
        private readonly List<IEGenerator> easyGenerators = null!;
        private readonly List<IGeneratorRule> rules = null!;
        public List<IResult> GetResults() => _state.GetResult();
        public void Generate(CSharpClass input, GeneratorState state)
        {
            foreach (var generator in easyGenerators)
            {
                generator.Generate(input, _state);
            }
        }
        public bool NeedToGenerate(CSharpClass @class)
        {
            return rules.All(a => a.NeedToGenerate(@class));
        }
    }
}
