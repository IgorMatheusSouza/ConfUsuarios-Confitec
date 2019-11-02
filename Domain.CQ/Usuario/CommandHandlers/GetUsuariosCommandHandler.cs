namespace Domain.CQ.Usuarios.CommandHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.CQ.Usuario.Commands;
    using Domain.Entity;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetUsuariosCommandHandler : IRequestHandler<GetUsuariosCommand, string>
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        public Task<string> Handle(GetUsuariosCommand request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
