using Ana_Panel.Models.Domain;

namespace Ana_Panel.Models.ProductViewModels
{
    public class IndexProductViewModel
    {
        public long ProductId { get; set; }
        public long? Barcode { get; set; }
        public string Name { get; set; } = String.Empty;
        public long Stock { get; set; }
        public string? Color { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public string StationName { get; set; } = "";
    }
}
