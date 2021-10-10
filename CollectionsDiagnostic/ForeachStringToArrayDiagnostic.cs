﻿namespace CollectionsDiagnostic
{
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Diagnostics;
    using Diagnostic = Microsoft.CodeAnalysis.Diagnostic;
    using DiagnosticDescriptor = Microsoft.CodeAnalysis.DiagnosticDescriptor;
    using DiagnosticSeverity = Microsoft.CodeAnalysis.DiagnosticSeverity;
    using IMethodSymbol = Microsoft.CodeAnalysis.IMethodSymbol;
    using LanguageNames = Microsoft.CodeAnalysis.LanguageNames;
    using SyntaxKind = Microsoft.CodeAnalysis.CSharp.SyntaxKind;

    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ForeachStringToArrayDiagnostic : DiagnosticAnalyzer
    {
        internal static readonly DiagnosticDescriptor ToArrayErrorRule = new(
            "CI0001",
            "Избыточный вызов ToArray",
            "",
            "",
            DiagnosticSeverity.Warning,
            true,
            ""
        );

        internal static readonly DiagnosticDescriptor ToCharArrayErrorRule = new(
            "CI0002",
            "Избыточный вызов ToCharArray",
            "",
            "",
            DiagnosticSeverity.Warning,
            true,
            ""
        );

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
        ImmutableArray.Create(ToArrayErrorRule, ToCharArrayErrorRule);

        public override void Initialize(AnalysisContext context)
        {
            context.EnableConcurrentExecution();
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);

            context.RegisterSyntaxNodeAction(Analyze, SyntaxKind.InvocationExpression);
        }

        private static readonly IReadOnlyCollection<string> methods = new HashSet<string>(new[] { "ToArray", "ToList" });

        private static void Analyze(SyntaxNodeAnalysisContext context)
        {
            var invocationExpression = (InvocationExpressionSyntax)context.Node;

            var methodSymbol = context.SemanticModel.GetSymbolInfo(invocationExpression).Symbol as IMethodSymbol;

            if (invocationExpression.Parent is ForEachStatementSyntax && methodSymbol != null)
            {
                if (StringExtensions.IsTypeMethodCalled(methodSymbol))
                {
                    context.ReportDiagnostic(Diagnostic.Create(ToCharArrayErrorRule, invocationExpression.GetLocation(),
                        methodSymbol.ToString()));
                }
                else if (LinqExtensions.IsLinqMethodCalled(context, invocationExpression, methodSymbol, "String", methods))
                {
                    context.ReportDiagnostic(Diagnostic.Create(ToArrayErrorRule, invocationExpression.GetLocation(),
                        methodSymbol.ToString()));
                }
            }
        }
    }
}