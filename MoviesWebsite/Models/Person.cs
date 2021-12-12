using System.ComponentModel.DataAnnotations;

namespace MoviesWebsite.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Birth { get; set; }
    }
}


