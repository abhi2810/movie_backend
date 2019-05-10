using System.ComponentModel.DataAnnotations;

namespace movie_backend.Models
{
    public class Movie
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int year { get; set; }
        public string plot { get; set; }
        public string poster { get; set; }
        public string producer { set; get; }
        public string actors { set; get; }
    }
}
