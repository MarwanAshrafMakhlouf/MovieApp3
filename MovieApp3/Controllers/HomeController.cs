using System.Diagnostics;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models;


namespace mvc.Controllers;

public class HomeController : Controller
{
    private UserContext context = new UserContext();

    public static int Id;
    public static int watctid;
    public IActionResult welcome()
    {

        return View();
    }
    public IActionResult home()
    {
        var picks = new List<int>()
        {
            2,
            10,
            3,
            6,
            7

        };
        var topick = context.Movies.Where(m => picks.Contains(m.Id)).ToList();
        ViewBag.topick = topick;
        var serie = new List<int>() { 3, 2 };

        // var series = context.tv_shows.Where(m => serie.Contains(m.Id)).ToList();
        var popluar = new List<int>() { 7, 20, 6 };
        var mostpoplar = context.Movies.Where(m => popluar.Contains(m.Id)).ToList();
        //ViewBag.series = series;
        ViewBag.mostpular = mostpoplar;
        /*       ViewBag.series  = ViewBag.series.Addrange(ViewBag.mostpular);
               var comingsoon = context.Movies.Where(m => m.rating==null).ToList();
               ViewBag.comingsoon = comingsoon;*/
        ViewBag.profile_picture = retrive();
        return View();
    }
    public IActionResult edit_profile()
    {

        var user = context.users.Where(u => u.id.Equals(Id)).FirstOrDefault();
        if (user != null)
        {
            ViewBag.name = user.name;
            ViewBag.profile_picture = user.profile_picture;
            if (user.gender != null) { ViewBag.gender = user.gender; }
            if (user.birth_date != default(DateTime)) { ViewBag.birth = user.birth_date; }
        }

        return View();
    }
    public IActionResult watchlist(int watchlistId)
    {
       
        ViewBag.profile_picture = retrive();
        var watchlistitems = context.WatchlistItems.Where(w=> Id.Equals(w.UserId)).ToList();
        var moviesid = watchlistitems.Where(w => w.itemType == "movie" ).Select(w => w.ItemId).ToList();
        var tvshowid = watchlistitems.Where(w => w.itemType == "Tv show" ).Select(w => w.ItemId).ToList();
        var episodeid = watchlistitems.Where(w => w.itemType == "episode" ).Select(w => w.ItemId).ToList();
        var personid = watchlistitems.Where(w => w.itemType == "person" ).Select(w => w.ItemId).ToList();
        var movies = context.Movies.Where(m => moviesid.Contains(m.Id)).ToDictionary(m => m.Id);
        var tvshowss = context.tv_shows.Where(m => tvshowid.Contains(m.Id)).ToDictionary(m => m.Id);
        var episodes = context.episodes.Where(m => episodeid.Contains(m.Id)).ToDictionary(m => m.Id);
        var persons = context.people.Where(m => personid.Contains(m.Id)).ToDictionary(m => m.Id);
        var model = new WatchlistViewModel
        {
            WatchlistItems = watchlistitems,
            Movies = movies,
            TvShows = tvshowss,
            Episodes = episodes,
            People = persons
        };

        return View(model);
    }
    public IActionResult profile_icon()
    {

        return View();
    }
    [HttpPost]
    public IActionResult profile_icon(string ProfilePicture)
    {

        var user = context.users.Where(u => u.id.Equals(Id)).FirstOrDefault();

        user.profile_picture = ProfilePicture;
        context.SaveChanges();
        return RedirectToAction("home");

    }
    [HttpPost]
    public IActionResult edit_profile(string name, string gender, DateTime dateOfBirth)
    {
        var user = context.users.Where(u => u.id.Equals(Id)).FirstOrDefault();
        if (name != null) { user.name = name; }
        if (gender != null) { user.gender = gender; }
        if (dateOfBirth != default(DateTime)) { user.birth_date = dateOfBirth; }
        context.SaveChanges();
        return RedirectToAction("home");
    }
    public IActionResult login()
    {

        return View();
    }
    public IActionResult signup()
    {

        return View();
    }

