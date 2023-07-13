using IsiBoCoreNegocio.Model;
using MySql.Data.MySqlClient;

namespace IsiBoCoreNegocio.Repository
{
    public class Conexion
    {
        public string CadenaConexion { get; set; }

        [Obsolete]
        public Conexion(MySqlConfigurationModel param)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = param.Server;
            builder.Database = param.Database;
            builder.UserID = param.Usuario;
            builder.Password = param.Password;
            builder.SslMode = MySqlSslMode.None; // Opcional: Establece el modo SSL

            CadenaConexion = builder.ToString();
        }
    }
}
