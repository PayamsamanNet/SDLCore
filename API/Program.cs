using Common.Setting;
using Data.Context;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SDLV1.Configuration;
using System.Security;
using WebFrameWork.Configuration;
using WebFrameWork.Mapper;
using Microsoft.Extensions.Localization;
using System.Globalization;
using Common.IdentityUttilies;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System;
using Core.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers(options =>
//{
//    options.Filters.Add(new AuthorizeFilter());
//});
//builder.Services.AddIdentity<SystemUser, Role>().AddEntityFrameworkStores<SDLDbContext>().AddDefaultTokenProviders().AddErrorDescriber<CustomIdentityError>();

builder.Services.AddControllers();
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

builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<SDLDbContext>().AddDefaultTokenProviders().AddErrorDescriber<CustomIdentityError>();

builder.Services.RegisterServiesEntities();
builder.Services.RegisterJwtService(_siteSetting);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.DefaultModelsExpandDepth(-1));
}

app.UseStaticFiles();



app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
