using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sacramentMeetingApp.Models
{
    public class Unit
    {
        public int UnitID { get; set; }
        [StringLength(60), Required, Display(Name = "Unit Name")]
        public string UnitName { get; set; } = default!;
        [Required, Display(Name = "Unit Number")]
        public UnitType UnitType { get; set; }
    }
}
public enum UnitType
{
    Unit,
    Branch,
    Ward
}