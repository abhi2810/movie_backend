using System.ComponentModel.DataAnnotations;

namespace movie_backend.Models
{
    public class Actor
    {
        [Key]
        public int id { set; get; }
        public string name { set; get; }
        public string sex { set; get; }
        public string dob { set; get; }
        public string bio { set; get; }
    }
}
