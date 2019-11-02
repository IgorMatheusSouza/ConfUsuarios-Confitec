namespace Application.Adapters.Usuario
{
    using System.Collections.Generic;
    using System.Linq;
    using Application.Abstraction.Adapters;
    using Application.DTO.Usuario;
    using Domain.Entity;

    public class UsuarioAdapter : IUsuarioAdapter
    {
        public Usuario Adapt(UsuarioDTO source)
        {
            return new Usuario(source.Id, source.Nome, source.Sobrenome, source.Email, source.DataNascimento, source.Escolaridade);
        }

        public UsuarioDTO Adapt(Usuario source)
        {
            return new UsuarioDTO(source.Id, source.Nome, source.Sobrenome, source.Email, source.DataNascimento, source.Escolaridade);
        }

        public IEnumerable<Usuario> Adapt(IEnumerable<UsuarioDTO> source) => source.Select(x => this.Adapt(x)).ToList();

        public IEnumerable<UsuarioDTO> Adapt(IEnumerable<Usuario> source) => source.Select(x => this.Adapt(x)).ToList();
    }
}
