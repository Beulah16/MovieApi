using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Dtos.SubscriptionDtos
{
    public class SubscriptionRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public List<string> Benefits { get; set; } = [];
        public List<string> Limitations { get; set; } = [];
    }
}