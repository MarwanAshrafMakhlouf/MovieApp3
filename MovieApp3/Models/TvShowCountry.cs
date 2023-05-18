using mvc.Models;

namespace mvc.Models
{
    public class TvShowCountry
    {
        public int TvShowId { get; set; }
        public virtual Tv_shows TvShow { get;set; }
        public int CountryID { get; set; }
        public virtual Countries Country { get; set; }
    }
}
