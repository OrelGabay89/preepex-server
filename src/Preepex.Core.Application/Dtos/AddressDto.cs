using System.ComponentModel.DataAnnotations;

namespace Preepex.Core.Application.Dtos
{
    public class AddressDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Zipcode { get; set; }


        public int Id { get; set; }
        public string AppUserId { get; set; }
    }
}