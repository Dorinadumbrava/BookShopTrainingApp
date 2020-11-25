using System.Threading.Tasks;

namespace BookShopTrainingApp.Application.Mailing
{
    public class MailWrapper : IMailWrapper
    {
        public async Task Send(EmailModel email)
        {
            await Task.Delay(1);
        }
    }
}