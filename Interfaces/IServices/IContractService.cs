namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IServices
{
    public interface IContractService
    {
        Task<bool> CheckExistingContract(int clientId);
    }
}
