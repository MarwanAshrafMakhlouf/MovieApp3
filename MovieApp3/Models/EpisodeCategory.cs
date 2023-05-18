namespace mvc.Models
{
    public class EpisodeCategory
    {
        public int EpisodeId { get; set; }
        public virtual Episodes Episode { get; set; }

        public int CategoryId { get; set; }
        public virtual Categories Category { get; set; }
    }
}
