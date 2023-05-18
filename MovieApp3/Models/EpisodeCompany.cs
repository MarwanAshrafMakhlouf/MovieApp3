using mvc.Models;

namespace mvc.Models
{
    public class EpisodeCompany
    {
        public int EpisodeId { get; set; }
        public virtual Episodes Episode { get; set; }

        public int CompanyID { get; set; }
        public virtual Production_companies Company { get; set; }
    }
}
