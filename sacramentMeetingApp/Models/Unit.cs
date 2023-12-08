namespace sacramentMeetingApp.Models
{
    public class Unit
    {
        String UnitName;
        Int UnitID;
        UnitType UnitType;
        Member[] Leadership;
    }

    public enum UnitType
    {
        Unit,
        Branch,
        Ward
    }
}
