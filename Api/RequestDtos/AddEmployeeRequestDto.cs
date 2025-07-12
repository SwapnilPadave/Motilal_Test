using System.ComponentModel.DataAnnotations;

namespace Api.RequestDtos
{
    public class AddEmployeeRequestDto
    {
        [Required(ErrorMessage = "Full Name is required.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Department is required.")]
        public string Department { get; set; } = string.Empty;
        public decimal? Salary { get; set; }
    }

    public class UpdateEmployeeRequestDto
    {
        [Required(ErrorMessage = "Full Name is required.")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Department is required.")]
        public string Department { get; set; } = string.Empty;
        public decimal? Salary { get; set; }
    }
}
