namespace P02_2_ASP.NET_Core_MVC_M01_ClaudiaSouza.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
