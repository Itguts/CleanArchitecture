using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Eaconomy.API.Middlewares;
using Eaconomy.Application;
using Eaconomy.Infrastructure;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Serilog;
var builder = WebApplication.CreateBuilder(args);

//Adding Services to the Layers

builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureInfrastructureServices(builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
IApiVersionDescriptionProvider provider = null;

builder.Services.AddSwaggerGen(opt =>
{
   

    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
    builder.Services.AddApiVersioning( option =>
    {
        option.AssumeDefaultVersionWhenUnspecified = true;
        option.DefaultApiVersion = ApiVersion.Default; //new ApiVersion(1);
        option.ReportApiVersions = true;
        option.ApiVersionReader = ApiVersionReader.Combine(
            new QueryStringApiVersionReader("api-version"),
            new HeaderApiVersionReader("api-version"),
            new UrlSegmentApiVersionReader()
            );
    }).AddApiExplorer(opt =>
    {
        opt.GroupNameFormat = "'v'V";
        opt.SubstituteApiVersionInUrl = true;

    });
//builder.Services.AddSwaggerGen();
   builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

//Error handling
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();




var env = builder.Environment.IsProduction();
if (env)
{

    builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                    .ReadFrom.Configuration(hostingContext.Configuration)
                    .WriteTo.ApplicationInsights(new TelemetryConfiguration (hostingContext.Configuration["AppSettings:Monitoring:AzureApplicationInsightsInstrumentationKey"].ToString() ), TelemetryConverter.Traces));
}
else
{
    //Serilog
    //Add support to logging with SERILOG
    builder.Host.UseSerilog((context, configuration) =>
        configuration.ReadFrom.Configuration(context.Configuration));
}

var app = builder.Build();
provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
       
       // options.InjectStylesheet("/swagger-ui/custom.css");
        foreach (var desc in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"../swagger/{desc.GroupName}/swagger.json", desc.ApiVersion.ToString());
            options.DefaultModelsExpandDepth(-1);
            options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
        }

    });

}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseExceptionHandler();
//Add support to logging request with SERILOG
app.UseSerilogRequestLogging();
app.MapControllers();

app.Run();
