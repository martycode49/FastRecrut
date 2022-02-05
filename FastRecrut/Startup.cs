using FastRecrut.Business.Services.Abstract;
using FastRecrut.Business.Services.Concrete;
using FastRecrut.Core.DataAccess.Abstract;
using FastRecrut.Core.DataAccess.Concrete.EntityFramework;
using FastRecrut.DataAccess.Abstract;
using FastRecrut.DataAccess.Concrete;
using FastRecrut.DataAccess.Concrete.EntityFramework.Contexts;
using FastRecrut.Entities.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FastRecrut
{
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
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();

            // Ajouter les services auto Mapper, DI interfaces Repository, Services, UoW
            // AddScoped : chaque services gère une instance de UoW
            services.AddScoped(typeof(IEntityRepository<Agent>), typeof(EfEntityRepositoryBase<Agent, FastRecrutDbContext>));
            services.AddScoped(typeof(IEntityRepository<ParticipantData>), typeof(EfEntityRepositoryBase<ParticipantData, FastRecrutDbContext>));
            services.AddScoped(typeof(IEntityRepository<Quiz>), typeof(EfEntityRepositoryBase<Quiz, FastRecrutDbContext>));
            services.AddScoped(typeof(IEntityRepository<AgentParticipant>), typeof(EfEntityRepositoryBase<AgentParticipant, FastRecrutDbContext>));

            // Services 
            services.AddScoped<IAgentService, AgentManager>();
            //services.AddTransient<IParticipantService, ParticipantManager>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            // Configuration pour SQL Server
            services.AddDbContext<FastRecrutDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"].ToString(), o =>
                {
                    o.MigrationsAssembly("FastRecrut.DataAccess");
                });
            });

            services.AddControllers().AddNewtonsoftJson();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
            app.UseSwaggerUI();
        }
    }
}
