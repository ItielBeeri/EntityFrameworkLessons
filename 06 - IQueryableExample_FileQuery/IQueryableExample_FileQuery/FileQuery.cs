using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IQueryableExample_FileQuery
{
    internal class FileQuery : IQueryable<FileData>
    {
        private readonly Expression _expression;
        private readonly FileQueryProvider _provider;

        public FileQuery(string folder)
            : this(new FileQueryProvider(folder)) { }

        public FileQuery(FileQueryProvider provider)
        {
            _provider = provider;
            _expression = Expression.Constant(this);
        }

        public FileQuery(FileQueryProvider provider, Expression expression)
        {
            _provider = provider;
            _expression = expression;
        }

        public Type ElementType
        {
            get
            {
                return typeof(FileData);
            }
        }

        public Expression Expression
        {
            get
            {
                return _expression;
            }
        }

        public IQueryProvider Provider
        {
            get
            {
                return _provider;
            }
        }

        public IEnumerator<FileData> GetEnumerator()
        {
            return _provider.Execute<IEnumerator<FileData>>(_expression);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}