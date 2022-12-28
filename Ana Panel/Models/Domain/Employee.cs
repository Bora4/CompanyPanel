namespace Ana_Panel.Models.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string? Email { get; set; }
        public long? Salary { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        public string? Department { get; set; }
        public string? Title { get; set; }

    }
}
