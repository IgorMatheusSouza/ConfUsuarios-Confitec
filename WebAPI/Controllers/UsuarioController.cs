namespace WebAPI.Controllers
{
    using System.Net;
    using System.Threading.Tasks;
    using Application.Abstraction.Services;
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
        /// <returns>Returns the asynchronous operation.</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        public async Task<IActionResult> PostAsync([FromBody] string value)
        {
            return this.Accepted();
        }

        /// <summary>
        /// Retorna todos usuario cadastrados.
        /// </summary>
        /// <returns> Retorna todos usuario cadastrados.</returns>
        [HttpGet]
        [Produces("application/json")]
        public async Task<IActionResult> GetAsync() => this.Ok(await _usuarioService.GetTodosUsuariosAsync());
    }
}
