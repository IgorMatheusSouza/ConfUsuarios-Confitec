namespace WebAPI.ExceptionHandler
{
    using System;

    public class DadosInvalidosException : Exception
    {
        public DadosInvalidosException(string message) : base(message) { }
    }
}
