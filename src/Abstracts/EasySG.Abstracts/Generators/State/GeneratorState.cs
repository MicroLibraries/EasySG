using EasySG.Abstracts.Generators.Interfaces;
using EasySG.Abstracts.Models.CSharp;
using System.Collections.Frozen;

namespace EasySG.Abstracts.Generators.State
{
    public class GeneratorState : IGeneratorState
    {
        private FrozenDictionary<string, IResult> _state = null!;
        public TResult GetState<TResult>() where TResult : IResult => (TResult)_state[typeof(TResult).Name];
        public List<IResult> GetResult() => _state.Select(a => a.Value).ToList();
    }
}
