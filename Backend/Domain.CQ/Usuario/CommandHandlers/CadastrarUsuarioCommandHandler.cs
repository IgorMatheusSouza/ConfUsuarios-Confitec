namespace Domain.CQ.Usuarios.CommandHandlers
{
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.CQ.Usuario.Commands;
    using Domain.Entity;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class CadastrarUsuarioCommandHandler : IRequestHandler<CadastrarUsuarioCommand>
    {
        private readonly IRepository<Usuario> _usuarioRepository;

        private readonly IUnitOfWork _unitOfWork;

        public CadastrarUsuarioCommandHandler(IRepositoryFactory repositoryFactory, IUnitOfWork unitOfWork)
        {
            this._usuarioRepository = repositoryFactory.GetRepository<Usuario>();
            this._unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CadastrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            await this._usuarioRepository.InsertAsync(request.Message);
            await this._unitOfWork.SaveChangesAsync();
            return Unit.Task.Result;
        }
    }
}