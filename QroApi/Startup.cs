using QroApi.BLL;
using QroApi.DLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace QroApi
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            #region[1. START : APPLICATION KEYS FETCH FROM APPSETTING.JSON]
            SiteKeys.Configure(Configuration.GetSection("AppSettings"));
            var key = Encoding.ASCII.GetBytes(SiteKeys.Token);
            #endregion

            #region[2. START : ADDED SESSION FUNCTIONALITY WITH TIME LIMIT OF 60 MIN IF IDEAL]
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);
            });
            #endregion

            SQLHelper.ConnectionString = Configuration["ConnectionStrings:SMSQLConnection"];

            //services.AddDbContext<JudgeMyTasteContext>(options => options.UseSqlServer(Configuration.GetConnectionString("SMSQLConnection")));

            #region[4. START : DISIABLED END POINT ROUTING , INJECTED FLUENT VALIDATOR AND ADDED RUNTIME COMPILATION FEATURE]
            services.AddMvc(option =>
            {
                option.EnableEndpointRouting = false;
            }).AddRazorRuntimeCompilation();
            //.AddNewtonsoftJson(o =>
            //{
            //    o.SerializerSetting.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            //})
            //.AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            #endregion
            services.AddMvc().AddNewtonsoftJson();

            #region[3. START : JWT TOKEN USES , AUTHENTICATION AND AUTHORIZATION]
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(token =>
                {
                    token.RequireHttpsMetadata = false;
                    token.SaveToken = true;
                    token.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidIssuer = SiteKeys.Domain,
                        ValidateAudience = true,
                        ValidAudience = SiteKeys.ApiDomain,
                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #endregion

            #region[4. START : SERVICES INJECTOR]
            new ServiceInjector(services);
            #endregion

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    app.UseHsts();
            //}
            app.UseSession();
            app.UseHttpsRedirection();

            app.UseCookiePolicy();
            app.UseStaticFiles();

            #region[START : JWT TOKEN USES , AUTHENTACTION AND AUTHORIZATION]
            app.Use(async (context, next) =>
            {
                var JWToken = context.Session.GetString("JWToken");
                if (!string.IsNullOrEmpty(JWToken))
                {
                    context.Request.Headers.Add("Authorization", "Bearer " + JWToken);
                }
                await next();
            });
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();

            #endregion
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                 name: "areas",
                 template: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        #region[START : FLUENT VALIDATION IMPLEMENTATION]
        public class ValidatorActionFilter : IActionFilter
        {
            public void OnActionExecuting(ActionExecutingContext filterContext)
            {
                if (!filterContext.ModelState.IsValid)
                {
                    filterContext.Result = new BadRequestObjectResult(filterContext.ModelState);
                }
            }

            public void OnActionExecuted(ActionExecutedContext filterContext)
            {

            }
        }
        #endregion
    }
}

