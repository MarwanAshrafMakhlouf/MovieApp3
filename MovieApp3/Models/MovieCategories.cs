namespace mvc.Models
{
    public class MovieCategories
    {
        public int MovieId { get; set; }
        public virtual Movies Movie {get; set;}
        public int CategoryId { get; set; }
        public virtual Categories Category { get; set; }
    }
}
