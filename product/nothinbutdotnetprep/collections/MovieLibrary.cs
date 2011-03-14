using System;
using System.Collections.Generic;

namespace nothinbutdotnetprep.collections
{
    public class MovieLibrary
    {
        IList<Movie> movies;

        public MovieLibrary(IList<Movie> list_of_movies)
        {
            this.movies = list_of_movies;
        }

        public IEnumerable<Movie> all_movies()
        {
            foreach( var v in this.movies)
            {
                yield return v;
            }
//            return  movies;
        }

        public void add(Movie movie)
        {
            foreach (Movie m in movies)
            {
                
            }

            if (!movies.Contains(movie))
            {
                this.movies.Add(movie);
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_descending
        {
            get
            {
                List<Movie> sortList = new List<Movie>(movies);
                sortList.Sort((a, b) => (b.title.CompareTo(a.title)));
                return sortList;
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar()
        {
            foreach (var movie in movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_movies_published_by_pixar_or_disney()
        {
            foreach (var movie in movies)
            {
                if (movie.production_studio == ProductionStudio.Pixar || movie.production_studio == ProductionStudio.Disney)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_title_ascending
        {
            get
            {
                List<Movie> sortList = new List<Movie>(movies);
                sortList.Sort((a, b) => (a.title.CompareTo(b.title)));
                return sortList;
            }
        }

        public IEnumerable<Movie> sort_all_movies_by_movie_studio_and_year_published()
        {
            List<Movie> sortList = new List<Movie>(movies);
            sortList.Sort(delegate(Movie a, Movie b)
            {
                int studioCodeA = GetProductionStudioRating(a.production_studio);
                int studioCodeB = GetProductionStudioRating(b.production_studio);

                if (studioCodeA < studioCodeB) return -1;
                if (studioCodeA > studioCodeB) return 1;
                if (a.date_published < b.date_published) return -1;
                if (a.date_published > b.date_published) return 1;
                return 0;
            });
            return sortList;
        }

        private int GetProductionStudioRating(ProductionStudio productionStudio)
        {
            if (productionStudio == ProductionStudio.MGM) return 0;
            if (productionStudio == ProductionStudio.Pixar) return 1;
            if (productionStudio == ProductionStudio.Dreamworks) return 2;
            if (productionStudio == ProductionStudio.Universal) return 3;
            if (productionStudio == ProductionStudio.Disney) return 4;

            return 5;
        }

        public IEnumerable<Movie> all_movies_not_published_by_pixar()
        {
           foreach (var movie in movies)
           {
               if (movie.production_studio != ProductionStudio.Pixar)
               {
                   yield return movie;
               }
           }
        }

        public IEnumerable<Movie> all_movies_published_after(int year)
        {
            foreach (var movie in movies)
            {
                if (movie.date_published.Year > year)
                {
                    yield return movie;
                }
            }
        }

        public IEnumerable<Movie> all_movies_published_between_years(int startingYear, int endingYear)
        {
            foreach (var movie in movies)
            {
                if (movie.date_published.Year >= startingYear && movie.date_published.Year <= endingYear)
                {
                    yield return movie;
                }
            }
        }

        private IEnumerable<Movie> findByGenre(Genre genre)
        {
            foreach (Movie movie in movies)
            {
                if (movie.genre == genre)
                {
                    yield return movie;
                }
            }            
        }

        public IEnumerable<Movie> all_kid_movies()
        {
            return findByGenre(Genre.kids);
        }

        public IEnumerable<Movie> all_action_movies()
        {
            return findByGenre(Genre.action);
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_descending()
        {
            List<Movie> sortList = new List<Movie>(movies);
            sortList.Sort(delegate(Movie a, Movie b)
            {
                if (a.date_published == b.date_published) return 0;
                if (a.date_published < b.date_published) return 1;
                return -1;
            });
            return sortList;
        }

        public IEnumerable<Movie> sort_all_movies_by_date_published_ascending()
        {
            List<Movie> sortList = new List<Movie>(movies);
            sortList.Sort(delegate(Movie a, Movie b)
            {
                if (a.date_published == b.date_published) return 0;
                if (a.date_published > b.date_published) return 1;
                return -1;
            });
            return sortList;
        }

    }

    
}