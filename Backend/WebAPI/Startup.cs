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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddMediatR(typeof(Startup));

            var conexaoBase = Configuration["SqlServerSetting:ConnectionString"];
            services.AddDbContext<ConfitecContext>(options => options.UseSqlServer(conexaoBase)).AddUnitOfWork<ConfitecContext>();

            services.AddTransient<IUsuarioService, UsuarioService>()
                    .AddTransient<IUsuarioAdapter, UsuarioAdapter>()
                    .AddTransient<IUsuarioService, UsuarioService>()
                    .AddScoped<IRequestHandler<GetTodosUsuariosQuery, IEnumerable<Usuario>>, GetTodosUsuariosQueryHandler>();

            services.AddScoped<DbContext, ConfitecContext>();
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
