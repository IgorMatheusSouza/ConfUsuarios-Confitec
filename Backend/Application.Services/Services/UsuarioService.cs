namespace Application.Services
{
    using Application.Abstraction.Adapters;
    using Application.Abstraction.Services;
    using Application.DTO.Usuario;
    using Domain.CQ.Usuario.Commands;
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

        public async Task AtualizarUsuarioAsync(UsuarioDTO usuario)
        {
            usuario.ValidarDados();
            await this.Mediator.Send(new AtualizarUsuarioCommand(this.UsuarioAdapter.Adapt(usuario)));
        }

        public async Task CadastrarUsuarioAsync(UsuarioDTO usuario)
        {
            usuario.ValidarDados();
            await this.Mediator.Send(new CadastrarUsuarioCommand(this.UsuarioAdapter.Adapt(usuario)));
        }

        public async Task DeletarUsuarioAsync(int id)
        {
            await this.Mediator.Send(new DeletarUsuarioCommand(id));
        }

        public async Task<IEnumerable<UsuarioDTO>> GetTodosUsuariosAsync()
        {
           var usuarios = await this.Mediator.Send(new GetTodosUsuariosQuery());
           return this.UsuarioAdapter.Adapt(usuarios);
        }

        public async Task<UsuarioDTO> GetUsuarioAsync(int id)
        {
            var usuario = await this.Mediator.Send(new GetUsuarioQuery(id));
            return this.UsuarioAdapter.Adapt(usuario);
        }
    }
}