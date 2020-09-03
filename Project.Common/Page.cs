using PagedList.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common
{
    public static class Page
    {
        public static async Task<IEnumerable<T>> DoPagingAsync<T>(IQueryable<T> DbSet, int PageNumber,int PageSize) where T : class
        {
            return await DbSet.ToPagedListAsync(PageNumber, PageSize);
        }
    }
}