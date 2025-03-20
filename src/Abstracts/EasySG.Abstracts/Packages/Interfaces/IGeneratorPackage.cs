using EasySG.Abstracts.Generators;
using EasySG.Abstracts.Generators.Interfaces;
using EasySG.Abstracts.Generators.State;

namespace EasySG.Abstracts.Packages.Interfaces
{
    public interface IGeneratorPackage : IEasyGenerator, IGeneratorRule
    {
        List<IResult> GetResults();
    }
}
