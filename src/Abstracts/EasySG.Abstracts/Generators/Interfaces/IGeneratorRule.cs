using EasySG.Abstracts.Models.CSharp;

namespace EasySG.Abstracts.Generators.Interfaces
{
    public interface IGeneratorRule
    {
        bool NeedToGenerate(CSharpClass @class);
    }
}
