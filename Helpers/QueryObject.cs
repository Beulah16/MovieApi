using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Helpers
{
    public class QueryObject
    {
        public string? Title { get; set; } = null;
        public string? Genre { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
        public bool? IsReleased { get; set;}
        // public int PageNum { get; set; } = 1;
        // public int PageSize { get; set;} = 2;
    }
}