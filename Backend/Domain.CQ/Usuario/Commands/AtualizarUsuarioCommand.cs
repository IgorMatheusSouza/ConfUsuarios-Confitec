namespace Domain.CQ.Usuario.Commands
{
    using Domain.Model.Entity;
    using Domain.CQ.Abstraction;
    public class AtualizarUsuarioCommand : Command<Usuario>
    {
        public AtualizarUsuarioCommand(Usuario usuario) : base(usuario) { }
    }
}
