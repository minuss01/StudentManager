using DATABASE.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WEB.Helpers;

namespace WEB.DTOs.Group
{
    public class GroupEditDto
    {
        public GroupEditDto()
        {
            Levels = EnumHelper.GetLevelEnum();
        }

        public int Id { get; set; }

        [DisplayName("Nazwa")]
        [Required(ErrorMessage = StaticHelper.REQUIRED_VALIDATION_TEXT)]
        public string Name { get; set; }

        [DisplayName("Poziom zaawansowania")]
        [Required(ErrorMessage = StaticHelper.REQUIRED_VALIDATION_TEXT)]
        public LevelEnum Level { get; set; }

        [DisplayName("Nauczyciel")]
        [Required(ErrorMessage = StaticHelper.REQUIRED_VALIDATION_TEXT)]
        public int TeacherId { get; set; }

        public List<SelectListItem> Teachers { get; set; }
        public List<SelectListItem> Levels { get; set; }
    }
}
