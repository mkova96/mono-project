using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common
{
    public static class Filter
    {
        public static IQueryable<T> WhereFilter<T>(IQueryable<T> DbSet, Expression<Func<T, bool>> Filter) where T : class
        {
            if (Filter != null)
            {
                return DbSet.Where(Filter);
            }
            return DbSet;
        }
    }
}
