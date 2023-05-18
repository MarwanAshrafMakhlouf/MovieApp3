using mvc.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class WatchlistItems
    {
        [Key]
        public int Id { get; set; }


        public int WatchlistId { get; set; }
        public Watchlist Watchlist { get; set; }
        [StringLength(10)]
        public string itemType { get; set; } // 1 = movie, 2 = TV show, 3 = episode, 4 = person
        public int ItemId { get; set; }
        public int UserId { get; set; }

       

    }
}
