using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{
    public interface IModality
    {
        #region Scalar Properties

        int ModalityId { get; }
        EnumModalityName ModalityName { get; }
        EnumModalityPackage ModalityPackage { get; }

        #endregion

       
    }
}
