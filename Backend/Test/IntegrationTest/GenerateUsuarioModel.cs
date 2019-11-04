namespace IntegrationTest
{
    using Application.DTO.Usuario;
    using Bogus;
    using Domain.Model.Enumerators;

    public class GenerateUsuarioModel
    {
        public UsuarioDTO usuarioDTOMock
        {
            get => new Faker<UsuarioDTO>()
                .RuleFor(o => o.Nome, f => f.Person.FirstName)
                .RuleFor(o => o.Sobrenome, f => f.Person.LastName)
                .RuleFor(o => o.DataNascimento, f => f.Date.Past())
                .RuleFor(o => o.Email, f => f.Person.Email)
                .RuleFor(o => o.Escolaridade, f => (EscolaridadeEnum)f.Random.Number(1, 4))
                .Generate();
        }
    }
}
