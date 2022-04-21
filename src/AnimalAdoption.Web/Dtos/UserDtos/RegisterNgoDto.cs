using AnimalAdoption.Data.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace AnimalAdoption.Web.Dtos.UserDtos
{
    public class RegisterNgoDto
    {
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Street is required")]
        public string Street { get; set; }

        [Required(ErrorMessage = "City is required")]
        public City City { get; set; }

        [Required(ErrorMessage = "County is required")]
        public County County { get; set; }
        [Required(ErrorMessage = "NgoName is required")]
        public string NgoName { get; set; }
        [Required(ErrorMessage = "Code is required")]
        public string Code { get; set; }
        [Required(ErrorMessage = "FoundedDate is required")]
        public DateTime FoundedDate { get; set; }
        [Required(ErrorMessage = "Street is required")]
        public string NgoStreet { get; set; }

        [Required(ErrorMessage = "City is required")]
        public City NgoCity { get; set; }

        [Required(ErrorMessage = "County is required")]
        public County NgoCounty { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
