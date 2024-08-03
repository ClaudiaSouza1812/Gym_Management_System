namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IMethods
{
    // SolId Principle: Interface Segregation
    // Reason: This interface has only one method, which is to calculate the payment
    public interface IPaymentCalculator
    {
        decimal CalculatePayment();
    }
}
