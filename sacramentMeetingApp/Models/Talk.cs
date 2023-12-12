using System.ComponentModel.DataAnnotations.Schema;

namespace sacramentMeetingApp.Models
{
    public class Talk
    {
        public int Id { get; set; }
        public string? SpeakerName { get; set; }
        public string? Topic { get; set; }
        public int SacramentProgramId { get; set; }

        public SacramentProgram? SacramentProgram { get; set; }

        [NotMapped] 
        public bool IsDeleted { get; set; }
    }

}
