using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{
    // Interface definition for IClient, extending IPerson
    // This means IClient inherits all properties and methods from IPerson
    public interface IClient : IPerson
    {
        // Scalar properties: Hold a single value of a specific type
        #region Scalar Properties

        // EnumPaymentType, an enumeration of possible payment types
        // Get-only property, indicating it should be set at creation and not changed directly
        EnumPaymentType PaymentType { get; }
        
        // Get-only property, suggesting it's a set value, not directly modifiable
        bool Loyal { get; }

        #endregion
    }
}
