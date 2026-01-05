using invetario_api.Modules.unit.entity;
using System.ComponentModel.DataAnnotations;

namespace invetario_api.Modules.unit.response
{
    public class UnitSingleResponse
    {
        public int unitId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool status { get; set; }

        public static UnitSingleResponse fromEntity(Unit unit)
        {
            return new UnitSingleResponse
            {
                unitId = unit.unitId,
                name = unit.name,
                description = unit.description,
                status = unit.status
            };
        }

        public static List<UnitSingleResponse> fromEntityList(List<Unit> units)
        {
            var responseList = new List<UnitSingleResponse>();

            foreach (var unit in units)
            {
                responseList.Add(fromEntity(unit));
            }

            return responseList;
        }
    }
}
