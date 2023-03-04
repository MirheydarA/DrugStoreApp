using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Extension
{
    public static class AppExtension
    {
        public static bool IsEmail(this string text)
        {
            return Regex.IsMatch(text, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }

        public static bool IsPhoneNumber(this string text1) 
        {
            return Regex.IsMatch(text1, ("^\\+?[1-9][0-9]{7,12}$") ,RegexOptions.IgnoreCase);
        }
    }
}
