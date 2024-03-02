using Eaconomy.Application;
using Eaconomy.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

//Adding Services to the Layers

builder.Services.ConfigureApplicationServices();
builder.Services.ConfigureInfrastructureServices(builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Eaconomy-API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."

    });
    //c.AddSecurityRequirement(new OpenApiSecurityRequirement
    //            {
    //                {
    //                      new OpenApiSecurityScheme
    //                      {
    //                          Reference = new OpenApiReference
    //                          {
    //                              Type = ReferenceType.SecurityScheme,
    //                              Id = "Bearer"
    //                          }
    //                      },
    //                     new string[] {}
    //                }
    //            });
    c.OperationFilter<Eaconomy.API.Filters.AuthorizeCheckOperationFilter>();
});
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
   
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
