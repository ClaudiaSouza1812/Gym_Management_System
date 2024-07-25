using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{
    public interface IModality
    {
        #region Scalar Properties

        public int ModalityID { get; }
        public EnumModalityName ModalityName { get; }
        public EnumModalityPackage ModalityPackage { get; }

        #endregion
    }
}
