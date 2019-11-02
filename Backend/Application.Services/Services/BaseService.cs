namespace Application.Services
{
    using MediatR;

    public abstract class ServiceBase
    {
        protected ServiceBase(IMediator mediator)
        {
            this.Mediator = mediator;
        }

        protected IMediator Mediator { get; private set; }
    }
}
