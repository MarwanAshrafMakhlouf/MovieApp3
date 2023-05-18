using mvc.Models;
namespace  mvc.Models
{
    public class MovieCountry
    {
        public int MovieId { get; set; }
        public virtual Movies Movie { get; set; }

        public int CountryId { get; set; }
        public virtual Countries Country { get; set; }
    }
}
