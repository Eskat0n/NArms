namespace NArms.Utility
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public static class Name
    {
        public static string Of<T>(Expression<Func<T>> expression)
        {
            return GetName(expression.Body);
        }
        
        public static IEnumerable<string> Of<T>(IEnumerable<Expression<Func<T>>> expressions)
        {
            if (expressions == null)
                throw new ArgumentNullException("expressions");

            return expressions.Select(Of);
        }

        public static string Of<T>(Expression<Func<T, object>> expression)
        {
            return expression != null ? GetName(expression.Body) : null;
        }
        
        public static IEnumerable<string> Of<T>(IEnumerable<Expression<Func<T, object>>> expressions)
        {
            if (expressions == null)
                throw new ArgumentNullException("expressions");

            return expressions.Select(Of);
        }

        public static string Of(LambdaExpression expression)
        {
            return GetName(expression.Body);
        }
        
        public static IEnumerable<string> Of(IEnumerable<LambdaExpression> expressions)
        {
            if (expressions == null)
                throw new ArgumentNullException("expressions");

            return expressions.Select(Of);
        }

        private static string GetName(Expression expression)
        {
            var extractor = new NamesExtractor();
            extractor.Visit(expression);
            return extractor.GetName();
        }

        #region Nested type: NamesExtractor

        private class NamesExtractor : ExpressionVisitor
        {
            private readonly Stack<string> _names = new Stack<string>();

            protected override Expression VisitMethodCall(MethodCallExpression node)
            {
                _names.Push(node.Method.Name);
                return base.VisitMethodCall(node);
            }

            protected override Expression VisitMember(MemberExpression node)
            {
                _names.Push(node.Member.Name);
                return base.VisitMember(node);
            }

            public string GetName()
            {
                return string.Join(".", _names);
            }
        }

        #endregion
    }
}