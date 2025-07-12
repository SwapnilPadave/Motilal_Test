using Api.Model;
using Api.RequestDtos;

namespace Api.Repos
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int id);
        string Add(AddEmployeeRequestDto employee);
        string Update(int id, UpdateEmployeeRequestDto employee);
        string Delete(int id);
    }
}
