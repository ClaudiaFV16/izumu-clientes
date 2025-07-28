using Microservice_Izumu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MicroService_Izumu.Test.Services;
using MicroService_Izumu.Test.Models;
using Microservice_Izumu.Data;
using Moq;
using NUnit.Framework;

namespace MicroService_Izumu.Test.MicroService
{
    [TestFixture]
    public class ClienteServicesTest_Completo
    {
        private Cliente cliente;
        private ClienteRequest clienteRequest;
        private IMapper mapper;
        private ClienteDbContext dbContext;

        [SetUp]
        public void Setup()
        {
            // Configurar mapper mock
            var mapperMock = new Mock<IMapper>();
            mapper = mapperMock.Object;

            // Configurar cliente de prueba
            cliente = new Cliente()
            {
                Id = 1,
                TipoDocumentoId = 1,
                NombreTipoDocumento = "Cedula de Ciudadania",
                NumeroDocumento = "80123456",
                FechaNacimiento = Convert.ToDateTime("1985-06-15"),
                PrimerNombre = "Claudia",
                SegundoNombre = "Andrea",
                PrimerApellido = "Fernandez",
                SegundoApellido = "Herrera",
                DireccionResidencia = "Calle 85 # 12-45, Oficina 302, Bogota",
                NumeroCelular = "3001234567",
                Email = "claudia.fernandez@empresa.com",
                PlanId = 2,
                Nombre_Plan = "Plan Premium - Cobertura Familiar"
            };

            // Configurar request de prueba
            clienteRequest = new ClienteRequest()
            {
                Id = 1,
                TipoDocumentoId = 1,
                NumeroDocumento = "80123456",
                FechaNacimiento = Convert.ToDateTime("1985-06-15"),
                PrimerNombre = "Claudia",
                SegundoNombre = "Andrea",
                PrimerApellido = "Fernandez",
                SegundoApellido = "Herrera",
                DireccionResidencia = "Calle 85 # 12-45, Oficina 302, Bogota",
                NumeroCelular = "3001234567",
                Email = "claudia.fernandez@empresa.com",
                PlanId = 2
            };

            // Configurar base de datos en memoria
            var services = new ServiceCollection();
            services.AddDbContext<ClienteDbContext>(options => 
                options.UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()));
            
            var serviceProvider = services.BuildServiceProvider();
            dbContext = serviceProvider.GetService<ClienteDbContext>();
        }

        [Test]
        public async Task UpdateCliente_WithValidData_ShouldReturnSuccess()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<Cliente>(It.IsAny<ClienteRequest>())).Returns(cliente);
            
            var services = new ClienteServices(dbContext, mapperMock.Object);

            // Act
            var result = await services.UpdateCliente(clienteRequest);

            // Assert
            Assert.That(result.HttpCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(result.Message, Is.Null.Or.Empty);
        }

        [Test]
        public async Task UpdateCliente_WithInvalidData_ShouldReturnError()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            mapperMock.Setup(m => m.Map<Cliente>(It.IsAny<ClienteRequest>()))
                     .Throws(new Exception("Error de validación"));
            
            var services = new ClienteServices(dbContext, mapperMock.Object);

            // Act
            var result = await services.UpdateCliente(clienteRequest);

            // Assert
            Assert.That(result.HttpCode, Is.EqualTo(HttpStatusCode.InternalServerError));
            Assert.That(result.Message, Is.EqualTo("Error de validación"));
        }

        [Test]
        public async Task UpdateCliente_WithNullRequest_ShouldReturnError()
        {
            // Arrange
            var mapperMock = new Mock<IMapper>();
            var services = new ClienteServices(dbContext, mapperMock.Object);

            // Act
            var result = await services.UpdateCliente(null);

            // Assert
            Assert.That(result.HttpCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        }

        [Test]
        public void ClienteRequest_Properties_ShouldBeAccessible()
        {
            // Arrange & Act
            var request = new ClienteRequest
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
            Assert.That(request.Id, Is.EqualTo(1));
            Assert.That(request.TipoDocumentoId, Is.EqualTo(1));
            Assert.That(request.NumeroDocumento, Is.EqualTo("80123456"));
            Assert.That(request.PrimerNombre, Is.EqualTo("Claudia"));
            Assert.That(request.Email, Is.EqualTo("claudia.fernandez@empresa.com"));
        }

        [Test]
        public void ResponseServices_Properties_ShouldBeAccessible()
        {
            // Arrange & Act
            var response = new ResponseServices
            {
                HttpCode = HttpStatusCode.OK,
                Message = "Operación exitosa"
            };

            // Assert
            Assert.That(response.HttpCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Message, Is.EqualTo("Operación exitosa"));
        }

        [TearDown]
        public void Cleanup()
        {
            dbContext?.Dispose();
        }
    }
} 