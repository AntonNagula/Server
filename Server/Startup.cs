using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Server.BusinessAbstraction;
using Server.BusinessManagers;
using Server.DatabaseAbstraction;
using Server.DatabaseAbstraction.Repositories;
using Server.DatabaseInfrastructure;
using Server.DatabaseInfrastructure.Repositories;
using Server.Managers;
using Server.Models;
using Server.Services;

namespace Server
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
            services.AddCors();

            services.AddJWTAuthService(Configuration);

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            services.AddSingleton<JWTManager>();

            services.AddDbContext<ProjectDbContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")
                   )
               );

            services.AddTransient<IGenericRepository<Proposal>,Repository<Proposal>>();
            services.AddTransient<IGenericRepository<Payment>, Repository<Payment>>();
            services.AddTransient<IGenericRepository<Budget>, Repository<Budget>>();
            services.AddTransient<IGenericRepository<BudgetTemplate>, Repository<BudgetTemplate>>();
            services.AddTransient<IGenericRepository<User>, Repository<User>>();

            services.AddTransient<IUnitOfWork,UnitOfWork>();

            services.AddTransient<IProposalService, ProposalService>();
            services.AddTransient<IBudgetService, BudgetService>();
            services.AddTransient<IBudgetTemplateService, BudgetTemplateService>();
            //services.AddTransient<IGenericRepository<BudgetTemplate>, Repository<BudgetTemplate>>();
            //services.AddTransient<IGenericRepository<User>, Repository<User>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
