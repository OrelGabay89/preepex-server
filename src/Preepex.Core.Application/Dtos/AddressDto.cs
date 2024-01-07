using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Preepex.Core.Application.Dtos
{
    public class AddressDto
    {
        [Required]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [Required]
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [Required]
        [JsonProperty("street")]
        public string Street { get; set; }

        [Required]
        [JsonProperty("city")]
        public string City { get; set; }

        [Required]
        [JsonProperty("state")]
        public string State { get; set; }

        [Required]
        [JsonProperty("zipcode")]
        public string Zipcode { get; set; }

        [Required]
        [JsonProperty("phoneNumber")]
        public string Phone { get; set; }
        
        public int Id { get; set; }
        public string AppUserId { get; set; }
    }
}