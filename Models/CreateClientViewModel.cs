namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models
{
    public class CreateClientViewModel
    {
        public Client Client { get; set; } 
        public Membership Membership { get; set; } 
        public Contract Contract { get; set; } 
        public Payment Payment { get; set; } 
        public Modality Modality { get; set; } 

    }
}
