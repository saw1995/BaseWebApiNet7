using IsiBoCoreNegocio.Logger;
using IsiBoCoreNegocio.Model;
using IsiBoCoreNegocio.Model.DataBase;
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
        public async Task<Response<UsuarioModel>> UsuarioById(int _idUsuario)
        {
            LogPrint.Info("UsuarioById", $"parametros: {JsonConvert.SerializeObject(_idUsuario)}");

            var response = new UsuarioModel();

            try
            {
                using (var conn = _connection())
                {
                    string query = "SELECT Id, Ci, Nombre, ApellidoPaterno, ApellidoMaterno, Direccion, Correo, Celular, Foto, Password, Estado FROM Usuario where Id = @Id";

                    await conn.OpenAsync();

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", _idUsuario);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                response.Id = Convert.ToInt32(reader["Id"]);
                                response.Ci = Convert.ToString(reader["Ci"]) ?? "";
                                response.Nombre = Convert.ToString(reader["Nombre"]) ?? "";
                                response.ApellidoPaterno = Convert.ToString(reader["ApellidoPaterno"]) ?? "";
                                response.ApellidoMaterno = Convert.ToString(reader["ApellidoMaterno"]) ?? "";
                                response.Direccion = Convert.ToString(reader["Direccion"]) ?? "";
                                response.Correo = Convert.ToString(reader["Correo"]) ?? "";
                                response.Celular = Convert.ToString(reader["Celular"]) ?? "";
                                response.Foto = Convert.ToString(reader["Foto"]) ?? "";
                                response.Password = Convert.ToString(reader["Password"]) ?? "";
                                response.Estado = Convert.ToBoolean(reader["Estado"]);
                            }
                        }
                    }
                }

                LogPrint.Info("UsuarioById", $"response: {JsonConvert.SerializeObject(response)}");

                if (response.Id == 0)
                {
                    LogPrint.Info("AppParkZone.Data.UsuarioData.UsuarioById", $"Usuario no existe no encontrado");
                    return Response<UsuarioModel>.UnhandledError($"Usuario no encontrado IdUsuario: {_idUsuario}");
                }

                return Response<UsuarioModel>.Success(response);
            }
            catch (Exception ex)
            {
                LogPrint.Info("AppParkZone.Data.UsuarioData.UsuarioById", $"Error Excepción: {ex.Message}");
                return Response<UsuarioModel>.Error(StatusCode.ExcepcionError, $"Error Excepción: {ex.Message}");
            }
        }
    }
}
