using Domain.Model.Enumerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Usuario
{
    public class UsuarioDTO
    {
        public UsuarioDTO(int id, string nome, string sobrenome, string email, DateTime dataNascimento, EscolaridadeEnum escolaridade)
        {
            Id = id;
            Nome = nome;
            Sobrenome = sobrenome;
            Email = email;
            DataNascimento = dataNascimento;
            Escolaridade = escolaridade;
        }

        public int Id { get; set; }

        public string Nome { get;  set; }

        public string Sobrenome { get;  set; }

        public string Email { get;  set; }

        public DateTime DataNascimento { get;  set; }

        public EscolaridadeEnum Escolaridade { get; set; }
    }
}
