using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Propellerhead.Assignment.MarceloFerraz.Core.Customers;
using Propellerhead.Assignment.MarceloFerraz.Core.Customers.Data;
using Propellerhead.Assignment.MarceloFerraz.Core.Notes;
using Propellerhead.Assignment.MarceloFerraz.Core.Notes.Data;
using Propellerhead.Assignment.MarceloFerraz.Core.Search;

namespace Propellerhead.Assignment.MarceloFerraz
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMemoryCache();

            services
                .AddMvcCore()
                .AddJsonFormatters();

            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<INotesService, NotesService>();

            var cnnString =
                configuration["connectionString"];

            services.AddSingleton<ICustomerRepository>(
                r => new CustomerRepository(cnnString));

            services.AddSingleton<INotesRepository>(
                r => new NotesRepository(cnnString));

            services.AddSingleton<ISearchRepository>(
                r => new SearchRepository(cnnString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
