using P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models;

namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Interfaces.IRepositories
{
    // Define the class ClientRepository that implements the interface IClientRepository
    // This class will interact with the database
    public abstract class ClientRepository : IClientRepository
    {
        #region Fields

        protected readonly List<Client> _clients = new List<Client>();

        #endregion

        #region Methods and Functions

        public virtual List<Client> GetClient()
        {
            return _clients;
        }

        #endregion

    }
}
