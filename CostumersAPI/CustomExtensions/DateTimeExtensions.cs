namespace CostumersAPI.CustomExtensions
{
    public static class DateTimeExtensions
    {
        public static int GetAge(this DateTime birthday)
        {
            var today = DateTime.Today;
            var age = DateTime.Today.Year - birthday.Year;
            if ((birthday.Month > DateTime.Now.Month) || (birthday.Month == DateTime.Now.Month && birthday.Day > DateTime.Now.Day))
                age--;
            return age;
        }
    }
}
