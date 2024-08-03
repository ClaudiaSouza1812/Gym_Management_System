using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{
    public interface IPayment
    {
        #region Scalar Properties

        int PaymentId { get; }
        int ContractId { get; }
        decimal PaymentBaseValue { get; }
        decimal PaymentBaseRate { get; }
        DateTime PaymentDate { get; }

        #endregion

        
    }
}
