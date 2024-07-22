using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models.Interfaces
{
    public interface IContract
    {
        #region Scalar Properties
        public int ContractID { get; set; }
        public string Terms { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        #endregion

    }
}
