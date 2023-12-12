using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sacramentMeetingApp.Models
{
    public class Member
    {
        public int Id { get; set; }
        [StringLength(60), Required, Display(Name = "Member Name")]
        public string? Name { get; set; }
        [StringLength(60), Required, Display(Name = "Member Calling")]
        public string? Position { get; set; } // Bishop, Counselor, Clerk, etc.
        [Required]
        public GenderType Gender { get; set; }
        public Member()
        {
            Position = "Member";
        }
    }
}

public enum GenderType
{
    Female,
    Male,
    Other
}