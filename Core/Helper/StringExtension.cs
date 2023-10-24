using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Core.Helper
{
    public static class StringExtension
    {
        public static bool IsStringALink(this string str)
        {
            string pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex rgx = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return rgx.IsMatch(str);
        }
    }

    public static class EnumExtension
    {
        public static string? GetDisplayName(this Enum enumValue)
        {
            var strValue = enumValue.ToString();
            var attr = enumValue.GetType()
                                .GetMember(strValue)
                                .First()
                                .GetCustomAttribute<DisplayAttribute>(true);
            return attr == null ? strValue : attr.Name;
        }
    }
}
