using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IServices
{
    public interface IPaymentService
    {
        decimal CalculateMonthlyPayment(IPayment payment);
        decimal CalculateMonthlyLoyalPayment(IPayment payment);
        decimal CalculatePerSessionPayment(IPayment payment);
        decimal ComputePayment(IPayment payment, IClient client);
    }
}
