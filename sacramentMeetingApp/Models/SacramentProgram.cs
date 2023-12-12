using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sacramentMeetingApp.Models
{
    public class SacramentProgram
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [StringLength(60), Required, Display(Name = "Unit")]
        public string? UnitName { get; set; }
        [StringLength(60), Required, Display(Name = "Presiding Leader")]
        public string? PresidingLeader { get; set; }
        [StringLength(60), Required, Display(Name = "Conducting Leader")]
        public string? ConductingLeader { get; set; }
        [StringLength(60), Required, Display(Name = "Opening Hymn")]
        public string? OpeningSong { get; set; }
        [StringLength(60), Required, Display(Name = "Sacrament Hymn")]
        public string? SacramentHymn { get; set; }
        [StringLength(60), Required, Display(Name = "Closing Hymn")]
        public string? ClosingSong { get; set; }
        [StringLength(60), Display(Name = "Special Number")]
        public string? SpecialNumber { get; set; }
        [StringLength(60), Required, Display(Name = "Opening Prayer")]
        public string? OpeningPrayer { get; set; }
        [StringLength(60), Required, Display(Name = "Closing Prayer")]
        public string? ClosingPrayer { get; set; }
        [Display(Name = "Speaker")]
        public List<Talk>? Talk { get; set; }
    }
}
