namespace Domain.CQ.Usuario.Queries
{
    using MediatR;
    using System.Collections.Generic;
    using Domain.Entity;

    public class GetTodosUsuariosQuery : IRequest<IEnumerable<Usuario>>
    {
    }
}
