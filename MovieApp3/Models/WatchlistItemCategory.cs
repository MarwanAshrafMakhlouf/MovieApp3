using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class WatchlistItemCategory
    {
    
         public int Id { get; set; }
        public int WatchlistItemId { get; set; }
        public int CategoryId { get; set; }

        public virtual WatchlistItems WatchlistItem { get; set; }
        public virtual Categories Category { get; set; }
    }
}
