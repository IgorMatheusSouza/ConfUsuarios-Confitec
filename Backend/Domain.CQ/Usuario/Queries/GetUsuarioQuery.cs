namespace Domain.CQ.Usuario.Queries
{
    using MediatR;
    using Domain.Model.Entity;

    public class GetUsuarioQuery  : IRequest<Usuario>
    {
        public GetUsuarioQuery(int id)
        {
            this.Id = id;
        }

        public int Id { get; set; }
    }
}
