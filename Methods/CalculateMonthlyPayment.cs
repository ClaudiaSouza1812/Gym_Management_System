using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Methods
{
    public class CalculateMonthlyPayment : PaymentCalculator
    {
        #region Constructor

        public CalculateMonthlyPayment(Payment payment) : base(payment) { }

        #endregion


        protected override decimal CalculatePayment()
        {
            _payment.PaymentBaseValue = 4.00M;
            _payment.PaymentBaseRate = 10.00M;
            return _payment.PaymentTotalValue = _payment.PaymentBaseValue * _payment.PaymentBaseRate;
        }
    }
}