    [HttpPost]
    public IActionResult signup(
        string email,
        string name,
        string password)
    {

        var user = context.users.Where(u => u.email.Equals(email)).FirstOrDefault();


        if (user != null)
        {
            @ViewBag.error = "Email already exist.";

        }
        else
        {
            var lastColumn = context.users.OrderBy(x => x.id).LastOrDefault();
            if (lastColumn == null)
            {
                Id = 1;
            }
            else
            {
                Id = lastColumn.id + 1;
            }
            string image_path = "profile/image-2.jpg";
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            User new_user = new User
            {

                name = name,
                email = email,
                password = passwordHash,
                profile_picture = image_path
            };
            // This the global id that will be used for authentication

            context.users.Add(new_user);
            context.SaveChanges();

            return RedirectToAction("home");
        }
        return View();

    }
    [HttpPost]
    public IActionResult login(
     string email,
     string password)
    {

        var user = context.users.Where(u => u.email.Equals(email)).FirstOrDefault();

        if (user != null)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
            bool verified = BCrypt.Net.BCrypt.Verify(password, user.password);
            if (verified)
            {
                Id = user.id;
                return RedirectToAction("home");
            }
            else
            {
                @ViewBag.Error = "Invalid email or password";
            }

        }
        else
        {
            @ViewBag.Error = "Invalid email or password";
        }
        return View();

    }
    public IActionResult Movies()
    {
        ViewBag.profile_picture = retrive();
        return View(context.Movies.ToList());

    }
    [HttpPost]
    public IActionResult AddWatchlist(int itemId)
    {
        Id = 1;

        return RedirectToAction("watchlist");
    }

    [HttpPost]
    public async Task<IActionResult> ToggleWatchlistItem(int itemId, string itemType, bool isOnWatchlist, bool addToWatchlist, bool removeFromWatchlist)
    {
        // This is the user Id for the purpose of this function I made it one
        // As I'm testing whithout logging in for some purposes for my project

        

        if (!isOnWatchlist)
        {

            var watchlistId = await GetOrCreateWatchlistId(Id);

            object item = null;
            var watchlistItem = new WatchlistItems
            {
                ItemId = itemId,
                itemType = itemType,
                WatchlistId = watchlistId,
                UserId = Id
            };

            if (itemType.Equals("movie"))
            {
                var movies = context.Movies.Where(m => m.Id == itemId).FirstOrDefault();
                movies.isOnWatchlist = true;
            }

            else if (itemType.Equals("Tv Show"))
            {
                var shows = context.tv_shows.Where(m => m.Id == itemId).FirstOrDefault();
                shows.isOnWatchlist = true;
            }

            else if (itemType.Equals("episode"))
            {
                var ep = context.episodes.Where(m => m.Id == itemId).FirstOrDefault();
                ep.isOnWatchlist = true;
            }

            else if (itemType.Equals("person"))
            {
                var pr = context.people.Where(m => m.Id == itemId).FirstOrDefault();
                pr.isOnWatchlist = true;
            }

            context.WatchlistItems.Add(watchlistItem);
        }
        else if (isOnWatchlist)
        {

            var watchlistId = await GetOrCreateWatchlistId(Id);
            switch (itemType)
            {
                case "movie":
                    var movies = context.Movies.Where(w => w.Id.Equals(itemId)).FirstOrDefault();
                    movies.isOnWatchlist = false;
                    break;
                case "Tv show":
                    var tvshows = context.Movies.Where(w => w.Id.Equals(itemId)).FirstOrDefault(); ;
                    tvshows.isOnWatchlist = false;
                    break;
                case "episode":
                    var episodes = context.episodes.Where(w => w.Id.Equals(itemId)).FirstOrDefault(); ;
                    episodes.isOnWatchlist = false;
                    break;
                case "person":
                    var person = context.people.Where(w => w.Id.Equals(itemId)).FirstOrDefault();
                    person.isOnWatchlist = false;
                    break;
            }
           
            var watchlistItem = await context.WatchlistItems.FirstOrDefaultAsync(w => w.ItemId == itemId && w.itemType == itemType && w.WatchlistId == watchlistId && w.UserId == Id);

            if (watchlistItem != null)
            {
                context.WatchlistItems.Remove(watchlistItem);   
            }
        }

        await context.SaveChangesAsync(); // Redirect to the p await context.SaveChangesAsync();revious page or the watchlist page.
        return RedirectToAction("watchlist", "Home");
    }

  private async Task<int> GetOrCreateWatchlistId(int userId)
  {
      var watchlist = context.Watchlists.FirstOrDefault(w => w.UserId == userId);

      if (watchlist == null)
      {
          watchlist = new Watchlist
          {
              UserId = userId
          };

          context.Watchlists.Add(watchlist);
           context.SaveChanges();
      }

      return watchlist.Id;
  }
    public IActionResult filter()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> filtered(string filter)

    {
        ViewBag.profile_picture = retrive();
        var category = await context.Categories.FirstOrDefaultAsync(n => n.name == filter);
        var movieCategory = context.MoviesCategories.Where(predicate: m => m.CategoryId == category.id).Select(mc => mc.MovieId).ToList();
        var movies = context.Movies.Where(m => movieCategory.Contains(m.Id)).ToList();
        ViewBag.filter = filter;
        return View(movies);
    }
    public string retrive()
    {
        UserContext context = new UserContext();
        var user = context.users.Where(u => u.id.Equals(Id)).FirstOrDefault();

        return user.profile_picture;
        

    }

    public IActionResult movie_info(int movieId)
    {
        ViewBag.profile_picture = retrive();
        var movieCategories = context.MoviesCategories.Where(m => m.MovieId
        == movieId).Select(m => m.CategoryId).ToList();
        var cat = context.Categories.Where(c => movieCategories.Contains(c.id))
            .Select(c => c.name).ToList();
        ViewBag.category = cat;
        var vidp = context.media.FirstOrDefault(context => context.ItemId == movieId && context.itemType.Equals("movie"));
        ViewBag.thumb = vidp;
        var movie = context.Movies.FirstOrDefault(m => m.Id == movieId);
        var moviecrew = context.Movies_crew.Where(m => m.MovieId == movieId).ToList();
        var moviecrewid = context.Movies_crew.Where(m => m.MovieId == movieId).Select(m =>m.PersonId).ToList();
        var stars = context.people.Where(p => moviecrewid.Contains(p.Id)).ToList();
        var productionId = context.MovieCompanies.Where(m => m.movieId == movieId).Select(m=> m.CompanyID).ToList();
        var companies = context.production_companies.Where(m => productionId.Contains(m.id)).ToList();
        var coutriesId = context.MovieCountries.Where(m => m.MovieId == movieId).Select(m => m.CountryId).ToList();
        var countries = context.countries.Where(m => coutriesId.Contains(m.id)).ToList();
        string m = "movie";
     
        var reviews = context.Reviews.Where(m => movieId.Equals(m.itemId) && m.itemType == "movie").ToList();
        var reviewid = context.Reviews.Where(m => movieId.Equals(m.itemId) && m.itemType == "movie").Select(m=>m.UserId).ToList();
        
        var username = context.users.Where(m => reviewid.Contains(m.id)).ToList();
        ViewBag.companies = companies; 
        ViewBag.countries = countries;
        ViewBag.crew = moviecrew;
        ViewBag.stars = stars;
        ViewBag.reviews = reviews;
        ViewBag.username = username;

        return View(movie);
    }
    [HttpPost]
    public async Task<IActionResult> reviewSubmit(int rating, int itemId, string itemType, string spoiler, string review)
    {
        bool spoil = spoiler.Equals("yes");
       // int rating = ratingModel.rating;

        var item = context.Reviews.FirstOrDefault(m => m.itemId == itemId && itemType.Equals(m.itemType) && Id.Equals(m.UserId));
        if (item != null)
        {
            item.rating_text = review;
            item.rating = rating;
            item.spoiler = spoil;
        }
        else
        {
            var reviews = new Reviews
            {
                UserId = Id,
                itemId = itemId,
                rating = rating,
                rating_text = review,
                itemType = itemType,
                spoiler = spoil
            };
            await context.Reviews.AddAsync(reviews);
        }
        await context.SaveChangesAsync();
        return RedirectToAction("home","Home");
    }

    public IActionResult review()
    {
        var reviwed = context.Reviews.Where(r => Id.Equals(r.UserId)).ToList();
        var moviesid =reviwed.Where(w => w.itemType == "movie").Select(w => w.itemId).ToList();
        var tvshowid = reviwed.Where(w => w.itemType == "Tv show").Select(w => w.itemId).ToList();
        var episodeid =reviwed.Where(w => w.itemType == "episode").Select(w => w.itemId).ToList();
        
        var movies = context.Movies.Where(m => moviesid.Contains(m.Id)).ToDictionary(m => m.Id);
        var tvshows = context.tv_shows.Where(m => tvshowid.Contains(m.Id)).ToDictionary(m => m.Id);
        var episodes = context.episodes.Where(m => episodeid.Contains(m.Id)).ToDictionary(m => m.Id);
       
        var model = new reviewedItems
        {
            Reviews = reviwed,
            Movies = movies,
            Episodes = episodes,
            TvShows = tvshows
        };
        return View(model);
    }

    public IActionResult  search(string value)
    {
       var movies = context.Movies.Where(m=> m.title ==value).FirstOrDefault();
        if (movies != null)
        {
            return RedirectToAction("movie_info", "home", new {movieId = movies.Id});
        }
        
        return View();
    }
    public IActionResult tv_show()
    {
        ViewBag.profile_picture = retrive();
       return View(context.tv_shows.ToList());
    }
}
