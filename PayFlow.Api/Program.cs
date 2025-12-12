using Microsoft.EntityFrameworkCore;
using PayFlow.Domain.Interfaces;
using PayFlow.Domain.Services;
using PayFlow.Infra.Data;
using PayFlow.Infra.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PayFlowDB"), sqlOptions =>
    {
        sqlOptions.CommandTimeout(400);
    });
});

// Register repository as scoped so it shares the same DbContext scope per request
builder.Services.AddScoped<IRepository, Repository>();

builder.Services.AddTransient<IPaymentService, PaymentService>();
builder.Services.AddTransient<IFastPayService, FastPayService>();
builder.Services.AddTransient<ISecurePayService, SecurePayService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
