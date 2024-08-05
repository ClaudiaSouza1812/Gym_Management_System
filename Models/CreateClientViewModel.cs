namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models
{
    public class CreateClientViewModel
    {
        public Client Client { get; set; } = new Client();
        public Membership Membership { get; set; } = new Membership();
        public Contract Contract { get; set; } = new Contract();
        public Payment Payment { get; set; } = new Payment();
        public Modality Modality { get; set; } = new Modality();

    }
}
