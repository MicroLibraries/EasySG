using EasySG.Abstracts.Models.Interfaces;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasySG.Abstracts.Models.CSharp
{

    public class CSharpProperty : IModelSyntax
    {
        public string Compile()
        {
            throw new NotImplementedException();
        }

        public IModelSyntax DeCompile(CSharpSyntaxNode declaration)
        {
            throw new NotImplementedException();
        }
        public string? Name { get; set; }
        public DataType? Type { get; set; }
        public string? Accessibility { get; set; }
        public List<string>? Attributes { get; set; }
        public string? DefaultValue { get; set; }
        public CSharpMethod? Set { get; set; }
        public CSharpMethod? Get { get; set; }
    }
}
