namespace Ana_Panel.Models.Domain
{
    public class Station
    {
        public int StationId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; } = "";
        public string City { get; set; } = "";
        public string? Address { get; set; }

        public ICollection<Product>? Products { get; set; }
    }
}
