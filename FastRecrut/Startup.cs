using System.Text;
using System.Threading.Tasks;
using FastRecrut.Business.Services.Abstract;
using FastRecrut.Business.Services.Concrete;
using FastRecrut.Core.DataAccess.Abstract;
using FastRecrut.Core.DataAccess.Concrete.EntityFramework;
using FastRecrut.Core.Services.Abstract;
using FastRecrut.DataAccess.Abstract;
using FastRecrut.DataAccess.Concrete;
using FastRecrut.DataAccess.Concrete.EntityFramework;
using FastRecrut.DataAccess.Concrete.EntityFramework.Contexts;
using FastRecrut.Entities.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                { Title = "Fast Recruitment API", Description = "DotNet Core Api - with swagger" });
            });

            // Auto Mapper
            services.AddAutoMapper(typeof(Startup));

            // AddScoped : chaque services gère une instance de UoW
            // ceci evite de redéfinir toutes les contrats d'interface (les méthodes sont définies dans EfEntityRepository<RepoName>)
            services.AddScoped(typeof(IEntityRepository<Agent>), typeof(EfEntityRepositoryBase<Agent, FastRecrutDbContext>));
            services.AddScoped(typeof(IEntityRepository<Role>), typeof(EfEntityRepositoryBase<Role, FastRecrutDbContext>));
            services.AddScoped(typeof(IEntityRepository<Quiz>), typeof(EfEntityRepositoryBase<Quiz, FastRecrutDbContext>));
            services.AddScoped(typeof(IService<>), typeof(ManagerBase<>));

            // Services 
            services.AddScoped<IAgentService, AgentManager>();
            services.AddScoped<IAgentDal, EfAgentDal>();
            services.AddScoped<IRoleService, RoleManager>();
            services.AddScoped<IRoleDal, EfRoleDal>();
            services.AddScoped<IQuizService, QuizManager>();
            services.AddScoped<IQuizDal, EfQuizDal>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Configuration pour SQL Server
            services.AddDbContext<FastRecrutDbContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"].ToString(), o =>
                {
                    o.MigrationsAssembly("FastRecrut.DataAccess");
                });
            });

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json
                .ReferenceLoopHandling.Ignore
               );

            //Jwt
            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("AppSettings:Secret"));
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        var userService = context.HttpContext.RequestServices.GetRequiredService<IAgentService>();
                        var userId = int.Parse(context.Principal.Identity.Name);
                        var user = userService.GetByIdAgent(userId);
                        if (user == null)
                        {
                            // return unauthorized if user no longer exists
                            context.Fail("Unauthorized");
                        }
                        return Task.CompletedTask;
                    }
                };
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

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

            app.UseAuthentication();

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
