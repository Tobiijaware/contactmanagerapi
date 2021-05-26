using ContactBook.Lib.Data;
using ContactManagerApiApp.Core.Abstractions;
using ContactManagerApiApp.Core.Repositories;
using ContactManagerApiApp.Data;
using ContactManagerApiApp.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagerApiApp
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
            //
            //services.AddCors();

            //add aplication dbcontext
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlite(Configuration.GetConnectionString("ConStr")));
            services.AddIdentity<IdentityUser, IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();

            //services and repos
            services.AddScoped<IUserRepo, UserRepositories>();
            services.AddAutoMapper(typeof(Startup));


            services.AddControllers();
            //jwt service

            services.AddAuthentication().AddJwtBearer(
               options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(
                           Encoding.UTF8.GetBytes(Configuration.GetSection("JWT:JWTSigningKey").Value)),
                       ValidateIssuer = false,
                       ValidateAudience = false
                   };

               });




            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ContactManagerApiApp", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, 
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ContactManagerApiApp v1"));
            }

            //admin, user and role seeder
            MyIdentityDataInitializer.SeedData(userManager, roleManager);
            

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseCors(options => options
            //    .WithOrigins(new[] {"http://localhost:5000","https://localhost:5001", "https://localhost:44343" })
            //    .AllowAnyHeader()
            //    .AllowAnyMethod()
            //    .AllowCredentials()
            //);


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //Seed.EnsurePopulated(app);
        }
    }
}
