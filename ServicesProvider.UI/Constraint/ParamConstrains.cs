using System.Text.RegularExpressions;

namespace ServicesProvider.UI.Constraint
{
    public static class ParamConstrains
    {
       
        public static bool IsValidEmail(string email)
        {
            string emailPattern = @"^[\w-]+(\.[\w-]+)*@([a-z0-9-]+(\.[a-z0-9-]+)*\.[a-z]{2,})$";
            return Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase);
        }
    }
}
