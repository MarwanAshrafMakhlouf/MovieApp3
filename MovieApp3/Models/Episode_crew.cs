using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Models
{
    public class Episode_crew
    {
        public string character_name { get; set; }
        public int EpisodeId { get; set; }
        public virtual Episodes Episode { get; set; }
        public int PersonId { get; set; }
        public virtual People Person { get; set; }



    }
}