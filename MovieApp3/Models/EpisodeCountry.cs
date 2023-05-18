using mvc.Models;

namespace mvc.Models
{
    public class EpisodeCountry
    {
        public int EpisodeId { get; set; }
        public virtual Episodes Episode { get; set; }
        public int CountryID { get; set; }
        public virtual Countries Country { get; set; }
    }
}
