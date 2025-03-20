using EasySG.Abstracts.Models.Interfaces;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace EasySG.Abstracts.Models.CSharp
{
    public class CSharpMethod : IModelSyntax
    {
        public string? Name { get; set; }
        public DataType? ReturnType { get; set; }
        public string? Accessibility { get; set; }
        public List<Parameter>? Parameters { get; set; }
        public List<string>? Attributes { get; set; }
        public System.Linq.Expressions.BlockExpression? Body { get; set; }

        public string Compile()
        {
            var sb = new StringBuilder();

            if (Attributes != null)
            {
                foreach (var attr in Attributes)
                    sb.AppendLine(attr);
            }

            if (!string.IsNullOrEmpty(Accessibility))
                sb.Append(Accessibility + " ");
            sb.Append(ReturnType != null ? ReturnType.Name : "void");
            sb.Append(" ");
            sb.Append(Name);
            sb.Append("(");
            if (Parameters != null)
                sb.Append(string.Join(", ", Parameters.Select(p => p.Compile())));
            sb.Append(")");
            sb.AppendLine();
            sb.AppendLine("{");
            if (Body != null)
                sb.AppendLine(Body.ToString());
            sb.AppendLine("}");
            return sb.ToString();
        }

        public IModelSyntax DeCompile(CSharpSyntaxNode declaration)
        {
            if (declaration is MethodDeclarationSyntax methodSyntax)
            {
                Name = methodSyntax.Identifier.Text;
                Accessibility = methodSyntax.Modifiers.ToString();
                ReturnType = new DataType() { Name = methodSyntax.ReturnType.ToString() };

                if (methodSyntax.AttributeLists != null)
                {
                    Attributes = new List<string>();
                    foreach (var attrList in methodSyntax.AttributeLists)
                    {
                        foreach (var attr in attrList.Attributes)
                        {
                            Attributes.Add($"[{attr.Name.ToString()}]");
                        }
                    }
                }

                if (methodSyntax.ParameterList != null)
                {
                    Parameters = new List<Parameter>();
                    foreach (var param in methodSyntax.ParameterList.Parameters)
                    {
                        var parameter = new Parameter();
                        parameter.DeCompile(param);
                        Parameters.Add(parameter);
                    }
                }
            }
            return this;
        }
    }
}
