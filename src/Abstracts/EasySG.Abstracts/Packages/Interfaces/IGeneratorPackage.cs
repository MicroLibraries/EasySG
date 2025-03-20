using EasySG.Abstracts.Generators;
using EasySG.Abstracts.Generators.Interfaces;

namespace EasySG.Abstracts.Packages.Interfaces
{
    public interface IGeneratorPackage : IEGenerator, IGeneratorRule
    {
        List<IResult> GetResults();
    }
}
