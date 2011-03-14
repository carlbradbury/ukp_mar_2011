using System;

namespace nothinbutdotnetprep.collections
{
    public class Movie: IEquatable<Movie>
    {
        public string title { get; set; }
        public ProductionStudio production_studio { get; set; }
        public Genre genre { get; set; }
        public int rating { get; set; }
        public DateTime date_published { get; set; }

        public override string ToString()
        {
            return title + " " + date_published.Year + " " + production_studio;
        }

        public bool Equals(Movie other)
        {
            if (other.title == this.title) return true;

            return false;
        }

//        public int CompareTo(Movie other)
//        {
//            return this.date_published.CompareTo(other.date_published);
//        }
    }


}