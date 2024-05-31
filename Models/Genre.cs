using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Type { get; set; } = string.Empty;
    }
}