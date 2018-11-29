using RookieNationMobile.Configurations;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RookieNationMobile.Models.User
{
    public class User : BaseModel
    {

        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("accountId")]
        public int? AccountId { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("confirmPassword")]
        public string ConfirmPassword { get; set; }
        
        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("bio")]
        public string Bio { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("profileType")]
        public string ProfileType { get; set; }
        
    }
}
