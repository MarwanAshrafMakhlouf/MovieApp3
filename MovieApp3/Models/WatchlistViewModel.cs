
namespace mvc.Models
{
    public class WatchlistViewModel
    {
        public List<WatchlistItems> WatchlistItems { get; set; }
        public Dictionary<int, Movies> Movies { get; set; }
        public Dictionary<int, Tv_shows> TvShows { get; set; }
        public Dictionary<int, Episodes > Episodes { get; set; }
        public Dictionary<int, People > People { get; set; }
    }
}
