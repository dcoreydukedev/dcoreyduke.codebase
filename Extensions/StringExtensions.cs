/*************************************************************************
 * Author: DCoreyDuke
 * Description: Contains String Extensions
 * Version: 1.0.0.0
 * Contents:
 *     Titleize(this string text)
 *     ToSentenceCase(this string str)
 ************************************************************************/

using System.Globalization;
using System.Text.RegularExpressions;

namespace DCoreyDuke.CodeBase.Extensions
{
    public static class StringExtensions
    {
        public static string ToTitleCase(this string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str).ToSentenceCase();
        }

        public static string ToSentenceCase(this string str)
        {
            return Regex.Replace(str, "[a-z][A-Z]", m => m.Value[0] + " " + char.ToLower(m.Value[1]));
        }

        public static string? NullIfEmpty(this string str)
        {
            return string.IsNullOrEmpty(str) ? null : str;
        }
        public static string? NullIfWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str) ? null : str;
        }
    }
}