using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Services;
using Data.Repositories;
using Domain.Contracts.Repositories;
using Domain.Contracts.Services;
using Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace WebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Repositories
            services.AddSingleton(typeof(IJobApplicantRepository), typeof(JobApplicantRepository));
            services.AddSingleton(typeof(IJobFeedBackRepository), typeof(JobFeedBackRepository));
            services.AddSingleton(typeof(IJobFeedBackSkillRepository), typeof(JobFeedBackSkillRepository));
            services.AddSingleton(typeof(IJobInterviewRepository), typeof(JobInterviewRepository));
            services.AddSingleton(typeof(IJobRepository), typeof(JobRepository));
            services.AddSingleton(typeof(IJobSkillRepository), typeof(JobSkillRepository));
            services.AddSingleton(typeof(ISkillRepository), typeof(SkillRepository));
            services.AddSingleton(typeof(IUserRepository), typeof(UserRepository));
            services.AddSingleton(typeof(IUserSkillRepository), typeof(UserSkillRepository));
            services.AddSingleton(typeof(ITeamRepository), typeof(TeamRepository));

            //Services
            services.AddSingleton(typeof(IJobApplicantService), typeof(JobApplicantService));
            services.AddSingleton(typeof(IJobFeedBackService), typeof(JobFeedBackService));
            services.AddSingleton(typeof(IJobInterviewService), typeof(JobInterviewService));
            services.AddSingleton(typeof(IJobService), typeof(JobService));
            services.AddSingleton(typeof(ISkillService), typeof(SkillService));
            services.AddSingleton(typeof(IUserService), typeof(UserService));
            services.AddSingleton(typeof(ITeamService), typeof(TeamService));
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
                app.UseHsts();
            }

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
