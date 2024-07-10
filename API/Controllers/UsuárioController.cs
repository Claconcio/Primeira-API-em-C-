using API.Models;
using API.Repositorio.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuárioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _UsuarioRepositorio;

        public UsuárioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _UsuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
             List<UsuarioModel> usuarios = await _UsuarioRepositorio.BuscarTodosUsuarios();
                return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            UsuarioModel usuario = await _UsuarioRepositorio.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _UsuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel,int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuario = await _UsuarioRepositorio.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar(int id)
        {
            bool apagado = await _UsuarioRepositorio.Apagar(id);
            return Ok(apagado);
            //testegit
        }
    }
}


