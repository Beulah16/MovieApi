using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Helpers
{
    public class QueryObject
    {
        public string? Search { get; set; } = null;
        // public FilterObject? FilterBy { get; set; }
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
        public bool? IsReleased { get; set;}
        // public int PageNum { get; set; } = 1;
        // public int PageSize { get; set;} = 2;
    }

}