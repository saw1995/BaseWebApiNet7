using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsiBoCoreNegocio.Model.DataBaseModel
{
    public class AppSistemaModel
    {
        public int Id { get; set; }
        public int IdCanal { get; set; }
        public string? VersionApp { get; set; }
        public string? Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }
    }
}
