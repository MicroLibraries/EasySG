using EasySG.Abstracts.Models.Interfaces;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace EasySG.Abstracts.Models.CSharp
{
    public class CSharpClass : IModelSyntax
    {
        public string? Name { get; set; }
        public string? Accessibility { get; set; }
        public List<string>? Attributes { get; set; }
        public CSharpClass? BaseClass { get; set; }
        public List<CSharpClass>? ImplementedInterfaces { get; set; }
        public List<CSharpProperty>? Properties { get; set; }
        public List<CSharpMethod>? Methods { get; set; }
        public List<CSharpClass>? NestedClasses { get; set; }
        public bool IsStatic { get; set; }
        public bool IsPartial { get; set; }

        public string Compile()
        {
            var sb = new StringBuilder();
            if (Attributes != null)
            {
                foreach (var attr in Attributes)
                {
                    sb.AppendLine(attr);
                }
            }
            string modifiers = "";
            if (!string.IsNullOrEmpty(Accessibility))
                modifiers += Accessibility + " ";
            if (IsStatic)
                modifiers += "static ";
            if (IsPartial)
                modifiers += "partial ";

            sb.Append(modifiers);
            sb.Append("class ");
            sb.Append(Name);
            List<string> inheritances = new List<string>();
            if (BaseClass != null && !string.IsNullOrEmpty(BaseClass.Name))
                inheritances.Add(BaseClass.Name);
            if (ImplementedInterfaces != null && ImplementedInterfaces.Any())
                inheritances.AddRange(ImplementedInterfaces.Select(i => i.Name));
            if (inheritances.Any())
                sb.Append(" : " + string.Join(", ", inheritances));

            sb.AppendLine();
            sb.AppendLine("{");
            if (Properties != null)
            {
                foreach (var prop in Properties)
                    sb.AppendLine(prop.Compile());
            }
            if (Methods != null)
            {
                foreach (var method in Methods)
                    sb.AppendLine(method.Compile());
            }
            if (NestedClasses != null)
            {
                foreach (var nested in NestedClasses)
                    sb.AppendLine(nested.Compile());
            }
            sb.AppendLine("}");

            return sb.ToString();
        }

        public IModelSyntax DeCompile(CSharpSyntaxNode declaration)
        {
            if (declaration is ClassDeclarationSyntax classSyntax)
            {
                Name = classSyntax.Identifier.Text;
                var modifiers = classSyntax.Modifiers.Select(m => m.Text).ToList();
                Accessibility = string.Join(" ", modifiers.Except(new[] { "static", "partial" }));
                IsStatic = modifiers.Contains("static");
                IsPartial = modifiers.Contains("partial");
                if (classSyntax.AttributeLists != null)
                {
                    Attributes = new List<string>();
                    foreach (var attrList in classSyntax.AttributeLists)
                    {
                        foreach (var attr in attrList.Attributes)
                        {
                            Attributes.Add($"[{attr.Name.ToString()}]");
                        }
                    }
                }
                if (classSyntax.BaseList != null)
                {
                    foreach (var baseType in classSyntax.BaseList.Types)
                    {
                        if (BaseClass == null)
                        {
                            BaseClass = new CSharpClass() { Name = baseType.Type.ToString() };
                        }
                        else
                        {
                            if (ImplementedInterfaces == null)
                                ImplementedInterfaces = new List<CSharpClass>();
                            ImplementedInterfaces.Add(new CSharpClass() { Name = baseType.Type.ToString() });
                        }
                    }
                }
                if (classSyntax.Members != null)
                {
                    foreach (var member in classSyntax.Members)
                    {
                        if (member is PropertyDeclarationSyntax propertySyntax)
                        {
                            var prop = new CSharpProperty();
                            prop.DeCompile(propertySyntax);
                            if (Properties == null)
                                Properties = new List<CSharpProperty>();
                            Properties.Add(prop);
                        }
                        else if (member is MethodDeclarationSyntax methodSyntax)
                        {
                            var method = new CSharpMethod();
                            method.DeCompile(methodSyntax);
                            if (Methods == null)
                                Methods = new List<CSharpMethod>();
                            Methods.Add(method);
                        }
                        else if (member is ClassDeclarationSyntax nestedClassSyntax)
                        {
                            var nested = new CSharpClass();
                            nested.DeCompile(nestedClassSyntax);
                            if (NestedClasses == null)
                                NestedClasses = new List<CSharpClass>();
                            NestedClasses.Add(nested);
                        }
                    }
                }
            }
            return this;
        }
    }
}
