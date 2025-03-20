using EasySG.Abstracts.Models.Interfaces;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace EasySG.Abstracts.Models.CSharp
{
    public class CSharpProperty : IModelSyntax
    {
        public string? Name { get; set; }
        public DataType? Type { get; set; }
        public string? Accessibility { get; set; }
        public List<string>? Attributes { get; set; }
        public string? DefaultValue { get; set; }
        public CSharpMethod? Set { get; set; }
        public CSharpMethod? Get { get; set; }

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
            sb.Append(Type != null ? Type.Name : "object");
            sb.Append(" ");
            sb.Append(Name);
            sb.Append(" { ");

            if (Get != null)
                sb.Append("get { " + Get.Compile() + " } ");
            if (Set != null)
                sb.Append("set { " + Set.Compile() + " } ");

            sb.Append("}");
            return sb.ToString();
        }

        public IModelSyntax DeCompile(CSharpSyntaxNode declaration)
        {
            if (declaration is PropertyDeclarationSyntax propertySyntax)
            {
                Name = propertySyntax.Identifier.Text;
                Accessibility = propertySyntax.Modifiers.ToString();
                Type = new DataType() { Name = propertySyntax.Type.ToString() };

                if (propertySyntax.AttributeLists != null)
                {
                    Attributes = new List<string>();
                    foreach (var attrList in propertySyntax.AttributeLists)
                    {
                        foreach (var attr in attrList.Attributes)
                        {
                            Attributes.Add($"[{attr.Name.ToString()}]");
                        }
                    }
                }

                if (propertySyntax.Initializer != null)
                    DefaultValue = propertySyntax.Initializer.Value.ToString();

                if (propertySyntax.AccessorList != null)
                {
                    foreach (var accessor in propertySyntax.AccessorList.Accessors)
                    {
                        if (accessor.Keyword.Text == "get")
                        {
                            Get = new CSharpMethod() { Name = "get", Accessibility = Accessibility };
                        }
                        else if (accessor.Keyword.Text == "set")
                        {
                            Set = new CSharpMethod() { Name = "set", Accessibility = Accessibility };
                        }
                    }
                }
            }
            return this;
        }
    }
}
