using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace mvc.Models
{
    public class Tv_show_crew
    {
        public string character_name { get; set; }
        public int TvShowId { get; set; }
        public virtual Tv_shows TvShow { get; set; }
        public int PersonId { get; set; }
        public virtual People Person { get; set; }
    }
}