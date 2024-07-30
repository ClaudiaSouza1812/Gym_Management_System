using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{
    public interface IClient : IPerson
    {
        #region Scalar Properties

        EnumClientStatus Status { get; }

        #endregion

        #region Navigation Properties

        ICollection<Contract> Contracts { get; }

        #endregion


    }


}
