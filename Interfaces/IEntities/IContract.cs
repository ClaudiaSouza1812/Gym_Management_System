using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{
    public interface IContract
    {
        #region Scalar Properties

        int ContractId { get; }
        int ClientId { get; }
        int MembershipId { get; }
        DateTime StartDate { get; }
        DateTime EndDate { get; }

        #endregion

    }
}
