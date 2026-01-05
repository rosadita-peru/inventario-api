using invetario_api.database;
using invetario_api.Exceptions;
using invetario_api.Modules.provider.dto;
using invetario_api.Modules.provider.entity;
using invetario_api.Modules.provider.response;
using invetario_api.utils;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace invetario_api.Modules.provider
{
    public class ProviderService : IProviderService
    {
        private Database _db;

        public ProviderService(Database db)
        {
            _db = db;
        }

        public async Task<List<ProviderResponseSingle>> getProviders()
        {
            var providers = await _db.providers.ToListAsync();

            return ProviderResponseSingle.fromEntityList(providers);
        }

        public async Task<ProviderResponseSingle> createProvider(ProviderDto data)
        {
            var newProvider = new Provider
            {
                code = data.code,
                companyName = data.companyName,
                publicName = data.publicName,
                typeDocument = data.typeDocument,
                documentNumber = data.documentNumber,
                address = data.address,
                phone = data.phone,
                email = data.email,
                mainContact = data.mainContact,
                contactPhone = data.contactPhone,
                payCondition = data.payCondition.Value,
                typeMoney = data.typeMoney,
                daysDelivery = data.daysDelivery,
            };

            _db.providers.Add(newProvider);
            await _db.SaveChangesAsync();

            return ProviderResponseSingle.fromEntity(newProvider);
        }

        public async Task<ProviderResponseSingle?> deleteProvider(int providerId)
        {
            var provider = await _db.providers.Where(p => p.providerId == providerId).FirstOrDefaultAsync();
            if (provider == null)
            {
                throw new HttpException(404, "Provider not found");
            }

            provider.status = false;
            await _db.SaveChangesAsync();
            return ProviderResponseSingle.fromEntity(provider);
        }

        public async Task<ProviderResponseSingle?> getProviderById(int providerId)
        {
            var provider = await _db.providers.Where(p => p.providerId == providerId).FirstOrDefaultAsync();
            if (provider == null)
            {
                throw new HttpException(404, "Provider not found");
            }

            return ProviderResponseSingle.fromEntity(provider);
        }

        public async Task<ProviderResponseSingle?> updateProvider(int providerId, UpdateProviderDto data)
        {
            var provider = await _db.providers.Where(p => p.providerId == providerId).FirstOrDefaultAsync();
            if (provider == null)
            {
                throw new HttpException(404, "Provider not found");
            }

            provider.code = data.code;
            provider.companyName = data.companyName;
            provider.publicName = data.publicName;
            provider.typeDocument = data.typeDocument;
            provider.documentNumber = data.documentNumber;
            provider.address = data.address;
            provider.phone = data.phone;
            provider.email = data.email;
            provider.mainContact = data.mainContact;
            provider.contactPhone = data.contactPhone;
            provider.payCondition = data.payCondition.Value;
            provider.typeMoney = data.typeMoney;
            provider.daysDelivery = data.daysDelivery;
            provider.status = data.status!.Value;
            await _db.SaveChangesAsync();

            return ProviderResponseSingle.fromEntity(provider);
        }
    }
}
