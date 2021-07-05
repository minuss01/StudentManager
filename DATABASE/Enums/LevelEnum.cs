namespace DATABASE.Enums
{
    public enum LevelEnum
    {
        None = 0,
        Beginner = 1,
        Intermidiate = 2,
        Advanced = 3,
        Native = 4
    }

    public static class LevelEnumEntensions
    {
        public static string GetName(this LevelEnum level)
        {
            switch (level)
            {
                case LevelEnum.Beginner: return "początkujący";
                case LevelEnum.Intermidiate: return "średniozaawansowany";
                case LevelEnum.Advanced: return "zaawansowany";
                case LevelEnum.Native: return "język ojczysty";
                default: return "nie określono";
            }
        }
    }
}
