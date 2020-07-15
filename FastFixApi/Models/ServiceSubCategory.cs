using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FastFixApi.Models
{
    public class ServiceSubCategory
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string SubCategory { get; set; }
        
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        
        public ServiceCategory ServiceCategory { get; set; }
        //public DateTime SubCateDate { get; set; }
    }
}
