namespace sacramentMeetingApp.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Position { get; set; } // Bishop, Counselor, Clerk, etc.
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