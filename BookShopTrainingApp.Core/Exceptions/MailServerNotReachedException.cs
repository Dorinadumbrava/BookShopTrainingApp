using System;

namespace BookShopTrainingApp.Core.Exceptions
{
    public class MailServerNotReachedException : Exception
    {
        public MailServerNotReachedException()
        {
        }

        public MailServerNotReachedException(string message)
            : base($"Mail not sent: {message}")
        {
        }
    }
}