using EasySG.Abstracts.Generators;
using EasySG.Abstracts.Generators.Interfaces;
using EasySG.Abstracts.Models.CSharp;
using EasySG.Abstracts.Packages.Interfaces;

namespace EasySG.Abstracts.Builder.Interfaces
{
    public interface IGeneratorPackageRegistration
    {
        IGeneratorPackageRegistration SetSelector<TSelector>(TSelector selector) where TSelector : IGeneratorRule;
        IGeneratorPackageRegistration SetSelector(Func<CSharpClass, bool> selector);
        IGeneratorPackageRegistration SetGenerator<TGenerator>(TGenerator generator) where TGenerator : IEGenerator;
        IGeneratorPackage Build();
    }
}
