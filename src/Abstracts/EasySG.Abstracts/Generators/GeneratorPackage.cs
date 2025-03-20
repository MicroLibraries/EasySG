using EasySG.Abstracts.Generators.Interfaces;
using EasySG.Abstracts.Generators.State;
using EasySG.Abstracts.Models;
using EasySG.Abstracts.Models.CSharp;

namespace EasySG.Abstracts.Generators
{
    public class GeneratorPackage : IGeneratorPackage
    {
        public GeneratorPackage(List<IEasyGenerator> easyGenerators, List<IGeneratorRule> rules)
        {
            _state = new();
            this.easyGenerators = easyGenerators;
            this.rules = rules;
        }

        private readonly GeneratorState _state = null!;
        private readonly List<IEasyGenerator> easyGenerators = null!;
        private readonly List<IGeneratorRule> rules = null!;
        public List<IResult> GetResults() => _state.GetResult;
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
