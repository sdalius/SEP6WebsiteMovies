﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesWebsite.Models
{
    public class Users
    {
        [JsonProperty("userID")]
        public int userID { get; set; }
        [JsonProperty("username")]
        public string username { get; set; }
        [JsonProperty("Token")]
        public string Token { get; set; }
    }
}
