using Microsoft.EntityFrameworkCore;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.DAL;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IServices;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Services
{
    public class ContractService : IContractService
    {

        private readonly CA_RS11_P2_2_ClaudiaSouza_DBContext _context;

        public ContractService(CA_RS11_P2_2_ClaudiaSouza_DBContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckExistingContract(int clientId)
        {
            return await _context.Contract.AnyAsync(c => c.ClientId == clientId);
        }
    }
}
