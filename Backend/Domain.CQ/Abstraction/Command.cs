namespace Domain.CQ.Abstraction
{
    using MediatR;

    public abstract class Command<TMessage> : IRequest
    {
        protected Command(TMessage message)
        {
            this.Message = message;
        }

        public TMessage Message { get; private set; }
    }
}