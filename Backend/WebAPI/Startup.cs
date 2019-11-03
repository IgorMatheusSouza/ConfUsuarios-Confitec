namespace ConfitecProject
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using MediatR;
    using Infrastructure.Data.Context;
    using Microsoft.EntityFrameworkCore;
    using Application.Abstraction.Services;
    using Application.Services;
    using Application.Abstraction.Adapters;
    using Application.Adapters.Usuario;
    using System.Collections.Generic;
    using Domain.CQ.Usuario.Queries;
    using Domain.CQ.Usuario.QueryHandlers;
    using Domain.Entity;
    using Domain.CQ.Usuarios.CommandHandlers;
    using Domain.CQ.Usuario.Commands;
    using Swashbuckle.AspNetCore.Swagger;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "Dev",
                    builder =>
                    {
                        builder
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                        .AllowCredentials();
                    });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMediatR(typeof(Startup));

            var conexaoBase = Configuration["SqlServerSetting:ConnectionString"];
            services.AddDbContext<ConfitecContext>(options => options.UseSqlServer(conexaoBase)).AddUnitOfWork<ConfitecContext>();

            services.AddTransient<IUsuarioService, UsuarioService>()
                    .AddTransient<IUsuarioAdapter, UsuarioAdapter>()
                    .AddTransient<IUsuarioService, UsuarioService>()
                    .AddScoped<IRequestHandler<GetTodosUsuariosQuery, IEnumerable<Usuario>>, GetTodosUsuariosQueryHandler>()
                    .AddScoped<IRequestHandler<GetUsuarioQuery, Usuario>, GetUsuarioQueryHandler>()
                    .AddScoped<IRequestHandler<CadastrarUsuarioCommand, Unit>, CadastrarUsuarioCommandHandler>();

            services.AddScoped<DbContext, ConfitecContext>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "ConfUsuarios", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseCors("Dev");
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ConfUsuarios");
            });
        }
    }
}
