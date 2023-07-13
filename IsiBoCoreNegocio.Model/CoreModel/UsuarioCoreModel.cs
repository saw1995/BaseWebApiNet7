using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsiBoCoreNegocio.Model.CoreModel
{
    public class UsuarioCoreModel
    {
        public class UsuarioByIdParameter : Param
        {
            public int idUSuario { get; set; }
        }
    }
}
