using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace mvc.Models
{
    public class Media
    {
        [Key]
        public int id { get; set; }
        public string content_type { get; set; }
        public string media_type { get; set; }
        [StringLength(10)]
        public string itemType { get; set; } // 1 = movie, 2 = TV show, 3 = episode, 4 = person
        public int ItemId { get; set; }


    }
}