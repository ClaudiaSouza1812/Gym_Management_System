using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{
    public interface IPayment
    {
        #region Scalar Properties

        public int PaymentID { get; set; }
        public EnumPaymentType PaymentType { get; set; }
        public decimal PaymentValue { get; set; }
        public DateTime PaymentDate { get; set; }

        #endregion
    }
}
