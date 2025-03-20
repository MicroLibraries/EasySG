using EasySG.Abstracts.Packages.Interfaces;

namespace EasySG.Abstracts.Generators.Interfaces
{
    public interface IGeneratorOptions
    {
        IEnumerable<IGeneratorPackage> GetPackages();
    }
}
