namespace Domain.CQ.Usuario.Commands
{
    using Domain.Entity;
    using Domain.CQ.Abstraction;

    public class CadastrarUsuarioCommand : Command<Usuario>
    {
        public CadastrarUsuarioCommand(Usuario usuario) : base(usuario) { }
    }
}