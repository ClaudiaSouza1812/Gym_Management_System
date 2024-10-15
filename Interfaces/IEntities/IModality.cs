/*
Areas that adhere to SOLID:
SRP: The interface has a single responsibility: defining the structure for Modality entities.
ISP: The interface is small and focused, not forcing implementing classes to provide methods they don't need.
*/
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{
    public interface IModality
    {
        #region Scalar Properties

        int ModalityId { get; }
        string ModalityName { get; }
        EnumModalityPackage ModalityPackage { get; }

        #endregion
    }
}
