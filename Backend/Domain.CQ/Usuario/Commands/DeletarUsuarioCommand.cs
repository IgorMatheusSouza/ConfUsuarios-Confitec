namespace Domain.CQ.Usuario.Commands
{
    using Domain.CQ.Abstraction;
    using Domain.Model.Entity;

    public class DeletarUsuarioCommand : Command<int>
    {
        public DeletarUsuarioCommand(int id) : base(id) { }
    }
}