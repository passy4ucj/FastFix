using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FastFixApi.Models
{
    public class ServiceCategory
    {
        public int Id { get; set; }
        [Required]
        public string Category { get; set; }
        public ICollection<ServiceSubCategory> SubCategories { get; set; }
    }
}
