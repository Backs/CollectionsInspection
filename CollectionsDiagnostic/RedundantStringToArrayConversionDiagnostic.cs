﻿namespace CollectionsDiagnostic
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
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
    public class RedundantStringToArrayConversionDiagnostic : DiagnosticAnalyzer
    {
        private static readonly IReadOnlyCollection<string> Methods =
        new HashSet<string>(new[] { nameof(Enumerable.ToArray), nameof(Enumerable.ToList) });

        internal static readonly DiagnosticDescriptor RedundantStringToArrayRule = new(
            "CI0001",
            Resources.CI0001_Title,
            Resources.CI0001_Title,
            Categories.Performance,
            DiagnosticSeverity.Warning,
            true
        );

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
        ImmutableArray.Create(RedundantStringToArrayRule);

        public override void Initialize(AnalysisContext context)
        {
            context.EnableConcurrentExecution();
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);

            context.RegisterSyntaxNodeAction(Analyze, SyntaxKind.InvocationExpression);
        }

        private static void Analyze(SyntaxNodeAnalysisContext context)
        {
            var invocationExpression = (InvocationExpressionSyntax)context.Node;

            var methodSymbol = context.SemanticModel.GetSymbolInfo(invocationExpression).Symbol as IMethodSymbol;

            if (invocationExpression.Parent is ForEachStatementSyntax && methodSymbol != null)
            {
                CheckRedundantStringConversion(context, methodSymbol, invocationExpression);
            }
            else if (invocationExpression.Parent is MemberAccessExpressionSyntax parentExpression
                     && methodSymbol != null
                     && context.SemanticModel.GetSymbolInfo(parentExpression).Symbol?.ContainingType.Name ==  nameof(Enumerable))
            {
                CheckRedundantStringConversion(context, methodSymbol, invocationExpression);
            }
            else if (invocationExpression.Parent is ArgumentSyntax argumentSyntax
                     && argumentSyntax.Parent is ArgumentListSyntax argumentListSyntax
                     && argumentListSyntax.Parent is ObjectCreationExpressionSyntax objectCreationExpression
                     && objectCreationExpression.Type is GenericNameSyntax genericName
                     && genericName.Identifier.ToString() == "List"
                     && genericName.TypeArgumentList.Arguments.FirstOrDefault()?.ToString() == "char")
            {
                CheckRedundantStringConversion(context, methodSymbol, invocationExpression);
            }
        }

        private static void CheckRedundantStringConversion(SyntaxNodeAnalysisContext context, IMethodSymbol methodSymbol,
            InvocationExpressionSyntax invocationExpression)
        {
            if (StringExtensions.IsTypeMethodCalled(methodSymbol))
            {
                context.ReportDiagnostic(Diagnostic.Create(RedundantStringToArrayRule, invocationExpression.GetLocation(),
                    methodSymbol.ToString()));
            }
            else if (LinqExtensions.IsLinqMethodCalled(context, invocationExpression, methodSymbol, nameof(String), Methods))
            {
                context.ReportDiagnostic(Diagnostic.Create(RedundantStringToArrayRule, invocationExpression.GetLocation(),
                    methodSymbol.ToString()));
            }
        }
    }
}