using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Models
{
    public class Interaction : BaseModel
    {
        [JsonProperty("Id")]
        public int Id { get; set; }

        [JsonProperty("IdUser")]
        public int IdUser { get; set; }

        [JsonProperty("IdFeed")]
        public int IdFeed { get; set; }

        [JsonProperty("Type")]
        public int? Type { get; set; }
    }
}
