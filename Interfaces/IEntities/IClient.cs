using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{
    public interface IClient : IPerson
    {
        #region Scalar Properties

        EnumClientStatus Status { get; }

        #endregion

        ICollection<IContract> Contracts { get; }

    }


}
