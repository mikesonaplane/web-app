using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PDX.PBOT.App.Data.Options;

namespace PDX.PBOT.App.API
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
			var connectionString = Configuration.GetConnectionString("SqlServer");
			var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

			var storeOptions = new AppStoreOptions();
			services.AddSingleton(storeOptions);

			services
				.AddEntityFrameworkSqlServer()
				.AddDbContext<Data.Concrete.AppDbContext>((serviceProvider, options) =>
					options.UseSqlServer(connectionString, builder => builder.MigrationsAssembly(migrationsAssembly))
						.UseInternalServiceProvider(serviceProvider));

			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseMvc();
		}
	}
}
