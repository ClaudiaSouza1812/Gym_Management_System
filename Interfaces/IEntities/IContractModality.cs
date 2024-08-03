using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{
    public interface IContractModality
    {
        #region Scalar Properties

        int ContractId { get; }
        int ModalityId { get; }

        #endregion

        
    }

}
