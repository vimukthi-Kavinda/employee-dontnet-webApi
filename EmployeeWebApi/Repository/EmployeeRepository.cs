using EmployeeWebApi.Data;
using EmployeeWebApi.Interfaces;
using EmployeeWebApi.Models;

namespace EmployeeWebApi.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _dataContext;
        public EmployeeRepository(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }


        public ICollection<Employee> GetAllEmployees() {
           return  _dataContext.Employees.OrderBy(x => x.Id).ToList();
        }

        public ICollection<Employee> GetEmployeesByName(string name) {
            return _dataContext.Employees.Where(e=>name.Equals(e.EmpName))
                .ToList();
        }

        public Employee GetById(int id)
        {
            return _dataContext.Employees.SingleOrDefault(e=>id==e.Id);
        }

    }
}
