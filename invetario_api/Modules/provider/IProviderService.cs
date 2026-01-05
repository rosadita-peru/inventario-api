using invetario_api.Modules.provider.dto;
using invetario_api.Modules.provider.entity;
using invetario_api.Modules.provider.response;
using invetario_api.utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace invetario_api.Modules.provider
{
    public interface IProviderService
    {
        Task<List<ProviderResponseSingle>> getProviders();

        Task<ProviderResponseSingle?> getProviderById(int providerId);

        Task<ProviderResponseSingle> createProvider(ProviderDto data);

        Task<ProviderResponseSingle?> updateProvider(int providerId, UpdateProviderDto data);

        Task<ProviderResponseSingle?> deleteProvider(int providerId);
    }
}
