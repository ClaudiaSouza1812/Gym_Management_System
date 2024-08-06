using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IMethods;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IServices;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.DAL;
using Microsoft.EntityFrameworkCore;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Services
{
    public class ClientService : IClientService
    {
        private readonly CA_RS11_P2_2_ClaudiaSouza_DBContext _context;
        /*
        private readonly IClientByMonthlyPayment _clientByMonthlyPayment;
        private readonly IClientByPerSessionPayment _clientByPerSessionPayment;
        */

        public ClientService(CA_RS11_P2_2_ClaudiaSouza_DBContext context)
        {
            _context = context;
            
        }

        public async Task<bool> CheckExistentNif(string nif)
        {
            return await _context.Client.AnyAsync(c => c.NIF == nif);
        }
    }
}
