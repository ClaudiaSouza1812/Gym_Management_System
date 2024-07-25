using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{
    public interface IMembership
    {
        #region Scalar Properties
        public int MembershipID { get; }
        public int ClientID { get; }
        public bool IsLoyal { get; }
        public decimal Discount { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        #endregion


    }
}
