using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IMethods;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IRepositories;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IServices;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Services
{
    public class ClientService : IClientServices
    {
        /*
        private readonly IClientRepository _clientRepository;
        private readonly IClientByMonthlyPayment _clientByMonthlyPayment;
        private readonly IClientByPerSessionPayment _clientByPerSessionPayment;

        public ClientService(IClientRepository repository, IClientByMonthlyPayment monthlyPayment, IClientByPerSessionPayment perSessionPayment)
        { 
            _clientRepository = repository;
            _clientByMonthlyPayment = monthlyPayment;
            _clientByPerSessionPayment = perSessionPayment;

        }

        public List<Client> GetAllClients()
        {
            return _clientRepository.GetAllClients();
        }

        public List<Client> GetClientByMonthlyPayment()
        {
            return _clientByMonthlyPayment.GetClientByMonthlyPayment();
        }

        public List<Client> GetClientByPerSessionPayment()
        {
            return _clientByPerSessionPayment.GetClientByPerSessionPayment();
        }
        */
    }
}
