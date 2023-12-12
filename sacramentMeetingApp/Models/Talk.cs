using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sacramentMeetingApp.Models
{
    public class Talk
    {
        public int Id { get; set; }
        [StringLength(60), Required, Display(Name = "Speaker Name")]
        public string? SpeakerName { get; set; }
        [StringLength(60)]
        public string? Topic { get; set; }
        public int SacramentProgramId { get; set; }

        public SacramentProgram? SacramentProgram { get; set; }

        [NotMapped] 
        public bool IsDeleted { get; set; }
    }

}
