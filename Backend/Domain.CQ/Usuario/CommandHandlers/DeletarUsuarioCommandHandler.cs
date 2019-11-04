namespace Domain.CQ.Usuario.CommandHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.CQ.Usuario.Commands;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Domain.Model.Entity;
    using Domain.Model.Enumerators;

    public class DeletarUsuarioCommandHandler : IRequestHandler<DeletarUsuarioCommand>
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        private readonly IUnitOfWork _unitOfWork;

        public DeletarUsuarioCommandHandler(IRepositoryFactory repositoryFactory, IUnitOfWork unitOfWork)
        {
            this._usuarioRepository = repositoryFactory.GetRepository<Usuario>();
            this._unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeletarUsuarioCommand request, CancellationToken cancellationToken)
        {
            this._usuarioRepository.Delete(new Usuario(request.Message));
            await this._unitOfWork.SaveChangesAsync();
            return Unit.Task.Result;
        }
    }
}
