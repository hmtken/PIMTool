using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PIMTool.Database
{
    public class Project
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ProjectNumber { get; set; }
        public string? Name { get; set; }
        public string? Customer { get; set; }
        public string? Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }


        public int Version { get; set; }

        public int GroupId { get; set; }

        public Group? Group { get; set; }

        public ICollection<ProjectEmployee>? ProjectEmployees { get; set; }


    }
}
