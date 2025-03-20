using EasySG.Abstracts.Generators.State;
using EasySG.Abstracts.Models.CSharp;

namespace EasySG.Abstracts.Generators
{
    public interface IEasyGenerator
    {
        void Generate(CSharpClass input, GeneratorState state);
    }
}
