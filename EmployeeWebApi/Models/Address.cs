using System.ComponentModel.DataAnnotations;

namespace EmployeeWebApi.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string  Email { get; set; }
        public string HomeAddress { get; set; }

        public Employee Employee { get; set; }  
    }
}
