using System.ComponentModel.DataAnnotations;

namespace Utilities
{
    /// <summary>
    /// thanks MSDN: https://msdn.microsoft.com/en-us/library/01escwtf(v=vs.85).aspx
    /// </summary>
    public class EmailValidator
    {
        private static EmailAddressAttribute emailChecker = new EmailAddressAttribute();
        private static string[] partsSplitter = new string[] { "@" };

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            //EmailAddressAttribute allows some cases which are illegal
            //1. consecutive dots
            //2. '´' character in domain part
            return emailChecker.IsValid(email) && !email.Contains("..") && AllDomainCharactersLegal(email);
        }

        private static bool AllDomainCharactersLegal(string email)
        {
            string[] parts = email.Split(partsSplitter, System.StringSplitOptions.RemoveEmptyEntries);
            return parts.Length == 2 && !parts[1].Contains("´");
        }
    }    
}