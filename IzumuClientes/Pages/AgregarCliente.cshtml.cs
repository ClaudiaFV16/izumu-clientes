using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IzumuClientes.Services;
using static IzumuClientes.Models.ClienteModels;

namespace IzumuClientes.Pages
{
    public class AgregarClienteModel : PageModel
    {
        private readonly IClienteService _clienteService;

        public AgregarClienteModel(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; } 

        [BindProperty(SupportsGet = true)]
        public string NombreTipoDocumento { get; set; }

        [BindProperty(SupportsGet = true)]
        public string NumeroDocumento { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime FechaNacimiento { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PrimerNombre { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SegundoNombre { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PrimerApellido { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SegundoApellido { get; set; }

        [BindProperty(SupportsGet = true)]
        public string DireccionResidencia { get; set; }

        [BindProperty(SupportsGet = true)]
        public string NumeroCelular { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Email { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PlanId { get; set; }

        public List<TipoDocumento> TiposDocumento { get; set; } = new List<TipoDocumento>();
        public List<Plan> Planes { get; set; } = new List<Plan>();

        public async Task OnGet()
        {
            //Obtener tipos de documento
            TiposDocumento = await _clienteService.GetTiposDocumentoAsync();

            // Obtener planes
            Planes = await _clienteService.GetPlanesAsync();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            ApiResponse<string> apiResponse;

            if (Id.HasValue)
            {
                // Si existe un Id, se trata de una actualización
                var clienteUpdate = new ClienteUpdate
                {
                    Id = Id.Value,
                    TipoDocumentoId = int.Parse(NombreTipoDocumento),
                    NumeroDocumento = NumeroDocumento,
                    FechaNacimiento = FechaNacimiento,
                    PrimerNombre = PrimerNombre.ToUpper(),
                    SegundoNombre = SegundoNombre?.ToUpper(),
                    PrimerApellido = PrimerApellido.ToUpper(),
                    SegundoApellido = SegundoApellido?.ToUpper(),
                    DireccionResidencia = DireccionResidencia.ToUpper(),
                    NumeroCelular = NumeroCelular,
                    Email = Email.ToUpper(),
                    PlanId = PlanId
                };

                apiResponse = await _clienteService.UpdateClienteAsync(clienteUpdate);
            }
            else
            {
                // Si no hay Id, se trata de una creación
                var clienteCreate = new ClienteCreate
                {
                    TipoDocumentoId = int.Parse(NombreTipoDocumento),
                    NumeroDocumento = NumeroDocumento,
                    FechaNacimiento = FechaNacimiento,
                    PrimerNombre = PrimerNombre.ToUpper(),
                    SegundoNombre = SegundoNombre?.ToUpper(),
                    PrimerApellido = PrimerApellido.ToUpper(),
                    SegundoApellido = SegundoApellido?.ToUpper(),
                    DireccionResidencia = DireccionResidencia.ToUpper(),
                    NumeroCelular = NumeroCelular,
                    Email = Email.ToUpper(),
                    PlanId = PlanId
                };

                apiResponse = await _clienteService.CreateClienteAsync(clienteCreate);
            }

            if (apiResponse.Mensaje.Contains("exitoso") || apiResponse.Mensaje.Contains("creado") || apiResponse.Mensaje.Contains("actualizado"))
            {
                TempData["SuccessMessage"] = apiResponse.Mensaje;
                return RedirectToPage("Index");
            }
            else
            {
                await CargarDatosAsync();
                TempData["ErrorMessage"] = apiResponse.Mensaje;
                return RedirectToPage("AgregarCliente");
            }
        }


        private async Task CargarDatosAsync()
        {
            // Obtener tipos de documento
            TiposDocumento = await _clienteService.GetTiposDocumentoAsync();

            // Obtener planes
            Planes = await _clienteService.GetPlanesAsync();
        }
    }


    

  
}
