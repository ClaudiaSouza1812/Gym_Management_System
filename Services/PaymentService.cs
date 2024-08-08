using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IServices;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.DAL;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Services
{
    // SolId Principle: Open Closed
    // Reason: This class is open for extension but closed for modification
    public class PaymentService : IPaymentService
    {

        #region Fields
        // SolId Principle: Dependency Inversion
        // Reason: The constructor is receiving an interface and not a concrete class as a parameter
        private readonly CA_RS11_P2_2_ClaudiaSouza_DBContext _context;

        #endregion

        #region Constructor

        public PaymentService(CA_RS11_P2_2_ClaudiaSouza_DBContext context)
        {
            _context = context;

        }

        #endregion

        #region Methods and Functions

        public decimal CalculateMonthlyPayment(IPayment payment)
        {
            return payment.PaymentBaseValue * payment.PaymentBaseRate;
        }

        public decimal CalculateMonthlyLoyalPayment(IPayment payment, IMembership membership)
        {
            decimal totalValue = payment.PaymentBaseValue * payment.PaymentBaseRate;
            decimal totalDiscount = membership.DiscountPercentage / 100 * totalValue;
            return totalValue - totalDiscount;
        }

        public decimal CalculatePerSessionPayment(IPayment payment, IModality modality)
        {
            switch (modality.ModalityName)
            {
                case EnumModalityName.Swimming:
                case EnumModalityName.Yoga:
                case EnumModalityName.Pilates:
                case EnumModalityName.Crossfit:
                    return payment.PaymentBaseRate * 3;
                case EnumModalityName.Zumba:
                case EnumModalityName.MartialArts:
                case EnumModalityName.Dance:
                    return payment.PaymentBaseRate * 2;
                default:
                    return payment.PaymentBaseValue;
            }
        }

        #endregion


    }
}
