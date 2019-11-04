namespace Domain.CQ.Usuario.Commands
{
    using Domain.Model.Entity;
    using Domain.CQ.Abstraction;

    public class CadastrarUsuarioCommand : Command<Usuario>
    {
        public CadastrarUsuarioCommand(Usuario usuario) : base(usuario) { }
    }
}