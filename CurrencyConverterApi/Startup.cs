using CurrencyConverterApi.Repositories;
using CurrencyConverterApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverterApi
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
      services.AddSwaggerGen();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
          Version = "v1",
          Title = "Currency Convertor Api",
          Description = "A test Api for currency conversion",
        });
      });
      services.AddHttpClient("openExchangeApiUrl", c =>
      {
          c.BaseAddress = new Uri("https://api.apilayer.com/"); 
          c.DefaultRequestHeaders.Add("apikey", "xtz773lyy6DpzYSilg5Bz7DYznkQpzNK"); // ideally this should be kept in secrets manager and accessed via that
       });

      services.AddScoped<ICurrencyConverterService, CurrencyConverterService>();
      services.AddScoped<ICurrencyConverterRepository, CurrencyConverterRepository>();
      services.AddControllers();
      
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseSwagger();
      app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Showing API V1");
      });

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
