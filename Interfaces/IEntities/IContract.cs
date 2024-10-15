// SOLID Principles applied in this interface:
//
// Single Responsibility Principle (SRP):
// - This interface has the single responsibility of defining the structure for Contract entities.
//
// Interface Segregation Principle (ISP):
// - The interface is focused and specific to Contract entities, not forcing unnecessary properties on implementing classes.
//
// Dependency Inversion Principle (DIP):
// - By defining an interface, we allow high-level modules to depend on this abstraction rather than concrete implementations.
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Enums;
using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;
using System;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IEntities
{
    // Interface defining the contract for Contract entities
    public interface IContract
    {
        // Scalar Properties: Properties that hold a single value of a specific type
        // They typically represent the basic attributes of the entity and often correspond directly to database columns.
        #region Scalar Properties

        int ContractId { get; }
        int ClientId { get; }
        int MembershipId { get; }
        DateTime StartDate { get; }
        DateTime EndDate { get; }

        #endregion

    }
}
