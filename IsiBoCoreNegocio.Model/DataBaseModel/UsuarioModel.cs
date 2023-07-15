using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsiBoCoreNegocio.Model.DataBaseModel
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public int IdCanal { get; set; }
        public int IdDepartamento { get; set; }
        public string? Ci { get; set; }
        public string? Nombre { get; set; }
        public string? ApellidoPaterno { get; set; }
        public string? ApellidoMaterno { get; set; }
        public string? Direccion { get; set; }
        public string? Correo { get; set; }
        public string? Celular { get; set; }
        public string? Foto { get; set; }
        public string? Pass { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
        public bool Estado { get; set; }
    }
}
