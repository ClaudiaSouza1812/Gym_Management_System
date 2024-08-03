using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{
    public interface IMembership
    {
        #region Scalar Properties

        int MembershipId { get; }
        decimal Discount { get; }
        DateTime StartDate { get; }

        #endregion


    }
}
