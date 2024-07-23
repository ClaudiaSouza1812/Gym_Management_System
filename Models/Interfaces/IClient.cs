using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models.Interfaces
{
    public interface IClient : IPerson
    {
        #region Scalar Properties
        public int ClientID { get; set; }
        public EnumClientStatus Status { get; set; }
        #endregion

    }


}
