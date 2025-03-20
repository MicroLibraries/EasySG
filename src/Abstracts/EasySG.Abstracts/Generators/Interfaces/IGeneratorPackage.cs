using EasySG.Abstracts.Generators.State;

namespace EasySG.Abstracts.Generators.Interfaces
{
    public interface IGeneratorPackage : IEasyGenerator, IGeneratorRule
    {
        List<IResult> GetResults();
    }
}
