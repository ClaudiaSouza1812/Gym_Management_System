using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IServices
{
    public interface IPaymentService
    {
        decimal CalculateMonthlyPayment(IPayment payment);
        decimal CalculateMonthlyLoyalPayment(IPayment payment, IMembership membership);
        decimal CalculatePerSessionPayment(IPayment payment, IModality modality);
    }
}
