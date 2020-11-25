using System.Threading.Tasks;

namespace BookShopTrainingApp.Application.Mailing
{
    public interface IMailWrapper
    {
        Task Send(EmailModel email);
    }
}