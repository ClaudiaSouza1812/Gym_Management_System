using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IMethods;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Methods
{
    public class ClientByMonthlyPayment : IClientByMonthlyPayment
    {
        /*
        public List<Client> GetClientByMonthlyPayment()
        {
            
            
            return _clients
                .Where(c => c.Contracts.Any(c => 
                c.Payments.Any(p => 
                p.PaymentType == Enums.EnumPaymentType.Monthly || p.PaymentType == Enums.EnumPaymentType.MonthlyLoyalty))).ToList();
            

    }
        */
    }
}
