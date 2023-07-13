using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsiBoCoreNegocio.Model.DataBase
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string? Ci { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? Direccion { get; set; }
        public string? Correo { get; set; }
        public string? Celular { get; set; }
        public string? Foto { get; set; }
        public string? Password { get; set; }
        public bool Estado { get; set; }
    }
}
