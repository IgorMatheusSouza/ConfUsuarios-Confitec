namespace Application.Abstraction.Services
{
    using System.Threading.Tasks;

    public interface IUsuarioService
    {
        Task<string> GetTodosUsuario();
    }
}
