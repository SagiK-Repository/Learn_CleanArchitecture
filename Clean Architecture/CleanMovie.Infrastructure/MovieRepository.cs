using CleanMovie.Application;
using CleanMovie.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanMovie.Infrastructure
{
    public class MovieRepository : IMovieRepository
    {
        public static List<Movie> movies = new List<Movie>()
        {
            new Movie { Id = 1, Name = "Passion of Christ", Cost = 2 },
            new Movie { Id = 2, Name = "Home Alone 4", Cost = 3 }
        };

        private readonly MovieDBContext _movieDBContext;

        public MovieRepository(MovieDBContext movieDBContext)
        {
            _movieDBContext = movieDBContext;
        }

        public Movie CreateMovie(Movie movie)
        {
            _movieDBContext.Movies.Add(movie);
            _movieDBContext.SaveChanges();
            return movie;
        }

        public List<Movie> GetAllMovies()
        {
            return _movieDBContext.Movies.ToList();
        }
    }
}
