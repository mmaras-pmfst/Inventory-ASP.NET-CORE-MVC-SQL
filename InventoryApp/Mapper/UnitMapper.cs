using Inventory.Models;

namespace Inventory.Mapper
{
    public class UnitMapper
    {
        public static Unit FromDatabase(DbModels.Unit unit)
        {
            return new Unit(
                unit.UnitId,
                unit.UnitName
                );
        }
        public static DbModels.Unit ToDatabase(Unit unit)
        {
            return new DbModels.Unit
            {
                UnitId = unit.UnitId.HasValue ? unit.UnitId.Value : 0,
                UnitName = unit.UnitName


            };
        }
    }
}
