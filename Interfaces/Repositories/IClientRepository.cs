using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.Repositories
{
    public interface IClientRepository
    {
        public Client GetClientByPayment();
    }
}
