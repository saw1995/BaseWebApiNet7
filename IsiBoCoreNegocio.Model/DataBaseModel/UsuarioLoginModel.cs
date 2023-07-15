using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsiBoCoreNegocio.Model.DataBaseModel
{
    public class UsuarioLoginModel
    {
        public int Id { get; set; }
        public int IdAppSistema { get; set; }
        public int IdUsuario { get; set; }
        public string? Dispositivo { get; set; }
        public string? Detalle { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public bool Estado { get; set; }
    }
}
