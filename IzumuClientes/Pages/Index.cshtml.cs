using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IzumuClientes.Services;
using IzumuClientes.Models;
using static IzumuClientes.Models.ClienteModels;

namespace IzumuClientes.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IClienteService _clienteService;

        public IndexModel(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public List<Cliente> Clientes { get; set; } = new List<Cliente>();
        public List<TipoDocumento> TiposDocumento { get; set; } = new List<TipoDocumento>();
        public List<Plan> Planes { get; set; } = new List<Plan>();

        public async Task OnGet()
        {
            // Obtener clientes
            Clientes = await _clienteService.GetClientesAsync();

            // Obtener tipos de documento
            TiposDocumento = await _clienteService.GetTiposDocumentoAsync();

            // Obtener planes
            Planes = await _clienteService.GetPlanesAsync();
        }

        public async Task<IActionResult> OnPostDeleteClienteAsync(int Id)
        {
            var apiResponse = await _clienteService.DeleteClienteAsync(Id);

            if (apiResponse.Mensaje.Contains("exitoso") || apiResponse.Mensaje.Contains("eliminado"))
            {   
                TempData["SuccessMessage"] = apiResponse.Mensaje;
            }
            else {
                TempData["ErrorMessage"] = apiResponse.Mensaje;
            }
            return RedirectToPage();
        }
    }

}
