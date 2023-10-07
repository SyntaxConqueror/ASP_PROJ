using System.Text.Json.Serialization;
using System.Text.Json;

namespace ASP_PROJ
{
    public class MyInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("lastname")]
        public string LastName { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("destination")]
        public string Destination { get; set; }
        
    }
}
