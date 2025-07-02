using EmployeeWebApi.Models;

namespace EmployeeWebApi.Interfaces
{
    public interface IEmployeeRepository
    {
        //each methods is like a queryMethods in jpa - but here need to impl behaviour accessing db context

        ICollection<Employee> GetAllEmployees();

        ICollection<Employee>GetEmployeesByName(string name);

        Employee GetById(int id);
    }
}
