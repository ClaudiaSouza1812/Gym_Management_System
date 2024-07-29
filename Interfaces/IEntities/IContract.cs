namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{
    public interface IContract
    {
        // SOLID Principle: Interface Segregation
        // Reason: Provides a focused interface with only the necessary properties
        int ContractId { get; }
        int ClientId { get; }
        int MembershipId { get; }
        DateTime ContractDate { get; }
    }
}
