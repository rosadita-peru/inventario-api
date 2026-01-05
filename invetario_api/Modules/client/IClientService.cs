using invetario_api.Modules.client.dto;
using invetario_api.Modules.client.entity;
using invetario_api.utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace invetario_api.Modules.client
{
    public interface IClientService
    {
        Task<List<Client>> getClients();

        Task<Client?> getClientById(int clientId);
        
        Task<Client> createClient(ClientDto data);

        Task<Client?> updateClient(int clientId, UpdateClientDto data);

        Task<Client?> deleteClient(int clientId);
    }
}
