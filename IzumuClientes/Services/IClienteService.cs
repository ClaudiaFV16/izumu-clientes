using IzumuClientes.Models;
using static IzumuClientes.Models.ClienteModels;

namespace IzumuClientes.Services
{
    public interface IClienteService
    {
        Task<List<Cliente>> GetClientesAsync();
        Task<List<TipoDocumento>> GetTiposDocumentoAsync();
        Task<List<Plan>> GetPlanesAsync();
        Task<ApiResponse<string>> CreateClienteAsync(ClienteCreate cliente);
        Task<ApiResponse<string>> UpdateClienteAsync(ClienteUpdate cliente);
        Task<ApiResponse<string>> DeleteClienteAsync(int id);
    }
} 