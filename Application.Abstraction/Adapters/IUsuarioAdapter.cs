namespace Application.Abstraction.Adapters
{
    using Application.Abstraction.Adapters;
    using Application.DTO.Usuario;
    using Domain.Entity;

    public interface IUsuarioAdapter : IAdapter<UsuarioDTO, Usuario>, IAdapter<Usuario, UsuarioDTO>
    {
    }
}
