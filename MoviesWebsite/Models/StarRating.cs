using Newtonsoft.Json;

namespace MoviesWebsite.Models
{
    public class StarRating
    {
        [JsonProperty("RatingAverage")]
        public double RatingAverage { get; set; }
        [JsonProperty("MoviesActedIn")]
        public int MoviesActedIn { get; set; }
        [JsonProperty("VotesSum")]
        public int VotesSum { get; set; }
    }
}
