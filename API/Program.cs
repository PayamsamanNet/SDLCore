using Data.Context;
using Microsoft.EntityFrameworkCore;
using WebFrameWork.Configuration;
using WebFrameWork.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MapperConfig));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SDLDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SDLConnectionString"));
});

builder.Services.RegisterServiesEntities();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.DefaultModelsExpandDepth(-1));
}

app.UseAuthorization();

app.MapControllers();

app.Run();
