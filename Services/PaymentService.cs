using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IServices;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.DAL;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Services
{
    public class PaymentService : IPaymentService
    {
        #region Fields
        private readonly CA_RS11_P2_2_ClaudiaSouza_DBContext _context;
        #endregion

        #region Constructor
        public PaymentService(CA_RS11_P2_2_ClaudiaSouza_DBContext context)
        {
            _context = context;

        }
        #endregion

        #region Methods and Functions
        public decimal ComputePayment(IPayment payment, IClient client)
        {
            if (client == null)
            {
                return 0;
            }

            return client.PaymentType switch
            {
                EnumPaymentType.Monthly => CalculateMonthlyPayment(payment),
                EnumPaymentType.MonthlyLoyalty => CalculateMonthlyLoyalPayment(payment),
                _ => CalculatePerSessionPayment(payment),
            };
        }

        public decimal CalculateMonthlyPayment(IPayment payment)
        {
            return payment.PaymentBaseValue * payment.PaymentBaseRate;
        }

        public decimal CalculateMonthlyLoyalPayment(IPayment payment)
        {
            decimal discount  = _context.Membership.Where(m => m.MembershipType == "MonthlyLoyalty").Select(m => m.DiscountPercentage).FirstOrDefault();

            decimal totalValue = payment.PaymentBaseValue * payment.PaymentBaseRate;
            decimal totalDiscount = discount / 100 * totalValue;
            return totalValue - totalDiscount;
        }

        public decimal CalculatePerSessionPayment(IPayment payment)
        {
            return payment.PaymentBaseValue * 3;
        }
        #endregion
    }
}
