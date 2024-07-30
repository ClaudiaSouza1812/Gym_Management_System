using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IMethods;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Methods
{
    // Solid Principle: Open Closed
    // Reason: This class is open for extension but closed for modification
    public abstract class PaymentCalculator : IPaymentCalculator
    {

        #region Fields
        // Solid Principle: Dependency Inversion
        // Reason: The constructor is receiving an interface and not a concrete class as a parameter

        protected readonly IPayment _payment;

        #endregion

        #region Constructor

        protected PaymentCalculator(IPayment payment)
        {
            _payment = payment;
        }

        #endregion

        #region Methods and Functions
        // Solid Principle: Liskov Substitution

        public decimal CalculatePayment()
        { 
            return CalculatePaymentApplication();
        }

        protected abstract decimal CalculatePaymentApplication();

        #endregion


    }
}
