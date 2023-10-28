using System.ComponentModel.DataAnnotations;

namespace PIMToolAPI.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }

        public int GroupLeaderId { get; set; }


        [Timestamp]
        public byte[] Version { get; set; }

        public Employee GroupLeader { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
