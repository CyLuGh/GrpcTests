using GrpcTestService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GrpcTestService
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices( IServiceCollection services )
        {
            services.AddRouting( options => options.LowercaseUrls = true );
            services.AddControllers();

            //Add API versioning to application
            services.AddApiVersioning(
                options =>
                {
                    //Reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                    options.ReportApiVersions = true;

                    options.AssumeDefaultVersionWhenUnspecified = true;
                } );

            services.AddVersionedApiExplorer(
                options =>
                {
                    //Add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
                    //NOTE: the specified format code will format the version as "'v'major[.minor][-status]"
                    options.GroupNameFormat = "'v'VVV";

                    //NOTE: this option is only necessary when versioning by url segment. the SubstitutionFormat
                    //can also be used to control the format of the API version in route templates
                    options.SubstituteApiVersionInUrl = true;
                } );

            services.AddGrpc();
            services.AddGrpcHttpApi();

            services.AddSwaggerGen( c =>
            {
                c.SwaggerDoc( "v1" , new OpenApiInfo { Title = "My POC API" , Version = "v1" } );
            } );
            services.AddGrpcSwagger();

            // Registers the service with a scoped lifetime
            services.AddScoped<IMicroPoc , MicroPocService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure( IApplicationBuilder app , IWebHostEnvironment env )
        {
            if ( env.IsDevelopment() )
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI( c =>
            {
                c.SwaggerEndpoint( "/swagger/v1/swagger.json" , "My POC API V1" );
            } );

            app.UseRouting();

            app.UseEndpoints( endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGrpcService<MicroPocService>();

                endpoints.MapGet( "/" , async context =>
                {
                    await context.Response.WriteAsync( "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909" );
                } );
            } );
        }
    }
}
