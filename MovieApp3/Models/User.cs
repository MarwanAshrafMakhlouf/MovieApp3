using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string profile_picture { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "password")]
        public string password { get; set; }
        [StringLength(10)]
        public string? gender { get; set; }
        public DateTime? birth_date { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
        public virtual ICollection<Watchlist> WatchList { get; set; }


    }
}