using IsiBoCoreNegocio.Model.DataBase;
using IsiBoCoreNegocio.Model;
using IsiBoCoreNegocio.Repository.UsuarioRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static IsiBoCoreNegocio.Model.CoreModel.UsuarioCoreModel;

namespace IsiBoCoreNegocio.WebApi.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioController(IUsuarioRepository usuarioDataBase)
        {
            _usuarioRepository = usuarioDataBase;
        }

        [HttpPost]
        [Route("UsuarioById")]
        public async Task<Response<UsuarioModel>> UsuarioById(UsuarioByIdParameter param)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Response<UsuarioModel>.Error(Model.StatusCode.BadRequest, "BAD REQUEST!!!");
                }

                var busquedaUsuario = await _usuarioRepository.UsuarioById(param.idUSuario);

                if (busquedaUsuario.codigo != Model.StatusCode.OK)
                {
                    return Response<UsuarioModel>.Error(Model.StatusCode.ExcepcionError, "Api: " + busquedaUsuario.mensaje);
                }

                var usuarioEncontrado = busquedaUsuario.data == null ? new UsuarioModel() : busquedaUsuario.data;
                usuarioEncontrado.Password = "";

                return Response<UsuarioModel>.Success(usuarioEncontrado);
            }
            catch (Exception ex)
            {
                return Response<UsuarioModel>.Error(Model.StatusCode.ExcepcionError, "Error: " + ex.Message);
            }
        }
    }
}
