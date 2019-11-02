namespace Application.Services
{
    using Application.Abstraction.Adapters;
    using Application.Abstraction.Services;
    using Application.DTO.Usuario;
    using Domain.CQ.Usuario.Queries;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class UsuarioService : ServiceBase, IUsuarioService
    {
        private readonly IUsuarioAdapter UsuarioAdapter;

        public UsuarioService(IMediator mediator, IUsuarioAdapter usuarioAdapter) : base(mediator)
        {
            this.UsuarioAdapter = usuarioAdapter;
        }

        public async Task<IEnumerable<UsuarioDTO>> GetTodosUsuariosAsync()
        {
           var usuarios = await this.Mediator.Send(new GetTodosUsuariosQuery());
            return this.UsuarioAdapter.Adapt(usuarios);
        }
    }
}
