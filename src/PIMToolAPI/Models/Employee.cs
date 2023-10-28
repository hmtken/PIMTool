using System.ComponentModel.DataAnnotations;

namespace PIMToolAPI.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string Visa { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        public Group Group { get; set; }

        public ICollection<ProjectEmployee> ProjectEmployees { get; set; }
    }
}
