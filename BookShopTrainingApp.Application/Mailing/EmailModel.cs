using System.Text.RegularExpressions;

namespace BookShopTrainingApp.Application.Mailing
{
    public class EmailModel
    {
        private const string emailMatch = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
        public EmailModel(string email, string body)
        {
            if (Regex.IsMatch(email, emailMatch))
            {
                Email = email;
            }
            else
            {
                Email = string.Empty;
            }
            Body = body;
        }
        
        public string Email { get; }
        public string Body { get; }
    }
}