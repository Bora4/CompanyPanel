namespace Ana_Panel.Models.Domain
{
	public class Product
	{
		public long ProductId { get; set; }
		public long? Barcode { get; set; }
		public string Name { get; set; } = String.Empty;
		public long Stock { get; set; }
		public string? Color { get; set; }
		public DateTime? DateCreated { get; set; }
		public DateTime? DateUpdated { get; set; }
		public int? StationId { get; set; } = 1;
		public int? LastStationId { get; set; }
		public int? DestinationId { get; set; }
		public Station Station { get; set; }


	}
}
