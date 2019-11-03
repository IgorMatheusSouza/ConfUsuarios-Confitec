namespace Domain.CQ.Usuario.QueryHandlers
{

    using Domain.CQ.Usuario.Queries;
    using MediatR;
    using Domain.Entity;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;

    public class GetUsuarioQueryHandler : IRequestHandler<GetUsuarioQuery, Usuario>
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        public GetUsuarioQueryHandler(IRepositoryFactory repositoryFactory)
        {
            this._usuarioRepository = repositoryFactory.GetRepository<Usuario>();
        }

        public async Task<Usuario> Handle(GetUsuarioQuery request, CancellationToken cancellationToken) => await this._usuarioRepository.FindAsync(request.Id);
    }
}
