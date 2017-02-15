using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;

namespace IQueryableExample_FileQuery
{
    internal class FileQueryProvider : IQueryProvider
    {
        private readonly string _folder;

        public FileQueryProvider(string folder)
        {
            _folder = folder;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return CreateQuery<FileData>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            if (typeof(TElement) != typeof(FileData))
            {
                throw new NotSupportedException();
            }
            return (IQueryable<TElement>)new FileQuery(this, expression);
        }

        public object Execute(Expression expression)
        {
            throw new NotImplementedException();
        }

        public TResult Execute<TResult>(Expression expression)
        {
            if (typeof(TResult) == typeof(IEnumerator<FileData>))
            {
                if (expression.NodeType == ExpressionType.Constant)
                {
                    return (TResult)HandleConstantExpression((ConstantExpression)expression);
                }
                else if (expression.NodeType == ExpressionType.Call)
                {
                    return (TResult)HandleCallExpression((MethodCallExpression)expression);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            throw new NotImplementedException();
        }

        private IEnumerator<FileData> HandleCallExpression(MethodCallExpression expression)
        {
            if (expression.Method.Name == "Where")
            {
                if (expression.Arguments[1].NodeType == ExpressionType.Quote)
                {
                    var quote = (UnaryExpression)expression.Arguments[1];
                    if (quote.Operand.NodeType == ExpressionType.Lambda)
                    {
                        var lambda = (LambdaExpression)quote.Operand;
                        if (lambda.Body.NodeType == ExpressionType.Equal)
                        {
                            var equal = (BinaryExpression)lambda.Body;
                            if (equal.Left.NodeType == ExpressionType.MemberAccess
                                && ((MemberExpression)equal.Left).Member.Name == "Name"
                                && equal.Right.NodeType == ExpressionType.Constant)
                            {
                                var fileName = (string)((ConstantExpression)equal.Right).Value;
                                var lines = File.ReadAllLines(Path.Combine(_folder, fileName));
                                yield return new FileData
                                {
                                    Name = fileName,
                                    FirstLine = lines.FirstOrDefault(),
                                    LastLine = lines.LastOrDefault(),
                                    LinesInTheMiddle = lines.Count() > 2 ? lines.Skip(1).Take(lines.Count() - 2) : Enumerable.Empty<string>()
                                };
                            }
                            else
                            {
                                throw new NotImplementedException();
                            }
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private IEnumerator<FileData> HandleConstantExpression(ConstantExpression expression)
        {
            var fileQuery = expression.Value as FileQuery;
            if (fileQuery != null)
            {
                foreach (var file in Directory.EnumerateFiles(_folder))
                {
                    var lines = File.ReadAllLines(file);
                    yield return new FileData
                    {
                        Name = Path.GetFileName(file),
                        FirstLine = lines.FirstOrDefault(),
                        LastLine = lines.LastOrDefault(),
                        LinesInTheMiddle = lines.Count() > 2 ? lines.Skip(1).Take(lines.Count() - 2) : Enumerable.Empty<string>()
                    };
                }
            }
            else
            {
                throw new NotImplementedException();
            }
        }

    }
}