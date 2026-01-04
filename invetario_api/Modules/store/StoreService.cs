using invetario_api.database;
using invetario_api.Exceptions;
using invetario_api.Modules.store.dto;
using invetario_api.Modules.store.entity;
using invetario_api.Modules.store.response;
using invetario_api.utils;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace invetario_api.Modules.store
{
    public class StoreService : IStoreService
    {
        private Database _db;

        public StoreService(Database db) { 
            _db = db;
        }

        public async Task<List<StoreResponse>> getStores()
        {
            var stores = await _db.stores.Include(s => s.user).ToListAsync();

            return StoreResponse.fromEntityList(stores);
        }

        public async Task<StoreResponse?> createStore(StoreDto data)
        {   
            var findUser = await _db.users
                .Where(user => user.userId == data.userId && user.status == true)
                .FirstOrDefaultAsync();

            if(findUser == null)
            {
                throw new HttpException(404, "User not found");
            }

            var newStore = new Store
            {
                name = data.name,
                code = data.code,
                address = data.address,
                phone = data.phone,
                maxCapacity = data.maxCapacity,
                status = true,
                type = data.type,
                userId = data.userId,
                observations = data.observations
            };

            await _db.stores.AddAsync(newStore);
            await _db.SaveChangesAsync();


            var storeResponse = StoreResponse.fromEntity(newStore);

            return storeResponse;
        }

        public async Task<StoreResponse?> deleteStore(int storeId)
        {
            var store = await _db.stores.FindAsync(storeId);
            if (store == null)
            {
                return null;
            }
            store.status = false;

            await _db.SaveChangesAsync();
            return StoreResponse.fromEntity(store);
        }

        public async Task<StoreResponse?> getStoreById(int storeId)
        {
            var store = await _db.stores.FindAsync(storeId);
            if (store == null)
            {
                throw new HttpException(404, "Store not found");
            }

            return StoreResponse.fromEntity(store);
        }

        public async Task<StoreResponse?> updateStore(int storeId, UpdateStoreDto data)
        {
            var store = await _db.stores.FindAsync(storeId);
            if (store == null)
            {
                throw new HttpException(404, "Store not found");
            }

            var findUser = await _db.users
                .Where(user => user.userId == data.userId && user.status == true)
                .FirstOrDefaultAsync();

            if(findUser == null)
            {
                throw new HttpException(404, "User not found");
            }


            store.name = data.name;
            store.code = data.code;
            store.address = data.address;
            store.phone = data.phone;
            store.maxCapacity = data.maxCapacity;
            store.status = data.status.Value;
            store.type = data.type;
            store.userId = data.userId;
            store.observations = data.observations;
            await _db.SaveChangesAsync();


            return StoreResponse.fromEntity(store);
        }
    }
}
