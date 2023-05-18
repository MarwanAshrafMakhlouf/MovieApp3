namespace mvc.Models
{
    public class TvShowCategory
    {
        public int TvShowId { get; set; }
        public virtual Tv_shows TvShow { get; set; }
        public int CategoryId { get; set; }
        public virtual Categories Category { get; set; }
    }
}
