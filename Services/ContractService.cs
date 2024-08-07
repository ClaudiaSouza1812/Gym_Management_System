using Microsoft.EntityFrameworkCore;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.DAL;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IServices;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;

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

        public async Task<bool> CheckContractValidity(int clientId, DateTime startDate)
        {
            return await _context.Contract.AnyAsync(c => c.ClientId == clientId && c.EndDate > startDate);
        }

        public async Task<Contract> CreateContract(Contract contract)
        {
            _context.Contract.Add(contract);
            await _context.SaveChangesAsync();
            return contract;
        }
    }
}
