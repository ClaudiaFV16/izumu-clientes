using IzumuClientes.Configuration;
using IzumuClientes.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using static IzumuClientes.Models.ClienteModels;
using System.Text;

namespace IzumuClientes.Services
{
    public class ClienteService : IClienteService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public ClienteService(HttpClient httpClient, IOptions<Microservicio> apiSettings)
        {
            _httpClient = httpClient;
            _baseUrl = apiSettings.Value.BaseUrl_Service;
        }

        public async Task<List<Cliente>> GetClientesAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync(GetApiUrl("GetClientes"));
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<Cliente>>>(response);
                return apiResponse?.Response ?? new List<Cliente>();
            }
            catch (Exception)
            {
                // Log the exception
                return new List<Cliente>();
            }
        }

        public async Task<List<TipoDocumento>> GetTiposDocumentoAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync(GetApiUrl("GetTipoDocumento"));
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<TipoDocumento>>>(response);
                return apiResponse?.Response ?? new List<TipoDocumento>();
            }
            catch (Exception)
            {
                return new List<TipoDocumento>();
            }
        }

        public async Task<List<Plan>> GetPlanesAsync()
        {
            try
            {
                var response = await _httpClient.GetStringAsync(GetApiUrl("GetPlan"));
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<Plan>>>(response);
                return apiResponse?.Response ?? new List<Plan>();
            }
            catch (Exception)
            {
                return new List<Plan>();
            }
        }

        public async Task<ApiResponse<string>> CreateClienteAsync(ClienteCreate cliente)
        {
            try
            {
                var clienteJson = JsonConvert.SerializeObject(cliente);
                var content = new StringContent(clienteJson, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(GetApiUrl("CreateCliente"), content);
                
                var responseContent = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<string>>(responseContent);
                
                return apiResponse ?? new ApiResponse<string> { Mensaje = "Error desconocido" };
            }
            catch (Exception ex)
            {
                return new ApiResponse<string> { Mensaje = ex.Message };
            }
        }

        public async Task<ApiResponse<string>> UpdateClienteAsync(ClienteUpdate cliente)
        {
            try
            {
                var clienteJson = JsonConvert.SerializeObject(cliente);
                var content = new StringContent(clienteJson, Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync(GetApiUrl("UpdateCliente"), content);
                
                var responseContent = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<string>>(responseContent);
                
                return apiResponse ?? new ApiResponse<string> { Mensaje = "Error desconocido" };
            }
            catch (Exception ex)
            {
                return new ApiResponse<string> { Mensaje = ex.Message };
            }
        }

        public async Task<ApiResponse<string>> DeleteClienteAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(GetApiUrl($"DeleteCliente/{id}"));
                var responseContent = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<string>>(responseContent);
                
                return apiResponse ?? new ApiResponse<string> { Mensaje = "Error desconocido" };
            }
            catch (Exception ex)
            {
                return new ApiResponse<string> { Mensaje = ex.Message };
            }
        }

        private string GetApiUrl(string endpoint)
        {
            return $"{_baseUrl}/{endpoint}";
        }
    }
} 