using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using mvc.Models;
using System.ComponentModel;

namespace mvc.Models
{
    public class Episodes
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string title { get; set; }
        [StringLength(70)]
        public string poster { get; set; }
        [StringLength(25)]
        public string releas_date { get; set; }
        [StringLength(1400)]
        public string story_line { get; set; }
        public int rating { get; set; }
        [StringLength(700)]
        public string brief { get; set; }
        [StringLength(15)]
        public string audience { get; set; }
        [StringLength(25)]
        public string duration { get; set; }
        [StringLength(15)]
        public int? won { get; set; }
        [StringLength(25)]
        public int? nominated { get; set; }
        public int TvShowId { get; set; }
        public virtual Tv_shows TvShow { get; set; }
        [DefaultValue(false)]
        public bool isOnWatchlist { get; set; }
        [StringLength(7)]
        [DefaultValue("episode")]
        public string itemType { get; set; }



        public virtual ICollection<Episode_crew> EpisodeCrew { get; set; }


        public virtual ICollection<EpisodeCategory> EpisodeCategories { get; set; }
        public virtual ICollection<EpisodeCompany> EpisodeCompanies { get; set; }
        public virtual ICollection<EpisodeCountry> EpisodeCountries { get; set; }
    }

}