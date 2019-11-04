namespace Application.Abstraction.Services
{
    using Application.DTO.Usuario;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDTO>> GetTodosUsuariosAsync();

        Task<UsuarioDTO> GetUsuarioAsync(int id);

        Task CadastrarUsuarioAsync(UsuarioDTO usuario);

        Task AtualizarUsuarioAsync(UsuarioDTO usuario);

        Task DeletarUsuarioAsync(int id);
    }
}
