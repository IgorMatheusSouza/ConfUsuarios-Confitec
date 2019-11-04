namespace Domain.CQ.Usuario.QueryHandlers
{
    using Domain.CQ.Usuario.Queries;
    using MediatR;
    using System.Collections.Generic;
    using Domain.Model.Entity;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;

    public sealed class GetTodosUsuariosQueryHandler : IRequestHandler<GetTodosUsuariosQuery, IEnumerable<Usuario>>
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        public GetTodosUsuariosQueryHandler(IRepositoryFactory repositoryFactory)
        {
            this._usuarioRepository = repositoryFactory.GetRepository<Usuario>();
        }

        public async Task<IEnumerable<Usuario>> Handle(GetTodosUsuariosQuery request, CancellationToken cancellationToken)
        {
            var result = await this._usuarioRepository.GetPagedListAsync(pageSize: int.MaxValue);
            return result.Items.ToList();
        }
    }
}
