using System.Text.RegularExpressions;

namespace LibrarayManagementSystem.Application.Features.Books.Commands
{
    internal static class IsbnValidator
    {
        private static bool IsISBNModernFormat(string isbn)
        {
            // Check if the ISBN contains hyphens
            return isbn.Replace("-", "").StartsWith("978") || isbn.Replace("-", "").StartsWith("979");
        }

        internal static bool IsValidIsbnFormat(string isbn)
        {
            isbn = isbn.Trim();
            bool isHyphenated = isbn.Contains("-");

            if (IsISBNModernFormat(isbn))
            {
                if (isHyphenated)
                    return Regex.IsMatch(isbn, @"^97[89]-\d{1,5}-\d{1,7}-\d{1,7}-\d{1}$");
                else
                    return Regex.IsMatch(isbn, @"^97[89]\d{10}$");
            }
            else
            {
                if (isHyphenated)
                    return Regex.IsMatch(isbn, @"^\d{1,5}-\d{1,7}-\d{1,7}-[\dX]$");
                else
                    return Regex.IsMatch(isbn, @"^\d{9}[\dX]$");
            }
        }
    }
}
