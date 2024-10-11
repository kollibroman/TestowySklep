using Microsoft.EntityFrameworkCore;
using Serilog;
using TestowySklep.Api.Extensions;
using TestowySklep.Api.Persitence;
using TestowySklep.Api.Repositories;
using TestowySklep.Api.Repositories.Interfaces;
using TestowySklep.Api.Services;
using TestowySklep.Api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TestowyDbContext>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddCors(o => o.AddPolicy("MyPolicy", policyBuilder =>
{
    policyBuilder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

builder.Services.AddControllers();

builder.Services.AddAntiforgery();

var app = builder.Build();

//app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Map("/", () => Results.Redirect("/swagger"));

app.RegisterApiEndpoints();

app.UseRouting();
app.UseAntiforgery();
app.UseCors("MyPolicy");

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetService<TestowyDbContext>();
context!.Database.Migrate();

app.UseHttpsRedirection();

app.Run();

