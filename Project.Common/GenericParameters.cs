using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common
{
        public class GenericParameters<T> where T : class
        {
        public GenericParameters(Expression<Func<T, object>> OrderBy,bool Asc,Expression<Func<T, bool>> Filter,int PageNumber,int PageSize)
        {
            this.OrderBy = OrderBy;
            this.Asc = Asc;
            this.Filter = Filter;
            this.PageNumber = PageNumber;
            this.PageSize = PageSize;
        }
        public Expression<Func<T, object>> OrderBy { get; set; }
        public bool Asc { get; set; }
        public Expression<Func<T, bool>> Filter { get; set; } 
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        }
}
