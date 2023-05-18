using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using mvc.Models;
using System.ComponentModel;

namespace mvc.Models
{
    public class People
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string profile_picture { get; set; }
        public string brief { get; set; }
        public string birth_year { get; set; }
        public string height { get; set; }
        public string state_born { get; set; }
        public string city_born { get; set; }
        public string country_born { get; set; }
        public string? spouse_name { get; set; }
        public int? num_childern { get; set; }
        public string? married { get; set; }
        public string? divorce { get; set; }
        public string? won { get; set; }
        public string? nominated { get; set; }
        [DefaultValue(false)]
        public bool isOnWatchlist { get; set; }
        [StringLength(10)]
        [DefaultValue("person")]
        public string itemType { get; set; } // 1 = movie, 2 = TV show, 3 = episode, 4 = person

        public virtual ICollection<Movie_crew> MovieCrew { get; set; }
        public virtual ICollection<Tv_show_crew> TvShowCrew { get; set; }
        public virtual ICollection<Episode_crew> EpisodeCrew { get; set; }

        public virtual ICollection<PeopleRoles> PeopleRoles { get; set; }

    }
}