using System.ComponentModel.DataAnnotations;

namespace EmployeeWebApi.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ProjectName { get; set; }
        public ICollection<Employee> Employees { get; set; }

        public ICollection<ProjectManager> ProjectManagers { get; set; }
        //EF Core Before 5.0: Use a Join Entity

        //now we dont need that
        //public ICollection<Manager> Managers { get; set; } //-> this will work
    }
}
