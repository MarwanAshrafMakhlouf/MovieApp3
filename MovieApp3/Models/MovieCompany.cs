using mvc.Models;

namespace mvc.Models
{
    public class MovieCompany
    {
           public int movieId { get; set; }
           public virtual Movies Movie { get; set; }

           public int CompanyID { get; set; }  
          public virtual Production_companies Company { get; set; }
       
    }
}
