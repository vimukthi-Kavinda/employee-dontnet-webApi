using System.ComponentModel.DataAnnotations;

namespace EmployeeWebApi.Models
{
    public class Manager
    {
        [Key]
        public int Id { get; set; }
        public string ManagerName { get; set; }
        public ICollection<Employee> Employees { get; set; }
        public ICollection<ProjectManager> ProjectManagers { get; set; } //m-n creates seperate tables
        //public List<Project> Projects { get; set; } -> now this will work -- above is for older versions -- not wrong though


    }
}
