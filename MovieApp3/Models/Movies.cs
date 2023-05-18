using mvc.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }
        [StringLength(70)]
        public string poster { get; set; }
        [StringLength(50)]
        public string title { get; set; }
        [StringLength(25)]
        public string release_date { get; set; }
        [StringLength(10)]
        public string duration { get; set; }
        [StringLength(10)]
        public string? won { get; set; }
        [StringLength(25)]
        public string? nominated { get; set; }
        public string story_line { get; set; }
        public string brief { get; set; }
        [StringLength(10)]
        public string audience { get; set; }
        [StringLength(4)]
        public string? rating { get; set; }
        [DefaultValue(false)]
        public bool isOnWatchlist { get; set; }
        [StringLength(5)]
        [DefaultValue("movie")]
        public string itemType { get; set; }
        public string director { get; set; }    
        public string writer { get; set; } 
        public virtual ICollection<MovieCompany> MovieCompanies { get; set; }
        public virtual ICollection<MovieCountry> MovieCountries { get; set; }
        public virtual ICollection<MovieCategories> MovieCategories { get; set; }



        public virtual ICollection<Movie_crew> MovieCrew { get; set; }


    }
}