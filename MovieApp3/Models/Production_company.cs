using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using mvc.Models;

namespace mvc.Models
{
    public class Production_companies
    {
        [Key]
        public int  id { get; set; }
        public string name {get; set;}
        public ICollection<MovieCompany> MovieCompanies { get; set; }
        public ICollection<TvShowCompany> TvShowCompanies { get; set; }
        public ICollection<EpisodeCompany> EpisodeCompanies { get; set; }
    }
}