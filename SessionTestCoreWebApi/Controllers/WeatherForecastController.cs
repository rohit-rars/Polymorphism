using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace SessionTestCoreWebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    //[Route("api/{v:apiVersion}/WeatherForecast")]  // URL based Versioning - [APIVersion(1.0)] is required. Version will be sent in Request URL. http://localhost:5234/api/1.0/WeatherForecast
    //[Route("api/WeatherForecast")] // Query String-Based Versioning - [APIVersion(1.0)] is required. In this we will send  api-version=1.0 in query string. 
    [Route("api/[controller]")] // HTTP Header-Based Versioning - This type of versioning makes URIs stay clean because we only modify the Accept header values.
                                // [APIVersion(1.0)] is required. We need to specify accept header name in AddApiVersioning (method in program.cs)
                                // -> options.ApiVersionReader = new HeaderApiVersionReader("x-api-version"). Further we need to pass value of x-api-version request header.
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            if(HttpContext.Items["isVerified"] == null)
            {
                HttpContext.Items["isVerified"] = true;
            }
            else
            {
                var resultBool = HttpContext.Items["isVerified"];
            }

            var currentTime = DateTime.Now;

            // Requires SessionExtensions from sample.
            if (HttpContext.Session.Get<DateTime>("Session_Data") == default)
            {
                HttpContext.Session.Set<DateTime>("Session_Data", currentTime);
            }

            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            return result;
        }
    }

    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T? Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}