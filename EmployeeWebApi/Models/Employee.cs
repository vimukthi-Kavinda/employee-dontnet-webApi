using System.ComponentModel.DataAnnotations;

namespace EmployeeWebApi.Models
{

    //model is for db tbles
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string EmpName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Address Adderss{ get; set; }
        public Manager Manager { get; set; }
        public Project Project { get; set; }

        public int ManagerId{ get; set; }
        public int ProjectId { get; set; }

        public int AdderssId { get; set; }




    }
}
