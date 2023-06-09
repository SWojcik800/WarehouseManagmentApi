using Autofac;
using Autofac.Extensions.DependencyInjection;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using WarehouseManagment.Api;
using WarehouseManagment.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Call UseServiceProviderFactory on the Host sub property 
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory(x => x.RegisterModule<WebApiModule>()));

// Add services to the container.
builder.Services.AddDbContext<WarehouseContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("WarehouseDatabase")));
builder.Services.AddHttpClient();

builder.Services.AddCors(options => {
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
        });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
