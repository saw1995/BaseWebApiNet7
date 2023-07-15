using IsiBoCoreNegocio.Logger;
using IsiBoCoreNegocio.Model;
using IsiBoCoreNegocio.Model.DataBaseModel;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsiBoCoreNegocio.Repository.UsuarioRepository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private Conexion _connectionString;
        public UsuarioRepository(Conexion connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection _connection()
        {
            return new MySqlConnection(_connectionString.CadenaConexion);
        }
        public async Task<Response<UsuarioModel>> usuarioById(int idUSuario)
        {
            LogPrint.Info("usuarioById", $"parametros: {JsonConvert.SerializeObject(idUSuario)}");

            var response = new UsuarioModel();

            try
            {
                using (var conn = _connection())
                {
                    string query = "SELECT id, idCanal, idDepartamento, ci, nombre, apellidoPaterno, apellidoMaterno, "
                        + "direccion, correo, celular, foto, pass, fechaCreacion, fechaActualizacion, estado "
                        + "FROM usuario WHERE id = @id";

                    await conn.OpenAsync();

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", idUSuario);

                        using (var drd = await cmd.ExecuteReaderAsync())
                        {
                            while (await drd.ReadAsync())
                            {
                                response.Id = Convert.ToInt32(drd["id"]);
                                response.IdCanal = Convert.ToInt32(drd["idCanal"]);
                                response.IdDepartamento = Convert.ToInt32(drd["idDepartamento"]);
                                response.Ci = Convert.ToString(drd["ci"]) ?? "";
                                response.Nombre = Convert.ToString(drd["nombre"]) ?? "";
                                response.ApellidoPaterno = Convert.ToString(drd["apellidoPaterno"]) ?? "";
                                response.ApellidoMaterno = Convert.ToString(drd["apellidoMaterno"]) ?? "";
                                response.Direccion = Convert.ToString(drd["direccion"]) ?? "";
                                response.Correo = Convert.ToString(drd["correo"]) ?? "";
                                response.Celular = Convert.ToString(drd["celular"]) ?? "";
                                response.Foto = Convert.ToString(drd["foto"]) ?? "";
                                response.Pass = Convert.ToString(drd["pass"]) ?? "";
                                response.FechaCreacion = Convert.ToString(drd["fechaCreacion"]) == "" ? new DateTime(); Convert.ToDateTime(drd["fechaCreacion"]);
                                response.FechaActualizacion = Convert.ToString(drd["fechaActualizacion"]) == "" ? new DateTime(); Convert.ToDateTime(drd["fechaActualizacion"]);
                                response.Estado = Convert.ToBoolean(drd["estado"]);
                            }
                        }
                    }
                }

                LogPrint.Info("usuarioById", $"response: {JsonConvert.SerializeObject(response)}");

                if (response.Id == 0)
                {
                    LogPrint.Info("usuarioById", $"Usuario no existe no encontrado");
                    return Response<UsuarioModel>.UnhandledError($"Usuario no encontrado IdUsuario: {idUSuario}");
                }

                return Response<UsuarioModel>.Success(response);
            }
            catch (Exception ex)
            {
                LogPrint.Info("usuarioById", $"Error Excepción: {ex.Message}");
                return Response<UsuarioModel>.Error(StatusCode.ExcepcionError, $"Error Excepción: {ex.Message}");
            }
        }
    }
}
