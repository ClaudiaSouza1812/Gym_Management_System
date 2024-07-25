using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{
    public interface IMembership
    {
        #region Scalar Properties
        int MembershipID { get; }
        int ClientID { get; }
        bool IsLoyal { get; }
        decimal Discount { get; }
        DateTime StartDate { get; }
        DateTime EndDate { get; }
        #endregion


    }
}
