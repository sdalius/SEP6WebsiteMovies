using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MoviesWebsite.Models
{
    public class DecadeRating
    {
        [JsonProperty("AverageRating")]
        public double AverageRating { get; set; }
        [JsonProperty("NumberOfMovies")]
        public int NumberOfMovies { get; set; }
        [JsonProperty("NumberOfVotes")]
        public int NumberOfVotes { get; set; }
    }
}
