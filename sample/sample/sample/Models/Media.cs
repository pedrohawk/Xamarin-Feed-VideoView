using Newtonsoft.Json;

namespace Sample.Models
{
    public class Media : BaseModel
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("IdUser")]
        public int IdUser { get; set; }

        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Filename")]
        public string Filename { get; set; }
        

        [JsonProperty("Type")]
        public string Type { get; set; }
    }
}
