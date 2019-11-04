namespace Application.DTO
{
    public abstract class BaseDTO
    {
        public int Id { get; set; }

        protected const string MensagemErro = " deve ser preenchido corretamente.";
    }
}
