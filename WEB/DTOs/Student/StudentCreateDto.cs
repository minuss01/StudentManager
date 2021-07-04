using DATABASE.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WEB.Helpers;

namespace WEB.DTOs.Student
{
    public class StudentCreateDto
    {
        public StudentCreateDto()
        {
            Levels = EnumHelper.GetLevelEnum();
        }

        [DisplayName("Imię")]
        [Required(ErrorMessage = StaticHelper.REQUIRED_VALIDATION_TEXT)]
        public string FirstName { get; set; }

        [DisplayName("Nazwisko")]
        [Required(ErrorMessage = StaticHelper.REQUIRED_VALIDATION_TEXT)]
        public string LastName { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = StaticHelper.REQUIRED_VALIDATION_TEXT)]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Nr telefonu")]
        [Phone]
        [Required(ErrorMessage = StaticHelper.REQUIRED_VALIDATION_TEXT)]
        public string PhoneNumber { get; set; }

        [DisplayName("Miasto")]
        [Required(ErrorMessage = StaticHelper.REQUIRED_VALIDATION_TEXT)]
        public string City { get; set; }

        [DisplayName("Kod pocztowy")]
        [Required(ErrorMessage = StaticHelper.REQUIRED_VALIDATION_TEXT)]
        public string PostCode { get; set; }

        [DisplayName("Ulica")]
        [Required(ErrorMessage = StaticHelper.REQUIRED_VALIDATION_TEXT)]
        public string Street { get; set; }

        [DisplayName("Poziom zaawansowania")]
        [Required(ErrorMessage = StaticHelper.REQUIRED_VALIDATION_TEXT)]
        public LevelEnum Level { get; set; }

        [DisplayName("Grupa")]
        public int GroupId { get; set; }

        public List<SelectListItem> Levels { get; set; }
        public List<SelectListItem> Groups { get; set; }
    }
}
