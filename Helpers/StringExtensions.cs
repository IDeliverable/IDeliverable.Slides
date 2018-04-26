using System;
using System.Linq;
using System.Text;

namespace IDeliverable.Slides.Helpers
{
    public static class StringExtensions
    {
        public static string ToPascalCase(this string text)
        {
            if (String.IsNullOrWhiteSpace(text))
                return "";

            var sb = new StringBuilder(text.Length);

            for (int i = 0; i < text.Length; i++)
            {
                if (i == 0 && Char.IsUpper(text[i]))
                {
                    sb.Append(Char.ToLower(text[i]));
                    continue;
                }

                if (!Char.IsWhiteSpace(text[i]))
                    sb.Append(text[i]);
            }

            return sb.ToString();
        }
    }
}