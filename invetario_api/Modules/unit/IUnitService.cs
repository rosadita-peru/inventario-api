using invetario_api.Modules.unit.dto;
using invetario_api.Modules.unit.entity;
using invetario_api.Modules.unit.response;

namespace invetario_api.Modules.unit
{
    public interface IUnitService
    {
        public Task<List<UnitSingleResponse>> getUnits();

        public Task<UnitSingleResponse?> getUnitById(int unitId);

        public Task<UnitSingleResponse> createUnit(UnitDto unitDto);

        public Task<UnitSingleResponse?> updateUnit(int unitId, UpdateUnitDto unitDto);

        public Task<UnitSingleResponse?> deleteUnit(int unitId);
    }
}
