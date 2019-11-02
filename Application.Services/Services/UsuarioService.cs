namespace Application.Services
{
    using Application.Abstraction.Services;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class UsuarioService : ServiceBase, IUsuarioService
    {
        public UsuarioService(IMediator mediator) : base(mediator)
        {
        }

        public Task<string> GetTodosUsuario()
        {
            throw new NotImplementedException();
        }
    }
}
