using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace mvc.Models
{
    public class Reviews
    {
        [Key]
        public int id { get; set; }
        public int rating { get; set; }
        public string? rating_text { get; set; }
        public bool spoiler { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [StringLength(10)]
        public string itemType { get; set; }
        public int itemId { get; set; }


    }
}