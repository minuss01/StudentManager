using DATABASE.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace WEB.Helpers
{
    public class EnumHelper
    {
        public static List<SelectListItem> GetLevelEnum()
        {
            var enumList = new List<SelectListItem>();
            foreach (LevelEnum level in (LevelEnum[])Enum.GetValues(typeof(LevelEnum)))
            {
                var item = new SelectListItem(level.GetName(), level.GetHashCode().ToString());
                enumList.Add(item);
            }

            return enumList;
        }
    }
}
