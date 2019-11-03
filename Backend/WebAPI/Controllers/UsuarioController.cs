namespace WebAPI.Controllers
{
    using System.Net;
    using System.Threading.Tasks;
    using Application.Abstraction.Services;
    using Application.DTO.Usuario;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this._usuarioService = usuarioService;
        }

        /// <summary>
        /// Cria um usuário.
        /// </summary>
        /// <param name="request">Informações do usuário.</param>
        /// <returns>Retorna uma operação.</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]UsuarioDTO usuario)
        {
            await _usuarioService.CadastrarUsuarioAsync(usuario);
            return this.Ok();
        }

        /// <summary>
        /// Retorna todos usuario cadastrados.
        /// </summary>
        /// <returns> Retorna todos usuario cadastrados.</returns>
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAsync() => this.Ok(await _usuarioService.GetTodosUsuariosAsync());

        /// <summary>
        /// Obtem o usuário que corresponde ao id enviado.
        /// </summary>
        /// <returns> Retorna um usuario cadastrado.</returns>
        [HttpGet("{id}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetPeloIdAsync(int id) => this.Ok(await _usuarioService.GetUsuarioAsync(id));
    }
}
