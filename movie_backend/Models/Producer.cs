using System.ComponentModel.DataAnnotations;

namespace movie_backend.Models
{
    public class Producer
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string sex { set; get; }
        public string dob { set; get; }
        public string bio { set; get; }
    }
}
