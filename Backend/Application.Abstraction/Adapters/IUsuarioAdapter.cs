namespace Application.Abstraction.Adapters
{
    using Application.Abstraction.Adapters;
    using Application.DTO.Usuario;
    using Domain.Entity;
    using System.Collections.Generic;

    public interface IUsuarioAdapter : 
        IAdapter<UsuarioDTO, Usuario>, 
        IAdapter<Usuario, UsuarioDTO>, 
        IAdapter<IEnumerable<UsuarioDTO>, IEnumerable<Usuario>>,
        IAdapter<IEnumerable<Usuario>, IEnumerable<UsuarioDTO>>
    {
    }
}
