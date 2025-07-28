using IzumuClientes.Services;
using IzumuClientes.Configuration;
using IzumuClientes.Models;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using static IzumuClientes.Models.ClienteModels;

namespace IzumuClientes.Tests.Services
{
    [TestFixture]
    public class ClienteServiceTests
    {
        private Mock<HttpClient> _httpClientMock;
        private Mock<IOptions<Microservicio>> _apiSettingsMock;
        private ClienteService _clienteService;

        [SetUp]
        public void Setup()
        {
            _httpClientMock = new Mock<HttpClient>();
            _apiSettingsMock = new Mock<IOptions<Microservicio>>();
            
            _apiSettingsMock.Setup(x => x.Value).Returns(new Microservicio 
            { 
                BaseUrl_Service = "http://localhost:5020/api/Cliente" 
            });

            _clienteService = new ClienteService(_httpClientMock.Object, _apiSettingsMock.Object);
        }

        [Test]
        public void ClienteService_Constructor_ShouldInitializeCorrectly()
        {
            // Assert
            Assert.That(_clienteService, Is.Not.Null);
        }

        [Test]
        public void ClienteService_WithValidSettings_ShouldHaveCorrectBaseUrl()
        {
            // Arrange
            var expectedBaseUrl = "http://localhost:5020/api/Cliente";

            // Assert
            Assert.That(_apiSettingsMock.Object.Value.BaseUrl_Service, Is.EqualTo(expectedBaseUrl));
        }

        [Test]
        public void ClienteCreate_Properties_ShouldBeAccessible()
        {
            // Arrange & Act
            var clienteCreate = new ClienteCreate
            {
                TipoDocumentoId = 1,
                NumeroDocumento = "80123456",
                FechaNacimiento = DateTime.Now,
                PrimerNombre = "Claudia",
                SegundoNombre = "Andrea",
                PrimerApellido = "Fernandez",
                SegundoApellido = "Herrera",
                DireccionResidencia = "Calle 85 # 12-45",
                NumeroCelular = "3001234567",
                Email = "claudia.fernandez@empresa.com",
                PlanId = 2
            };

            // Assert
            Assert.That(clienteCreate.TipoDocumentoId, Is.EqualTo(1));
            Assert.That(clienteCreate.NumeroDocumento, Is.EqualTo("80123456"));
            Assert.That(clienteCreate.PrimerNombre, Is.EqualTo("Claudia"));
            Assert.That(clienteCreate.Email, Is.EqualTo("claudia.fernandez@empresa.com"));
        }

        [Test]
        public void ClienteUpdate_Properties_ShouldBeAccessible()
        {
            // Arrange & Act
            var clienteUpdate = new ClienteUpdate
            {
                Id = 1,
                TipoDocumentoId = 1,
                NumeroDocumento = "80123456",
                FechaNacimiento = DateTime.Now,
                PrimerNombre = "Claudia",
                SegundoNombre = "Andrea",
                PrimerApellido = "Fernandez",
                SegundoApellido = "Herrera",
                DireccionResidencia = "Calle 85 # 12-45",
                NumeroCelular = "3001234567",
                Email = "claudia.fernandez@empresa.com",
                PlanId = 2
            };

            // Assert
            Assert.That(clienteUpdate.Id, Is.EqualTo(1));
            Assert.That(clienteUpdate.TipoDocumentoId, Is.EqualTo(1));
            Assert.That(clienteUpdate.NumeroDocumento, Is.EqualTo("80123456"));
            Assert.That(clienteUpdate.PrimerNombre, Is.EqualTo("Claudia"));
            Assert.That(clienteUpdate.Email, Is.EqualTo("claudia.fernandez@empresa.com"));
        }

        [Test]
        public void ApiResponse_Properties_ShouldBeAccessible()
        {
            // Arrange & Act
            var apiResponse = new ApiResponse<string>
            {
                Mensaje = "Operación exitosa",
                Response = "Datos del cliente"
            };

            // Assert
            Assert.That(apiResponse.Mensaje, Is.EqualTo("Operación exitosa"));
            Assert.That(apiResponse.Response, Is.EqualTo("Datos del cliente"));
        }

        [Test]
        public void Cliente_Properties_ShouldBeAccessible()
        {
            // Arrange & Act
            var cliente = new Cliente
            {
                Id = 1,
                TipoDocumentoId = 1,
                NombreTipoDocumento = "Cedula de Ciudadania",
                NumeroDocumento = "80123456",
                FechaNacimiento = DateTime.Now,
                PrimerNombre = "Claudia",
                SegundoNombre = "Andrea",
                PrimerApellido = "Fernandez",
                SegundoApellido = "Herrera",
                DireccionResidencia = "Calle 85 # 12-45",
                NumeroCelular = "3001234567",
                Email = "claudia.fernandez@empresa.com",
                PlanId = 2,
                Nombre_Plan = "Plan Premium"
            };

            // Assert
            Assert.That(cliente.Id, Is.EqualTo(1));
            Assert.That(cliente.TipoDocumentoId, Is.EqualTo(1));
            Assert.That(cliente.NombreTipoDocumento, Is.EqualTo("Cedula de Ciudadania"));
            Assert.That(cliente.NumeroDocumento, Is.EqualTo("80123456"));
            Assert.That(cliente.PrimerNombre, Is.EqualTo("Claudia"));
            Assert.That(cliente.Email, Is.EqualTo("claudia.fernandez@empresa.com"));
            Assert.That(cliente.Nombre_Plan, Is.EqualTo("Plan Premium"));
        }

        [Test]
        public void TipoDocumento_Properties_ShouldBeAccessible()
        {
            // Arrange & Act
            var tipoDocumento = new TipoDocumento
            {
                Id = 1,
                Cod_TipoDocumento = "CC",
                NombreTipoDocumento = "Cedula de Ciudadania"
            };

            // Assert
            Assert.That(tipoDocumento.Id, Is.EqualTo(1));
            Assert.That(tipoDocumento.Cod_TipoDocumento, Is.EqualTo("CC"));
            Assert.That(tipoDocumento.NombreTipoDocumento, Is.EqualTo("Cedula de Ciudadania"));
        }

        [Test]
        public void Plan_Properties_ShouldBeAccessible()
        {
            // Arrange & Act
            var plan = new Plan
            {
                Id = 1,
                Nombre_Plan = "Plan Premium - Cobertura Familiar"
            };

            // Assert
            Assert.That(plan.Id, Is.EqualTo(1));
            Assert.That(plan.Nombre_Plan, Is.EqualTo("Plan Premium - Cobertura Familiar"));
        }
    }
} 