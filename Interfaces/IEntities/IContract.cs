using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{
    public interface IContract
    {
        #region Scalar Properties

        // SOLID Principle: Interface Segregation
        // Reason: Provides a focused interface with only the necessary properties
        int ContractId { get; }
        int ClientId { get; }
        int MembershipId { get; }
        DateTime ContractDate { get; }

        #endregion

        #region Navigation Properties

        Client Client { get; }
        Membership Membership { get; }
        ICollection<Payment> Payments { get; }
        ICollection<ContractModality> ContractModalities { get; }

        #endregion
    }
}
