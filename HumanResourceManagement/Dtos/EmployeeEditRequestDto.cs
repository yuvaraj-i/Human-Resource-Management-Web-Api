namespace HumanResourceManagement.Dtos
{
    public class EmployeeEditRequestDto : EmployeeDto
    {
        public bool WorkingStatus { get; set; } = true;
        public int Id { get; set; }
    }
}
