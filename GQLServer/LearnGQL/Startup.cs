using GraphQL.Server.Ui.Voyager;
using LearnGQL.Data;
using LearnGQL.GraphQL;
using LearnGQL.GraphQL.DataLoaders;
using LearnGQL.GraphQL.ExtendType;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.Tasks;

namespace LearnGQL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddDebug(); });
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<AppDbContext>(options =>
                options.UseSqlite("Filename=Uworld.db").UseLoggerFactory(MyLoggerFactory));
            services.AddScoped<IdentityDbContext>();
            services.AddCors();
            services.AddGraphQLServer()
                .AddFiltering()
                .AddSorting()
                .AddProjections()
                .AddAuthorization()
                .AddQueryType<Queries>()
                .AddTypeExtension<UserExtend>()
                .AddDataLoader<UserGroupCountBatchDataLoader>()
                .AddMutationType<Mutations>()
                .AddInMemorySubscriptions()
                .AddSubscriptionType<Subscriptions>();

            #region Authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };

                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        if (context.HttpContext.Request.Query.ContainsKey("token"))
                        {
                            context.Token = context.HttpContext.Request.Query["token"];
                        }
                        return Task.CompletedTask;
                    }
                };
            });
            #endregion

            #region Authorization
            services.AddAuthorization();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();
            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization();

            if (env.IsDevelopment())
                app.UseCors(builder => builder.WithOrigins("*")
                                .AllowAnyHeader()
                                .AllowAnyMethod());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });

                endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager();
        }
    }
}
