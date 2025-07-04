namespace API_EmployeesManagement.DTO
{
    public class CreateEmployeeDTO
    {
        public string Name { get; set; }
        public DateTime? DOB { get; set; } = DateTime.Now;
        public string? Image { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
    }
}
