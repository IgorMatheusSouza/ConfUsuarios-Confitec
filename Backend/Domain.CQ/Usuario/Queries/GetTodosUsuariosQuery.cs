namespace Domain.CQ.Usuario.Queries
{
    using MediatR;
    using System.Collections.Generic;
    using Domain.Model.Entity;

    public class GetTodosUsuariosQuery : IRequest<IEnumerable<Usuario>>
    {
    }
}
