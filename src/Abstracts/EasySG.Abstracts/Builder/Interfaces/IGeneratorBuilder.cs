using EasySG.Abstracts.Generators.Interfaces;

namespace EasySG.Abstracts.Builder.Interfaces
{
    public interface IGeneratorBuilder
    {
        IGeneratorPackageRegistration RegisterPackage();
        IGeneratorOptions Build();
    }
}
