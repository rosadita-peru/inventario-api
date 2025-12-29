using invetario_api.Modules.unit.dto;
using invetario_api.Modules.unit.entity;

namespace invetario_api.Modules.unit
{
    public interface IUnitService
    {
        public Task<List<Unit>> getUnits();

        public Task<Unit?> getUnitById(int unitId);

        public Task<Unit> createUnit(UnitDto unitDto);

        public Task<Unit?> updateUnit(int unitId, UpdateUnitDto unitDto);

        public Task<Unit?> deleteUnit(int unitId);
    }
}
