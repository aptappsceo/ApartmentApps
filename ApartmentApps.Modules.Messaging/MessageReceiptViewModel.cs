namespace ApartmentApps.Api.ViewModels
{
    public class MessageReceiptViewModel
    {
        public bool Opened { get; set; }
        public string UserEmail { get; set; }
        public string BuildingNumber { get; set; }
        public string UnitNumber { get; set; }
        public bool Error { get; set; }
        public string ErrorMessage { get; set; }
        public int Id { get; set; }
    }
}