namespace Ana_Panel.Models.EmployeeViewModels
{
    public class AddEmployeeViewModel
    {

        public string Name { get; set; } = string.Empty;
        public string? Email { get; set; }
        public long? Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Department { get; set; }
        public string? Title { get; set; }
    }
}
