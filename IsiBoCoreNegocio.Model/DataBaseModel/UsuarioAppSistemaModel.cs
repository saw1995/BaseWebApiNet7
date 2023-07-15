using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsiBoCoreNegocio.Model.DataBaseModel
{
    public class UsuarioAppSistemaModel
    {
        public int Id { get; set; }
        public int IdAppSistema { get; set; }
        public int IdUsuario { get; set; }
        public bool Estado { get; set; }
    }
}
