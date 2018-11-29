using Newtonsoft.Json;
using RookieNationMobile.Helpers;

namespace RookieNationMobile.Models.User
{
    public class RookieNationUser : User
    {

        private Relation _relation;

        [JsonProperty("CoreUserId")]
        public int CoreId { get; set; }

        [JsonProperty("Profile")]
        public Profile Profile { get; set; }

        [JsonProperty("Ranking")]
        public Ranking Ranking { get; set; }

        public Relation Relation {
            get
            {
                return _relation;
            }
            set
            {
                if (_relation != value)
                {
                    _relation = value;
                    OnPropertyChanged(nameof(Relation));
                }
            }
        }
    }
}
