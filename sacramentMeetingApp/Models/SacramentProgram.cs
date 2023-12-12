using System.ComponentModel.DataAnnotations;

namespace sacramentMeetingApp.Models
{
    public class SacramentProgram
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string? UnitName { get; set; }
        public string? PresidingLeader { get; set; }
        public string? ConductingLeader { get; set; }
        public string? OpeningSong { get; set; }
        public string? SacramentHymn { get; set; }
        public string? ClosingSong { get; set; }
        public string? SpecialNumber { get; set; }
        public string? OpeningPrayer { get; set; }
        public string? ClosingPrayer { get; set; }
        public List<Talk>? Talk { get; set; }
    }
}
