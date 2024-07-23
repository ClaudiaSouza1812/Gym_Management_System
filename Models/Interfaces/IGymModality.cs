using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models.Interfaces
{
    public interface IGymModality
    {
        #region Scalar Properties

        public int ModalityID { get; set; }
        public EnumModalityName ModalityName { get; set; }
        public EnumModalityPackage ModalityPackage { get; set; }
        

        #endregion
    }
}
