using EasySG.Abstracts.Generators.Interfaces;
using EasySG.Abstracts.Models.CSharp;

namespace EasyGenerator.Builder.Simulates
{
    internal class GeneratorRule : IGeneratorRule
    {
        Func<CSharpClass, bool> _func;
        public GeneratorRule(Func<CSharpClass, bool> func)
        {
            _func = func;
        }
        public bool NeedToGenerate(CSharpClass @class)
        {
            return _func(@class);
        }
    }
}
