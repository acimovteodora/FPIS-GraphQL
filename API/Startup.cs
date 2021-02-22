using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer;
using Logic;
using Logic.ILogic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using GraphQL.Types;
using API.Schema;
using API.Query;
using API.Type;
using GraphQL.Server;
using GraphiQl;
using API.Mutation;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace API
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
            services.AddControllers().AddNewtonsoftJson(s =>
            {
                s.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });
            services.AddControllers();
            services.AddDbContext<FPISContext>(options => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FPIS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"),
            ServiceLifetime.Transient);
            //services.AddDbContext<FPISContext>(options => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FPIS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            //services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.AddScoped<IStudentLogic, StudentLogic>();
            services.AddScoped<ICityLogic, CityLogic>();
            services.AddScoped<ICompanyContactLogic, ContactCompanyLogic>();
            services.AddScoped<ICompanyLogic, CompanyLogic>();
            services.AddScoped<IEmployeeLogic, EmployeeLogic>();
            services.AddScoped<IEmployeePositionLogic, EmployeePositionLogic>();
            services.AddScoped<IExternalMentorContactLogic, ExternalMentorContactLogic>();
            services.AddScoped<IExternalMentorLogic, ExternalMentorLogic>();
            services.AddScoped<ILocationLogic, LocationLogic>();
            services.AddScoped<IPositionLogic, PositionLogic>();
            services.AddScoped<IProjectLogic, ProjectLogic>();
            services.AddScoped<IProjectPlanLogic, ProjectPlanLogic>();
            services.AddScoped<IProjectProposalLogic, ProjectProposalLogic>();
            services.AddScoped<IScientificAreaLogic, ScientificAreaLogic>();
            services.AddScoped<IApplicationLogic, ApplicationLogic>();
            services.AddScoped<IEngagementLogic, EngagementLogic>();
            services.AddScoped<IPhaseLogic, PhaseLogic>();
            services.AddScoped<ISkillLogic, SkillLogic>();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(
                            Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            //GraphQl
            //services.Configure<KestrelServerOptions>(o => o.AllowSynchronousIO = true);

            //TYPE
            services.AddTransient<StudentType>();
            services.AddTransient<SkillType>();
            services.AddTransient<CompanyType>();
            services.AddTransient<PhaseType>();
            services.AddTransient<ApplicationType>();
            services.AddTransient<ProjectProposalType>();
            services.AddTransient<ProjectType>();
            services.AddTransient<ProjectPlanType>();
            services.AddTransient<EmployeeType>();
            services.AddTransient<EngagementType>();
            services.AddTransient<ApplicationInputType>();
            services.AddTransient<EmployeeInputType>();
            services.AddTransient<SkillInputType>();
            services.AddTransient<EngagementInputType>();
            services.AddTransient<PhaseInputType>();
            services.AddTransient<ProjectPlanInputType>();
            //QUERY
            services.AddTransient<ApplicationQuery>();
            services.AddTransient<CompanyQuery>();
            services.AddTransient<EmployeeQuery>();
            services.AddTransient<PhaseQuery>();
            services.AddTransient<ProjectPlanQuery>();
            services.AddTransient<ProjectProposalQuery>();
            services.AddTransient<ProjectQuery>();
            services.AddTransient<SkillQuery>();
            services.AddTransient<StudentQuery>();
            services.AddTransient<EngagementQuery>();
            services.AddTransient<RootQuery>();
            //MUTATION
            services.AddTransient<ApplicationMutation>();
            services.AddTransient<ProjectPlanMutation>();
            services.AddTransient<RootMutation>();
            //SCHEMA
            services.AddScoped<ISchema, RootSchema>();

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = false;
            }).AddSystemTextJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, FPISContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();
            //app.UseCors(x => x
            //    .AllowAnyMethod()
            //    .AllowAnyHeader()
            //    .SetIsOriginAllowed(origin => true) // allow any origin
            //    .AllowCredentials());

            //app.UseRouting();
            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
            //app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthentication();
            dbContext.Database.EnsureCreated();

            app.UseGraphiQl("/graphql"); //znaci da mi je poziv endpointa: localhost/5000/graphql

            app.UseGraphQL<ISchema>();

        }
    }
}
