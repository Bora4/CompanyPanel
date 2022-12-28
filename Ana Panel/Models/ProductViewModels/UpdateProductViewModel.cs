using Ana_Panel.Models.Domain;

namespace Ana_Panel.Models.ProductViewModels
{
    public class UpdateProductViewModel
    {
        public long ProductId { get; set; }
        public long? Barcode { get; set; }
        public string Name { get; set; } = string.Empty;
        public long Stock { get; set; }
        public string? Color { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; } = DateTime.Now;
        public int? StationId { get; set; }
        public int? DestinationId { get; set; }
        public string StationName { get; set; } = "";
    }
}
