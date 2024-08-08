using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IMethods;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.DAL;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Methods
{
    public class CalculateMonthlyLoyalPayment : PaymentCalculator
    {
        private readonly IMembership _membership;
        #region Constructor

        public CalculateMonthlyLoyalPayment(IPayment payment, IMembership membership) : base(payment) 
        {
            _membership = membership;
        }

        #endregion

        protected override decimal CalculatePaymentApplication()
        {
            decimal totalValue = _payment.PaymentBaseValue * _payment.PaymentBaseRate;
            decimal totalDiscount = _membership.DiscountPercentage / 100 * totalValue;
            return totalValue - totalDiscount;
        }
        
    }
}
