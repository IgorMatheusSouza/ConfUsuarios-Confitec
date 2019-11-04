namespace Application.Adapters.Usuario
{
    using System.Collections.Generic;
    using System.Linq;
    using Application.Abstraction.Adapters;
    using Application.DTO.Usuario;
    using Domain.Model.Entity;

    public class UsuarioAdapter : IUsuarioAdapter
    {
        public Usuario Adapt(UsuarioDTO source) => new Usuario(source.Id, source.Nome, source.Sobrenome, source.Email, source.DataNascimento, source.Escolaridade, source.Imagem);

        public UsuarioDTO Adapt(Usuario source) => new UsuarioDTO(source.Id, source.Nome, source.Sobrenome, source.Email, source.DataNascimento, source.Escolaridade, source.Imagem);

        public IEnumerable<Usuario> Adapt(IEnumerable<UsuarioDTO> source) => source.Select(x => this.Adapt(x)).ToList();

        public IEnumerable<UsuarioDTO> Adapt(IEnumerable<Usuario> source) => source.Select(x => this.Adapt(x)).ToList();
    }
}
