namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models
{
    public class CreateClientViewModel
    {
        public Client Client { get; set; } = new Client();
        public List<Membership> MembershipOptions { get; set; } = new List<Membership>();
        public List<Contract> Contract { get; set; } = new List<Contract>();
        public List<Payment> Payment { get; set; } = new List<Payment>();
        public List<Modality> ModalityOptions { get; set; } = new List<Modality>();

    }
}
