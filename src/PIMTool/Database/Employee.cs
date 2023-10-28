using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PIMTool.Database
{
    public class Employee
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Visa { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public int Version { get; set; }

        public ICollection<ProjectEmployee>? ProjectEmployees { get; set; }

        public Group Group { get; set; }


    }
}
