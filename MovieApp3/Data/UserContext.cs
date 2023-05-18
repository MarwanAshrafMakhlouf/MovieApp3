using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using mvc.Models;

namespace mvc.Data
{
    public class UserContext : DbContext
    {
        public UserContext()
        {

        }
        public UserContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }

        public DbSet<Countries> countries { get; set; }
        public DbSet<Episode_crew> episode_crew { get; set; }
        public DbSet<Episodes> episodes { get; set; }
        public DbSet<Media> media { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Movie_crew> Movies_crew { get; set; }
        public DbSet<People> people { get; set; }
        public DbSet<Production_companies> production_companies { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
        public DbSet<Tv_shows> tv_shows { get; set; }
        public DbSet<Tv_show_crew> tv_show_crew { get; set; }

        public DbSet<MovieCompany> MovieCompanies { get; set; }
        public DbSet<MovieCountry> MovieCountries { get; set; }
        public DbSet<TvShowCompany> TvShowCompanies { get; set; }
        public DbSet<EpisodeCountry> EpisodeCountries { get; set; }
        public DbSet<EpisodeCompany> EpisodeCompanies { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<MovieCategories> MoviesCategories { get; set; }
        public DbSet<EpisodeCategory> EpisodeCategories { get; set; }
        public DbSet<TvShowCategory> TvShowCategories { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<PeopleRoles> PeopleRoles { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }
        public DbSet<WatchlistItems> WatchlistItems { get; set; }
        public DbSet<WatchlistItemCategory> WatchlistItemCategories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=LAPTOP-EK0EQRAB\\SQLEXPRESS;Initial Catalog=MovieInc_d;Integrated Security=True;Pooling=False;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .OnDelete(DeleteBehavior.Cascade);





            modelBuilder.Entity<People>()
                .HasMany(p => p.MovieCrew)
                .WithOne(mp => mp.Person)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<People>()
                .HasMany(p => p.TvShowCrew)
                .WithOne(tp => tp.Person)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<People>()
                .HasMany(p => p.EpisodeCrew)
                .WithOne(ep => ep.Person)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Movies>()
                .HasMany(m => m.MovieCrew)
                .WithOne(mp => mp.Movie)
                .OnDelete(DeleteBehavior.Cascade);





            modelBuilder.Entity<Tv_shows>()
                .HasMany(t => t.Episodes)
                .WithOne(ep => ep.TvShow)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Tv_shows>()
                .HasMany(t => t.TvShowCrew)
                .WithOne(tp => tp.TvShow)
                .OnDelete(DeleteBehavior.Cascade);





            modelBuilder.Entity<Episodes>()
                .HasMany(ep => ep.EpisodeCrew)
                .WithOne(ep => ep.Episode)
                .OnDelete(DeleteBehavior.Cascade);


            // Configure the relation between all tables and the watchlist
            modelBuilder.Entity<Watchlist>()
         .HasOne(w => w.User)
         .WithMany(u => u.WatchList)
         .HasForeignKey(w => w.UserId);


            modelBuilder.Entity<WatchlistItems>()
                .HasOne(w => w.Watchlist)
                .WithMany(wl => wl.WatchlistItems)
                .HasForeignKey(w => w.WatchlistId);







            modelBuilder.Entity<Movie_crew>()
            .HasKey(mp => new { mp.MovieId, mp.PersonId });

            modelBuilder.Entity<Movie_crew>()
                .HasOne(mp => mp.Movie)
                .WithMany(m => m.MovieCrew)
                .HasForeignKey(mp => mp.MovieId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Movie_crew>()
                .HasOne(mp => mp.Person)
                .WithMany(p => p.MovieCrew)
                .HasForeignKey(mp => mp.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure many-to-many relationship between TvShow and Person
            modelBuilder.Entity<Tv_show_crew>()
                .HasKey(tp => new { tp.TvShowId, tp.PersonId });

            modelBuilder.Entity<Tv_show_crew>()
                .HasOne(tp => tp.TvShow)
                .WithMany(t => t.TvShowCrew)
                .HasForeignKey(tp => tp.TvShowId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tv_show_crew>()
                .HasOne(tp => tp.Person)
                .WithMany(p => p.TvShowCrew)
                .HasForeignKey(tp => tp.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure many-to-many relationship between Episode and Person
            modelBuilder.Entity<Episode_crew>()
                .HasKey(ep => new { ep.EpisodeId, ep.PersonId });

            modelBuilder.Entity<Episode_crew>()
                .HasOne(ep => ep.Episode)
                .WithMany(e => e.EpisodeCrew)
                .HasForeignKey(ep => ep.EpisodeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Episode_crew>()
                .HasOne(ep => ep.Person)
                .WithMany(p => p.EpisodeCrew)
                .HasForeignKey(ep => ep.PersonId)
                .OnDelete(DeleteBehavior.Cascade);
            // Configure many-to-many relationship between Movie and Country.
            modelBuilder.Entity<MovieCountry>()
                .HasKey(mv => new { mv.MovieId, mv.CountryId });
            modelBuilder.Entity<MovieCountry>()
                .HasOne(mv => mv.Movie)
                .WithMany(m => m.MovieCountries)
                .HasForeignKey(mv => mv.MovieId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MovieCountry>()
             .HasOne(mc => mc.Country)
             .WithMany(c => c.MovieCountries)
             .HasForeignKey(mc => mc.CountryId)
             .OnDelete(DeleteBehavior.Cascade);
            // Configure many-to-many relationship between Movie and ProdCompany.
            modelBuilder.Entity<MovieCompany>()
                .HasKey(mv => new { mv.movieId, mv.CompanyID });
            modelBuilder.Entity<MovieCompany>()
                .HasOne(mc => mc.Company)
                .WithMany(c => c.MovieCompanies)
                .HasForeignKey(mc => mc.CompanyID)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<MovieCompany>()
                .HasOne(mc => mc.Movie)
                .WithMany(c => c.MovieCompanies)
                .HasForeignKey(mc => mc.movieId)
                .OnDelete(DeleteBehavior.Cascade);
            // Configur many-to-many relationship between TvShow and Country
            modelBuilder.Entity<TvShowCountry>()
                .HasKey(tv => new { tv.TvShowId, tv.CountryID });
            modelBuilder.Entity<TvShowCountry>()
                .HasOne(tv => tv.TvShow)
                .WithMany(c => c.TvShowCountries)
                .HasForeignKey(tv => tv.TvShowId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TvShowCountry>()
                .HasOne(tv => tv.Country)
                .WithMany(c => c.TvShowCountries)
                .HasForeignKey(tv => tv.CountryID)
                .OnDelete(DeleteBehavior.Cascade);
            // Configure many-to-many relationship between Tvshow and ProdCompany
            modelBuilder.Entity<TvShowCompany>()
                .HasKey(tv => new { tv.TvShowId, tv.CompanyID });
            modelBuilder.Entity<TvShowCompany>()
                .HasOne(tv => tv.Company)
                .WithMany(c => c.TvShowCompanies)
                .HasForeignKey(tv => tv.CompanyID)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TvShowCompany>()
                .HasOne(tv => tv.TvShow)
                .WithMany(c => c.TvShowCompanies)
                .HasForeignKey(tv => tv.TvShowId)
                .OnDelete(DeleteBehavior.Cascade);
            // Configure many-to-many relationship between Episode and Country
            modelBuilder.Entity<EpisodeCountry>()
                .HasKey(ep => new { ep.EpisodeId, ep.CountryID });
            modelBuilder.Entity<EpisodeCountry>()
                .HasOne(ep => ep.Country)
                .WithMany(c => c.EpisodeCountries)
                .HasForeignKey(ep => ep.CountryID)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<EpisodeCountry>()
                .HasOne(ep => ep.Episode)
                .WithMany(c => c.EpisodeCountries)
                .HasForeignKey(ep => ep.EpisodeId)
                .OnDelete(DeleteBehavior.Cascade);
            // Configure many-to-many relationship between Episode and ProdCompany
            modelBuilder.Entity<EpisodeCompany>()
                .HasKey(ep => new { ep.EpisodeId, ep.CompanyID });
            modelBuilder.Entity<EpisodeCompany>()
                .HasOne(ep => ep.Company)
                .WithMany(c => c.EpisodeCompanies)
                .HasForeignKey(ep => ep.CompanyID)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<EpisodeCompany>()
                .HasOne(ep => ep.Episode)
                .WithMany(c => c.EpisodeCompanies)
                .HasForeignKey(ep => ep.EpisodeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Configure many-to-many relationship between People and Roles
            modelBuilder.Entity<PeopleRoles>()
                .HasKey(pr => new { pr.personId, pr.roleId });
            modelBuilder.Entity<PeopleRoles>()
                .HasOne(pr => pr.role)
                .WithMany(p => p.PeopleRoles)
                .HasForeignKey(pr => pr.roleId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PeopleRoles>()
                .HasOne(pr => pr.person)
                .WithMany(p => p.PeopleRoles)
                .HasForeignKey(pr => pr.personId)
                .OnDelete(DeleteBehavior.Cascade);
            // Configure many-to-many relationship between Movie and Category
            modelBuilder.Entity<MovieCategories>()
                .HasKey(mr => new { mr.MovieId, mr.CategoryId });
            modelBuilder.Entity<MovieCategories>()
                .HasOne(mc => mc.Category)
                .WithMany(c => c.MovieCategories)
                .HasForeignKey(mc => mc.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<MovieCategories>()
                .HasOne(mc => mc.Movie)
                .WithMany(c => c.MovieCategories)
                .HasForeignKey(mc => mc.MovieId)
                .OnDelete(DeleteBehavior.NoAction);
            // Configure many-to-many relationship between Tvshow and Category
            modelBuilder.Entity<TvShowCategory>()
                .HasKey(tc => new { tc.TvShowId, tc.CategoryId });
            modelBuilder.Entity<TvShowCategory>()
                .HasOne(tc => tc.TvShow)
                .WithMany(c => c.TvShowCategories)
                .HasForeignKey(tc => tc.TvShowId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<TvShowCategory>()
                .HasOne(tc => tc.Category)
                .WithMany(c => c.TvShowCategories)
                .HasForeignKey(tc => tc.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            // Configure many-to-many relationship between Episode and Category
            modelBuilder.Entity<EpisodeCategory>()
                .HasKey(ec => new { ec.EpisodeId, ec.CategoryId });
            modelBuilder.Entity<EpisodeCategory>()
                .HasOne(ec => ec.Category)
                .WithMany(c => c.EpisodeCategories)
                .HasForeignKey(ec => ec.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<EpisodeCategory>()
                .HasOne(ec => ec.Episode)
                .WithMany(c => c.EpisodeCategories)
                .HasForeignKey(ec => ec.EpisodeId)
                .OnDelete(DeleteBehavior.NoAction);
            // Relationship for categories
            modelBuilder.Entity<WatchlistItemCategory>()
              .HasKey(wc => new { wc.Id });
                    modelBuilder.Entity<WatchlistItemCategory>()
            .HasOne(wc => wc.Category)
            .WithMany()
            .HasForeignKey(wc => wc.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        }
    }
}