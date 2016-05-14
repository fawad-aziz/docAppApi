using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using docAppDomain;
using Microsoft.AspNet.Mvc.Formatters;
using Newtonsoft.Json;
using docAppSqliteProvider;
using AutoMapper;
using Newtonsoft.Json.Serialization;

namespace docAppApi
{
	public class Startup
	{
		private MapperConfiguration _mapperConfiguration { get; set; }
		
		public Startup(IHostingEnvironment env)
		{
			// Set up configuration sources.
			var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables();
			_mapperConfiguration = new MapperConfiguration(cfg => {
				cfg.AddProfile(new AutoMapperProfileConfiguration());
			});
			
			this.Configuration = builder.Build();
		}

		public IConfigurationRoot Configuration { get; set; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Add framework services.

			// Use a SQLite database
			services.AddEntityFramework().AddSqlite().AddDbContext<docAppContext>();			
			services.AddScoped<IDataAccessProvider, SqliteProvider>();

			//Use PostgreSql
			//services.AddEntityFramework().AddNpgsql().AddDbContext<docAppContext>();
			//services.AddScoped<IDataAccessProvider, docAppDomain.PostgreSqlProvider>();
			
			services.AddSingleton<IMapper>(sp => _mapperConfiguration.CreateMapper());

			var jsonOutputFormatter = new JsonOutputFormatter
			{
				SerializerSettings =
												  new JsonSerializerSettings
												  {
													  ReferenceLoopHandling =
															  ReferenceLoopHandling.Ignore,
														ContractResolver = new CamelCasePropertyNamesContractResolver()
												  }
			};
			services.AddCors();
			services.AddMvc(
				options =>
				{
					options.OutputFormatters.Clear();
					options.OutputFormatters.Insert(0, jsonOutputFormatter);
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(this.Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			app.UseIISPlatformHandler();
			app.UseStaticFiles();
			app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
			app.UseMvc();
		}

		// Entry point for the application.
		public static void Main(string[] args) => WebApplication.Run<Startup>(args);
	}
}