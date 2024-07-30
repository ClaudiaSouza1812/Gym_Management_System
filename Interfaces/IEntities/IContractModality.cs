﻿namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{
    public interface IContractModality
    {
        #region Scalar Properties

        int ContractModalityId { get; }
        int ContractId { get; }
        int ModalityId { get; }

        #endregion

        #region Navigation Properties

        IContract Contract { get; }
        IModality Modality { get; }

        #endregion
    }

}
