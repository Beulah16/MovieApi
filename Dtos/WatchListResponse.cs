using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Dtos
{
    public class WatchListResponse
    {
        public Guid Id { get; set; }
        public MovieResponse Movie { get; set; }
    }
}