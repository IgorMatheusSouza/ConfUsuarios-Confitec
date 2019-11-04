namespace Domain.CQ.Usuario.CommandHandlers
{
    using Domain.CQ.Usuario.Commands;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using Domain.Model.Entity;
    using System.Threading;
    using System.Threading.Tasks;

    public class AtualizarUsuarioCommandHandler : IRequestHandler<AtualizarUsuarioCommand>
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        private readonly IUnitOfWork _unitOfWork;

        public AtualizarUsuarioCommandHandler(IRepositoryFactory repositoryFactory, IUnitOfWork unitOfWork)
        {
            this._usuarioRepository = repositoryFactory.GetRepository<Usuario>();
            this._unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            this._usuarioRepository.Update(request.Message);
            await this._unitOfWork.SaveChangesAsync();
            return Unit.Task.Result;
        }
    }
}
