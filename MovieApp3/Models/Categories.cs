using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class Categories
    {
        [Key]
        public int id { get; set; }
        [StringLength(30)]
        public string name { get; set; }
        public virtual ICollection<MovieCategories> MovieCategories { get; set; }    
        public virtual ICollection<EpisodeCategory> EpisodeCategories { get; set; }    
        public virtual ICollection<TvShowCategory> TvShowCategories { get; set; }    
       
        
    }
}