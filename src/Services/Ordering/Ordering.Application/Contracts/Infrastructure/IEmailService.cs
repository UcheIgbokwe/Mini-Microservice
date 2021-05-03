using System.Threading.Tasks;
using src.Services.Ordering.Ordering.Application.Models;

namespace src.Services.Ordering.Ordering.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}