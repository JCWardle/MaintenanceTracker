using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MaintenanceTracker.Tests.Domain.Context
{
    class MockDbQueryProvider<T> : IDbAsyncQueryProvider 
    {
        private readonly IQueryProvider _inner;
        public MockDbQueryProvider(IQueryProvider provider)
        {
            _inner = provider;
        }

        public IQueryable<T> CreateQuery<T>(Expression exp)
        {
            return new MockDbAsyncEnumerable<T>(exp);
        }

        public IQueryable CreateQuery(Expression exp)
        {
            return new MockDbAsyncEnumerable<T>(exp);
        }

        public object Execute(Expression exp)
        {
            return _inner.Execute(exp);
        }

        public TResult Execute<TResult>(Expression exp)
        {
            return _inner.Execute<TResult>(exp);
        }

        public Task<object> ExecuteAsync(Expression exp, CancellationToken token)
        {
            return Task.FromResult(Execute(exp));
        }

        public Task<TResult> ExecuteAsync<TResult>(Expression exp, CancellationToken token)
        {
            return Task.FromResult(Execute <TResult>(exp));
        }
    }
}
