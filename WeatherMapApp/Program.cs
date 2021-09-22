using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

namespace WeatherMapApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var connection = new HttpClient();
            var coordinates = JObject.Parse(connection.GetStringAsync("https://api.openweathermap.org/data/2.5/weather?zip=35242&appid=1dcee7ffd45c44da5027030ca80e60a2")
                .Result).GetValue("coord").ToString().Replace('"', ' ').Replace('{', ' ').Replace('}', ' ').Replace(',', ' ');
            var weather = JToken.Parse(connection.GetStringAsync("https://api.openweathermap.org/data/2.5/weather?zip=35242&units=imperial&appid=1dcee7ffd45c44da5027030ca80e60a2")
                .Result).SelectToken("main.temp").ToString().Replace('"', ' ').Replace('{', ' ').Replace('}', ' ') + " Fahrenheit";
            Console.WriteLine(weather);
            Console.WriteLine(coordinates);
        }
    }
}
