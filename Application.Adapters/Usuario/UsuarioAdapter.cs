namespace Application.Adapters.Usuario
{
    using Application.Abstraction.Adapters;
    using Application.DTO.Usuario;
    using System;
    using Domain.Entity;

    public class UsuarioAdapter : IUsuarioAdapter
    {
        public Usuario Adapt(UsuarioDTO source)
        {
            return new Usuario(source.Id, source.Nome, source.Sobrenome, source.Email, source.DataNascimento, source.Escolaridade);
        }

        public UsuarioDTO Adapt(Usuario source)
        {
            throw new NotImplementedException();
        }
    }
}
