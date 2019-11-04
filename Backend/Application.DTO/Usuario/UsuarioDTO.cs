namespace Application.DTO.Usuario
{
    using Domain.Model.Enumerators;
    using System;
    using System.Text.RegularExpressions;
    using WebAPI.ExceptionHandler;

    public class UsuarioDTO : BaseDTO
    {
        public UsuarioDTO(int id, string nome, string sobrenome, string email, DateTime dataNascimento, EscolaridadeEnum escolaridade, string imagem)
        {
            this.Id = id;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Email = email;
            this.DataNascimento = dataNascimento;
            this.Escolaridade = escolaridade;
            this.Imagem = imagem;
        }

        public string Nome { get; private set; }

        public string Sobrenome { get; private set; }

        public string Email { get; private set; }

        public DateTime DataNascimento { get; private set; }

        public EscolaridadeEnum Escolaridade { get; private set; }

        public string Imagem { get; set; }

        public void ValidarDados()
        {
            if (this.DataNascimento > DateTime.Now)
            {
                throw new DadosInvalidosException("Data de nascimento não pode ser maior que a data atual.");
            }

            Regex regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"+"@"+@"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            if (!regex.Match(this.Email).Success)
            {
                throw new DadosInvalidosException("E-mail está em um formato inválido.");
            }
        }
    }
}