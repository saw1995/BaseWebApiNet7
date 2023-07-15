using IsiBoCoreNegocio.Model;
using IsiBoCoreNegocio.Model.DataBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsiBoCoreNegocio.Repository.UsuarioRepository
{
    public interface IUsuarioRepository
    {
        Task<Response<UsuarioModel>> UsuarioById(int IdUsuario);
    }
}
