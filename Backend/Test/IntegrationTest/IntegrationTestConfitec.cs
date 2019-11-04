namespace Tests
{
    using Application.Abstraction.Services;
    using Application.DTO.Usuario;
    using ConfitecProject;
    using IntegrationTest;
    using Lambda3.AspNetCore.Mvc.Testing;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;
    using WebAPI.Controllers;

    public class IntegrationTestConfitec
    {
        private WebApplicationFactory<Startup> webAppFactory;
        private IServiceScope scope;
        protected IServiceProvider serviceProvider;
        protected HttpClient client;
        public UsuarioController usuarioController;
        public GenerateUsuarioModel generateUsuarioModel => new GenerateUsuarioModel();

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            webAppFactory = new WebApplicationFactory<Startup>(port: 4972);
            webAppFactory.CreateDefaultClient();
            client = webAppFactory.CreateClient();
            scope = webAppFactory.Host.Services.CreateScope();
            serviceProvider = scope.ServiceProvider;
            usuarioController = new UsuarioController(serviceProvider.GetService<IUsuarioService>());
        }

        [Test]
        public async Task IntegrationCRUDTest()
        {
            // Create
            var usuario = generateUsuarioModel.usuarioDTOMock;
            await CreateAsync(usuario);
            var usuarioGet = (await GetAllAsync()).Where(x => x.Nome == usuario.Nome && x.Email == usuario.Email).LastOrDefault();
            Assert.NotNull(usuarioGet);

            // Update
            usuarioGet.Nome = $"{usuario.Nome} teste Update";
            await UpdateAsync(usuarioGet);
            usuarioGet = await GetByIdAsync(usuarioGet.Id);
            Assert.AreNotEqual(usuarioGet.Nome, usuario.Nome);

            // Delete
            await DeleteAsync(usuarioGet.Id);            
        }
        internal async Task<List<UsuarioDTO>> GetAllAsync()
        {
            var result = await usuarioController.GetAsync();
            var usuarioResult = ((OkObjectResult)result).Value;
            return (List<UsuarioDTO>)usuarioResult;
        }
        internal async Task<UsuarioDTO> GetByIdAsync(int id)
        {
            var result = await usuarioController.GetPeloIdAsync(id);
            var usuarioResult = ((OkObjectResult)result).Value;
            return (UsuarioDTO)usuarioResult;
        }

        internal async Task CreateAsync(UsuarioDTO usuarioViewModel)
        {
            var result = await usuarioController.PostAsync(usuarioViewModel);
            Assert.True(((OkResult)result).StatusCode.Equals(StatusCodes.Status200OK));
        }

        internal async Task UpdateAsync(UsuarioDTO usuarioViewModel)
        {
            var result = await usuarioController.PutAsync(usuarioViewModel);
            Assert.True(((OkResult)result).StatusCode.Equals(StatusCodes.Status200OK));
        }

        internal async Task DeleteAsync(int id)
        {
            var result = await usuarioController.DeleteAsync(id);
            Assert.True(((OkResult)result).StatusCode.Equals(StatusCodes.Status200OK));
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() {
            webAppFactory?.Dispose();
        }
    }
}
