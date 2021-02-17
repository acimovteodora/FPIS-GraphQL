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
            services.AddDbContext<FPISContext>(options => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FPIS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            //services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.AddTransient<IStudentLogic, StudentLogic>();
            services.AddTransient<ICityLogic, CityLogic>();
            services.AddTransient<ICompanyContactLogic, ContactCompanyLogic>();
            services.AddTransient<ICompanyLogic, CompanyLogic>();
            services.AddTransient<IEmployeeLogic, EmployeeLogic>();
            services.AddTransient<IEmployeePositionLogic, EmployeePositionLogic>();
            services.AddTransient<IExternalMentorContactLogic, ExternalMentorContactLogic>();
            services.AddTransient<IExternalMentorLogic, ExternalMentorLogic>();
            services.AddTransient<ILocationLogic, LocationLogic>();
            services.AddTransient<IPositionLogic, PositionLogic>();
            services.AddTransient<IProjectLogic, ProjectLogic>();
            services.AddTransient<IProjectPlanLogic, ProjectPlanLogic>();
            services.AddTransient<IProjectProposalLogic, ProjectProposalLogic>();
            services.AddTransient<IScientificAreaLogic, ScientificAreaLogic>();
            services.AddTransient<IApplicationLogic, ApplicationLogic>();
            services.AddTransient<IEngagementLogic, EngagementLogic>();
            services.AddTransient<IPhaseLogic, PhaseLogic>();
            services.AddTransient<ISkillLogic, SkillLogic>();
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
            //SCHEMA
            services.AddTransient<ISchema, RootSchema>();

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
