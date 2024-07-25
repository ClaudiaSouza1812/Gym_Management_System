using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{
    public interface IPayment
    {
        #region Scalar Properties

        int PaymentID { get; }
        EnumPaymentType PaymentType { get; }
        decimal PaymentValue { get; }
        DateTime PaymentDate { get; }

        #endregion
    }
}
