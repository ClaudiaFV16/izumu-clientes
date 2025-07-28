
using Microservice_Izumu.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
//using System.Data.SqlClient;

namespace Microservice_Izumu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly string cadenaSql;

        public ClienteController(IConfiguration config)
        {
            cadenaSql = config.GetConnectionString("Bd_Izumu_Cx");

        }

        /// <summary>
        /// GetTipoDocumento obtiene todos lo tipos de documentos 
        /// </summary>
        /// <returns></returns>
        [EnableCors("AllowSpecificOrigins")]
        [HttpGet]
        [Route("GetTipoDocumento")]
        public IActionResult GetTipoDocumento()
        {
            List<TipoDocumento> lista = new List<TipoDocumento>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSql))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_GetTipoDocumento", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new TipoDocumento()
                            {
                                Id = Convert.ToInt32(rd["Id"]),
                                Cod_TipoDocumento = rd["Cod_TipoDocumento"].ToString(),
                                NombreTipoDocumento = rd["NombreTipoDocumento"].ToString()

                            });
                        }

                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });

            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = lista });
            }


        }


        /// <summary>
        /// GetPlan enlista todos los planes existentes
        /// </summary>
        /// <returns></returns>
        /// 

        [EnableCors("AllowSpecificOrigins")]
        [HttpGet]
        [Route("GetPlan")]
        public IActionResult GetPlan()
        {
            List<Plan> lista = new List<Plan>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSql))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_GetPlan", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Plan()
                            {
                                Id = Convert.ToInt32(rd["Id"]),
                                Nombre_Plan = rd["Nombre_Plan"].ToString()


                            });
                        }

                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });

            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = lista });
            }


        }



        /// <summary>
        /// GetClientes: genera información de todos los clientes en la BD
        /// </summary>
        /// <returns></returns>
        /// 
        [EnableCors("AllowSpecificOrigins")]
        [HttpGet]
        [Route("GetClientes")]
        public IActionResult GetClientes()
        {
            List<Cliente> lista = new List<Cliente>();
            try
            {
                using (var conexion = new SqlConnection(cadenaSql))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("sp_GetClientes", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            lista.Add(new Cliente()
                            {
                                Id = Convert.ToInt32(rd["Id"]),
                                TipoDocumentoId = Convert.ToInt32(rd["TipoDocumentoId"]),
                                NombreTipoDocumento = rd["NombreTipoDocumento"].ToString(),
                                NumeroDocumento = rd["NumeroDocumento"].ToString(),
                                FechaNacimiento = Convert.ToDateTime(rd["FechaNacimiento"]),
                                PrimerNombre = rd["PrimerNombre"].ToString(),
                                SegundoNombre = rd["SegundoNombre"].ToString(),
                                PrimerApellido = rd["PrimerApellido"].ToString(),
                                SegundoApellido = rd["SegundoApellido"].ToString(),
                                DireccionResidencia = rd["DireccionResidencia"].ToString(),
                                NumeroCelular = rd["NumeroCelular"].ToString(),
                                Email = rd["Email"].ToString(),
                                PlanId = Convert.ToInt32(rd["PlanId"]),
                                Nombre_Plan = rd["Nombre_Plan"].ToString()


                            });
                        }

                    }
                }
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });

            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = lista });
            }


        }

        /// <summary>
        /// DeleteCliente: elimina el cliente por el Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// 

        [EnableCors("AllowSpecificOrigins")]
        [HttpDelete]
        [Route("DeleteCliente/{id}")]
        public IActionResult DeleteCliente(int id)
        {
            try
            {
                using (var conexion = new SqlConnection(cadenaSql))
                {
                    conexion.Open();
                    using (var cmd = new SqlCommand("sp_DeleteCliente", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);


                        var resultadoParam = new SqlParameter
                        {
                            ParameterName = "@Resultado",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(resultadoParam);

                        cmd.ExecuteNonQuery();


                        int resultado = (int)resultadoParam.Value;

                        if (resultado == 1)
                        {
                            return StatusCode(StatusCodes.Status200OK, new { mensaje = "Cliente eliminado exitosamente" });
                        }
                        else
                        {
                            return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "Cliente no encontrado" });
                        }
                    }
                }
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }

        /// <summary>
        /// UpdateCliente: actualiza la información del cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        /// 
        [EnableCors("AllowSpecificOrigins")]
        [HttpPut]
        [Route("UpdateCliente")]
        public IActionResult UpdateCliente([FromBody] ClienteUpdateDTO cliente)
        {
            if (cliente == null)
            {
                return BadRequest(new { mensaje = "Los datos del cliente no pueden ser nulos." });
            }

            try
            {
                using (var conexion = new SqlConnection(cadenaSql))
                {
                    conexion.Open();
                    using (var cmd = new SqlCommand("sp_UpdateCliente", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@Id", cliente.Id);
                        cmd.Parameters.AddWithValue("@TipoDocumentoId", cliente.TipoDocumentoId);
                        cmd.Parameters.AddWithValue("@NumeroDocumento", cliente.NumeroDocumento);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@PrimerNombre", cliente.PrimerNombre);
                        cmd.Parameters.AddWithValue("@SegundoNombre", (object)cliente.SegundoNombre ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@PrimerApellido", cliente.PrimerApellido);
                        cmd.Parameters.AddWithValue("@SegundoApellido", (object)cliente.SegundoApellido ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@DireccionResidencia", cliente.DireccionResidencia);
                        cmd.Parameters.AddWithValue("@NumeroCelular", cliente.NumeroCelular);
                        cmd.Parameters.AddWithValue("@Email", cliente.Email);
                        cmd.Parameters.AddWithValue("@PlanId", cliente.PlanId);


                        cmd.ExecuteNonQuery();

                        return StatusCode(StatusCodes.Status200OK, new { mensaje = "Cliente actualizado exitosamente" });
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == 50000) // RAISERROR
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { mensaje = ex.Message });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }



        /// <summary>
        /// InsertarCliente: inserta un nuevo cliente en la base de datos
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        /// 
        [EnableCors("AllowSpecificOrigins")]
        [HttpPost]
        [Route("CreateCliente")]
        public IActionResult CreateCliente([FromBody] ClienteCreateDTO cliente)
        {
            if (cliente == null)
            {
                return BadRequest(new { mensaje = "Los datos del cliente no pueden ser nulos." });
            }

            try
            {
                using (var conexion = new SqlConnection(cadenaSql))
                {
                    conexion.Open();
                    using (var cmd = new SqlCommand("sp_InsertCliente", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@TipoDocumentoId", cliente.TipoDocumentoId);
                        cmd.Parameters.AddWithValue("@NumeroDocumento", cliente.NumeroDocumento);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@PrimerNombre", cliente.PrimerNombre);
                        cmd.Parameters.AddWithValue("@SegundoNombre", (object)cliente.SegundoNombre ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@PrimerApellido", cliente.PrimerApellido);
                        cmd.Parameters.AddWithValue("@SegundoApellido", (object)cliente.SegundoApellido ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@DireccionResidencia", cliente.DireccionResidencia);
                        cmd.Parameters.AddWithValue("@NumeroCelular", cliente.NumeroCelular);
                        cmd.Parameters.AddWithValue("@Email", cliente.Email);
                        cmd.Parameters.AddWithValue("@PlanId", cliente.PlanId);

                        cmd.ExecuteNonQuery();

                        return StatusCode(StatusCodes.Status200OK, new { mensaje = "Cliente registrado exitosamente" });
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == 50000) // RAISERROR
            {
                return StatusCode(StatusCodes.Status400BadRequest, new { mensaje = ex.Message });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message });
            }
        }


    }
}
