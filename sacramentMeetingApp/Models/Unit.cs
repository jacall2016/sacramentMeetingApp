namespace sacramentMeetingApp.Models
{
    public class Unit
    {
        public int UnitID { get; set; }
        public string UnitName { get; set; } = default!;
        public UnitType UnitType { get; set; }
    }
}
public enum UnitType
{
    Unit,
    Branch,
    Ward
}