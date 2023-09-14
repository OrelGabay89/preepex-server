using Microsoft.AspNetCore.Components;
using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Preepex.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static string ToSnakeCase(this string input)
        {
            if (string.IsNullOrEmpty(input)) { return input; }

            var startUnderscores = Regex.Match(input, @"^_+");
            return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }

        public static string Excerpt(this string str, int limit)
        {
            if (str.Length > limit)
            {
                return $"{str.Substring(0, limit)}...";
            }
            else
            {
                return str;
            }
        }

        public static string UppercaseFirst(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return string.Empty;
            }
            char[] a = str.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        public static T ToEnum<T>(this string value) where T : struct
        {
            if (!Enum.TryParse<T>(value, out var enumeration))
            {
                return default;
            }
            return enumeration;
        }

        public static MarkupString ToMarkupString(this string value)
        {
            return new MarkupString(value);
        }

        public static string ToInitials(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return string.Empty;
            }

            var builder = new StringBuilder();

            var words = value.Split(" ");
            foreach (var word in words)
            {
                builder.Append(word.Substring(0, 1));
            }

            return builder.ToString().ToUpper();
        }

        public static string TrimStart(this string target, string trimString)
        {
            if (string.IsNullOrEmpty(trimString)) return target;

            string result = target;
            while (result.StartsWith(trimString))
            {
                result = result.Substring(trimString.Length);
            }

            return result;
        }
    }
}
