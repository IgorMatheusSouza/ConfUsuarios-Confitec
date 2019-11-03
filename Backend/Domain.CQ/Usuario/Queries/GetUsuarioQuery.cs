namespace Domain.CQ.Usuario.Queries
{
    using MediatR;
    using Domain.Entity;

    public class GetUsuarioQuery  : IRequest<Usuario>
    {
        public GetUsuarioQuery(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
