using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Common
{
    public class UriParameters
    {
        public string Filter { get; set; } = "";
        public string OrderBy { get; set; } = "";
        public string Asc { get; set; } = "";
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}   