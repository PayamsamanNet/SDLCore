using Common;
using Data.Context;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Security;
using WebFrameWork.Configuration;
using WebFrameWork.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(new AuthorizeFilter());
});

//builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MapperConfig));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<SecuritySetting>(builder.Configuration.GetSection("Security"));
SecuritySetting? _siteSetting = builder.Configuration.GetSection("Security").Get<SecuritySetting>();


builder.Services.AddSwaggerGen(options => 

{
    options.AddSecurityDefinition(_siteSetting.Scheme, new OpenApiSecurityScheme
    {
        Scheme = _siteSetting.Scheme,
        BearerFormat = _siteSetting.BearerFormat,
        In = ParameterLocation.Header,
        Name = _siteSetting.HeaderName,
        Description = _siteSetting.DescriptionScheme,
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = _siteSetting.Scheme,
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });

});

builder.Services.AddDbContext<SDLDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SDLConnectionString"));
});

builder.Services.RegisterServiesEntities();
builder.Services.RegisterJwtService(_siteSetting);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.DefaultModelsExpandDepth(-1));
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
