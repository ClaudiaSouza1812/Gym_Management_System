using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.Repositories
{
    // Define the class ClientRepository that implements the interface IClientRepository
    // This class will interact with the database
    public abstract class ClientRepository : IClientRepository
    {
        #region Fields

        private readonly List<Client> _clients = new List<Client>();

        #endregion

        #region Methods and Functions

        protected abstract Client GetClientByPayment();

        
        #endregion

    }
}
