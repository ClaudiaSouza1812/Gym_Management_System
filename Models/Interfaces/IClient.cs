using System.Diagnostics.Contracts;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models.Interfaces
{
    public interface IClient : IPerson
    {
        #region Properties
        public int ClientID { get; set; }
        public string Status { get; set; }
        #endregion




    }
}
