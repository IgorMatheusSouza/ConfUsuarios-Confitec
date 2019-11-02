namespace WebAPI.Controllers
{
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;

    public class UsuarioController : Controller
    {
        /// <summary>
        /// Cria um usuário.
        /// </summary>
        /// <param name="request">Informações do usuário sendo criado.</param>
        /// <returns>Returns the asynchronous operation.</returns>
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Conflict)]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        public async Task<IActionResult> PostAsync([FromBody] string value)
        {
            return this.Accepted();
        }
    }
}
