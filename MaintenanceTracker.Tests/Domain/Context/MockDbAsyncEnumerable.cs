using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceTracker.Tests.Domain.Context
{
    class MockDbAsyncEnumerable<T> : EnumerableQuery<T>, IDbAsyncEnumerable<T>, IQueryable<T>
    {
        public MockDbAsyncEnumerable(IEnumerable<T> enumerable)
            : base (enumerable)
        { }

        public MockDbAsyncEnumerable(Expression exp)
            :base (exp)
        { }

        public IDbAsyncEnumerator<T> GetAsyncEnumerator()
        {
            return new MockDbAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        IDbAsyncEnumerator IDbAsyncEnumerable.GetAsyncEnumerator()
        {
            return GetAsyncEnumerator();
        }

        IQueryProvider IQueryable.Provider
        {
            get { return new MockDbQueryProvider<T>(this); }
        }
    }
}
