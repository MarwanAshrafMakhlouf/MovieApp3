using mvc.Models;

namespace mvc.Models
{
    public class TvShowCompany
    {
        public int TvShowId { get; set; }
        public virtual Tv_shows TvShow { get; set; }

        public int CompanyID { get; set; }
        public virtual Production_companies Company { get; set; }
    }
}
