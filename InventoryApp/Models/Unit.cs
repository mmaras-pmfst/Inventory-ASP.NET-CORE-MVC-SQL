namespace Inventory.Models
{
    public class Unit
    {
        public int? UnitId { get; set; }
        public string UnitName { get; set; }
        public Unit(int? unitId, string unitName)
        {
            UnitId = unitId;
            UnitName = unitName;
        }
    }
}
