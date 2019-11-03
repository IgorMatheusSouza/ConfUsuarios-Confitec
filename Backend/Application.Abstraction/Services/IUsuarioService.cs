namespace Application.Abstraction.Services
{
    using Application.DTO.Usuario;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> GetTodosUsuariosAsync();

        Task CadastrarUsuario(UsuarioDTO usuario);
    }
}
