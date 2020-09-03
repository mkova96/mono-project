using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common
{
    public static class Sort
    {
        public static IQueryable<T> OrderBySort<T>(IQueryable<T> DbSet, Expression<Func<T, object>> Sort,bool Asc) where T : class
        {
            if (Asc)
            {
                return DbSet.OrderBy(Sort);
            }
            return DbSet.OrderByDescending(Sort);
        }
    }
}
