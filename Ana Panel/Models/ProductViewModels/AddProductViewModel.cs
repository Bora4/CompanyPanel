using Ana_Panel.Models.Domain;

namespace Ana_Panel.Models.ProductViewModels
{
    public class AddProductViewModel
    {
        public long? Barcode { get; set; }
        public string Name { get; set; } = string.Empty;
        public long Stock { get; set; }
        public string? Color { get; set; }
        public int? StationId { get; set; }
    }
}
