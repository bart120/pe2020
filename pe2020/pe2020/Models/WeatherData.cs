using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace pe2020.Models
{
    public class WeatherData
    {
        [JsonProperty("name")]
        public string CityName { get; set; }
        [JsonProperty("weather")]
        public Weather[] Weather { get; set; }
        [JsonProperty("main")]
        public Main Main { get; set; }
        [JsonProperty("wind")]
        public Wind wind { get; set; }
    }

    public class Main
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }
        [JsonProperty("humidity")]
        public long Humidity { get; set; }
    }

    public class Weather
    {
        [JsonProperty("main")]
        public string  Visibility { get; set; }
        [JsonProperty("icon")]
        public string  Icon { get; set; }
    }

    public class Wind
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
    }
}
