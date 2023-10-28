using System.ComponentModel.DataAnnotations;

namespace PIMToolAPI.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }


        public int ProjectNumber { get; set; }

        public string Name { get; set; }

        public string Customer { get; set; }

        public string Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Timestamp]
        public byte[] Version { get; set; }

        public int GroupId { get; set; }


        public Group Group { get; set; }

        public ICollection<ProjectEmployee> ProjectEmployees { get; set; }
    }
}
