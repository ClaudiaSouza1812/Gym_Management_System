using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{
    public interface IMembership
    {
        #region Scalar Properties

        int MembershipId { get; }
        bool IsLoyal { get; }
        decimal Discount { get; }
        DateTime StartDate { get; }
        DateTime EndDate { get; }

        #endregion

        #region Navigation Properties

        ICollection<IContract> Contracts { get; }

        #endregion

    }
}
