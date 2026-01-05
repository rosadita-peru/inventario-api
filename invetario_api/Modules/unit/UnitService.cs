using invetario_api.database;
using invetario_api.Exceptions;
using invetario_api.Modules.unit.dto;
using invetario_api.Modules.unit.entity;
using invetario_api.Modules.unit.response;
using Microsoft.EntityFrameworkCore;

namespace invetario_api.Modules.unit
{
    public class UnitService : IUnitService
    {
        private Database _db;

        public UnitService(Database db)
        {
            _db = db;
        }

        public async Task<UnitSingleResponse> createUnit(UnitDto unitDto)
        {
            var newUnit = new Unit();
            newUnit.name = unitDto.name;
            newUnit.description = unitDto.description;

            await _db.units.AddAsync(newUnit);
            await _db.SaveChangesAsync();

            return UnitSingleResponse.fromEntity(newUnit);
        }

        public async Task<UnitSingleResponse?> deleteUnit(int unitId)
        {
            var findUnit = await _db.units.FindAsync(unitId);

            if (findUnit == null)
            {
                throw new HttpException(404, "Unit not found");
            }

            findUnit.status = false;

            await _db.SaveChangesAsync();

            return UnitSingleResponse.fromEntity(findUnit);
        }

        public async Task<UnitSingleResponse?> getUnitById(int unitId)
        {
            var findUnit = await _db.units.FindAsync(unitId);

            if (findUnit == null)
            {
                throw new HttpException(404, "Unit not found");
            }

            return UnitSingleResponse.fromEntity(findUnit);
        }

        public async Task<List<UnitSingleResponse>> getUnits()
        {
            var units = await _db.units.ToListAsync();

            return UnitSingleResponse.fromEntityList(units);
        }

        public async Task<UnitSingleResponse?> updateUnit(int unitId, UpdateUnitDto unitDto)
        {
            var findUnit = await _db.units.FindAsync(unitId);

            if (findUnit == null)
            {
                throw new HttpException(404, "Unit not found");
            }

            findUnit.name = unitDto.name;
            findUnit.description = unitDto.description;
            findUnit.status = (bool)unitDto.status!;

            await _db.SaveChangesAsync();

            return UnitSingleResponse.fromEntity(findUnit);
        }
    }
}
