using System.ComponentModel.DataAnnotations;

namespace movie_backend.Models
{
    public class MovieCast
    {
        [Key]
        public int id { get; set; }
        public int movie { get; set; }
        public int actor { get; set; }
    }
}
