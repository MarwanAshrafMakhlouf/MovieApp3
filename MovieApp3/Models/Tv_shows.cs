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
    public class Tv_shows
    {
        [Key]
        public int Id { get; set; }
        [StringLength(70)]
        public string title { get; set; }
        [StringLength(70)]
        public string poster { get; set; }
        [StringLength(10)]
        public string duration { get; set; }
        [StringLength(10)]
        public string? won { get; set; }
        [StringLength(25)]
        public string? nominated { get; set; }
        [StringLength(1400)]
        public string story_line { get; set; }
        [StringLength(10)]
        public string type { get; set; }
        [StringLength(10)]
        public int num_season { get; set; }
        public float? rating { get; set; }
        [StringLength(600)]
        public string brief { get; set; }
        public string audience { get; set; }
        [StringLength(4)]
        public string start_date { get; set; }
        [StringLength(4)]
        public string end_date { get; set; }
        [StringLength(25)]
        public string realeas_date { get; set; }
        [DefaultValue(false)]
        public bool isOnWatchlist { get; set; }
        [StringLength(7)]
        [DefaultValue("Tv show")]
        public string itemType { get; set; }
        public string director { get; set; }
        public string writer { get; set; }
        public virtual ICollection<TvShowCompany> TvShowCompanies { get; set; }
        public virtual ICollection<TvShowCountry> TvShowCountries { get; set; }
        public virtual ICollection<Episodes> Episodes { get; set; }

        public virtual ICollection<Tv_show_crew> TvShowCrew { get; set; }


        public virtual ICollection<TvShowCategory> TvShowCategories { get; set; }

    }
}