namespace mvc.Models
{
    public class reviewedItems
    {
        public List<Reviews> Reviews { get; set; }
        public Dictionary<int, Movies> Movies { get; set; }
        public Dictionary<int, Tv_shows> TvShows { get; set; }
        public Dictionary<int, Episodes> Episodes { get; set; }
    }
}
