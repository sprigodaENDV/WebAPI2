using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
//using AutoMapper;
using System;
using API2.Persistence.Entities;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.OpenApi.Models;

namespace API2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services/*, IApiVersionDescriptionProvider provider*/)
        {
            services.AddControllers();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddDbContext<LocalDBContext>(ServiceLifetime.Scoped);

            //services.AddApiVersioning(options =>
            //{
            //    options.ReportApiVersions = true;
            //    options.DefaultApiVersion = new ApiVersion(1, 0);
            //    options.AssumeDefaultVersionWhenUnspecified = true;
            //    //options.ApiVersionReader = ApiVersionReader.Combine(
            //    //                                                    new HeaderApiVersionReader("headerapiversion"),
            //    //                                                    new MediaTypeApiVersionReader("contentapiversion"),
            //    //                                                    new QueryStringApiVersionReader("queryapiversion")
            //    //                                                    );
            //});

            //services.AddVersionedApiExplorer(setup =>
            //{
            //    //setup.SubstitutionFormat = 
            //    //setup.GroupNameFormat = "'v'VVV";
            //    setup.SubstituteApiVersionInUrl = true;
            //});

            //services.AddSwaggerGen(g =>
            //{
            //    //var provider = services.BuildServiceProvider();
            //    //var service = provider.GetRequiredService<IApiVersionDescriptionProvider>();
            //    //foreach (ApiVersionDescription description in service.ApiVersionDescriptions)
            //    //{
            //    //    g.SwaggerDoc(description.ApiVersion.ToString() /*GroupName*/, new Microsoft.OpenApi.Models.OpenApiInfo
            //    //    {
            //    //        Title = "API1",
            //    //        Description = description.ApiVersion.ToString(),  /*GroupName*/
            //    //        Contact = new Microsoft.OpenApi.Models.OpenApiContact
            //    //        {
            //    //            Name = "Stanislav Prigoda",
            //    //            Email = "Stanislav.Prigoda@Endava.com"
            //    //        }
            //    //    });
            //    //}
            //});

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "WebAPI2",
                    Version = "v1",
                    Description = "Swagger didn't work with versioning",
                    Contact = new OpenApiContact
                    {
                        Name = "Stanislav Prigoda",
                        Email = "Stanislav.Prigoda@endava.com"
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStatusCodePages();
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
