using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using mvc.Models;

namespace mvc.Models
{
    public class Countries
    {
        [Key]
        public int id{get; set;}
        public string country{get; set;}
        public ICollection<MovieCountry> MovieCountries { get; set;} 
        public  ICollection<TvShowCountry> TvShowCountries { get; set;}
        public  ICollection<EpisodeCountry> EpisodeCountries { get; set;}  
        
    }
}