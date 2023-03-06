using Common.Setting;
using Data.Context;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Security;
using WebFrameWork.Configuration;
using WebFrameWork.Mapper;
using Common.IdentityUttilies;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System;
using Core.Entities;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers(options =>
//{
//    options.Filters.Add(new AuthorizeFilter());
//});

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MapperConfig));
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
builder.Services.Configure<IdentityOptions>(option =>
{
    option.Password.RequireDigit = false;
    option.Password.RequireLowercase = false;
    option.Password.RequireNonAlphanumeric = false;
    option.Password.RequireUppercase = false;
    option.Password.RequiredLength = 4;
    option.Password.RequiredUniqueChars = 0;
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

app.UseStaticFiles();



app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
