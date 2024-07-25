using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{
    public interface IModality
    {
        #region Scalar Properties

        int ModalityID { get; }
        EnumModalityName ModalityName { get; }
        EnumModalityPackage ModalityPackage { get; }

        #endregion
    }
}
