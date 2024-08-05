namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models
{
    public class CreateClientViewModel
    {
        public Client Client { get; set; }
        public Membership Membership { get; set; }
        public DateTime ContractDate { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaymentBaseValue { get; set; }
        public decimal PaymentBaseRate { get; set; }
        public Modality Modality { get; set; }

    }
}
