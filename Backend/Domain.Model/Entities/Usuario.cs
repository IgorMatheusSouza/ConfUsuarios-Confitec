namespace Domain.Model.Entity
{
    using Domain.Model.Abstractions;
    using Domain.Model.Enumerators;
    using System;

    public class Usuario : Entity<int>
    {
        public Usuario(int id) : base(id) { }

        public Usuario(int id, string nome, string sobrenome, string email, DateTime dataNascimento, EscolaridadeEnum escolaridade, string imagem) : base(id)
        {
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

        public string Imagem { get; private set; }
    }
}