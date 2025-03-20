using EasySG.Abstracts.Models.CSharp;

namespace EasySG.Abstracts.Models.Intermediate
{
    public interface IModelSelector
    {
        bool CheckType(CSharpClass @class);
    }
}
