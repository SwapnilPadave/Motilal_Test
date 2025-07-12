using Api.Model;
using Api.RequestDtos;

namespace Api.Repos
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employee = new();
        private int _nextId = 1;
        public IEnumerable<Employee> GetAll() => _employee;

        public Employee GetById(int id) => _employee.FirstOrDefault(p => p.EmployeeId == id);

        public string Add(AddEmployeeRequestDto employee)
        {
            try
            {
                if (employee.Salary == null || employee.Salary <= 0)
                {
                    return "Salary must be greater than zero.";
                }

                var emp = new Employee();
                emp.EmployeeId = _nextId++;
                emp.FullName = employee.FullName;
                emp.Department = employee.Department;
                emp.Salary = employee.Salary;

                _employee.Add(emp);
                return "Success.";
            }
            catch (Exception ex)
            {
                return $"Error adding employee: {ex.Message}";
            }

        }

        public string Update(int id, UpdateEmployeeRequestDto employee)
        {
            try
            {
                if (employee.Salary == null || employee.Salary <= 0)
                {
                    return "Salary must be greater than zero.";
                }
                var existing = GetById(id);
                existing.FullName = employee.FullName;
                existing.Department = employee.Department;
                existing.Salary = employee.Salary;

                return "Success.";
            }
            catch (Exception ex)
            {
                return $"Error while updating employee: {ex.Message}";
            }
        }

        public string Delete(int id)
        {
            try
            {
                var Employee = GetById(id);
                _employee.Remove(Employee);
                return "Success.";
            }
            catch (Exception ex)
            {
                return $"Error while deleting employee: {ex.Message}";
            }
        }
    }
}
