//using MicroRabbit.Banking.Data.Context;
//using MicroRabbit.Infra.Bus;
//using MicroRabbit.Infra.IoC;
using MediatR;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Infra.IoC;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Application.Services;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Data.Repository;
using MicroRabbit.Transfer.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TransferDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TransferDbConnection"));
});
builder.Services.Configure<RabbitMQSettings>(builder.Configuration.GetSection("RabbitMQSettings"));

builder.Services.RegisterServices(builder.Configuration);
//builder.Services.
//DependencyContainer.RegisterServices(builder.Services, builder.Configuration);

builder.Services.AddTransient<ITransferService, TransferService>();
builder.Services.AddTransient<ITransferRepository, TransferRepository>();
builder.Services.AddTransient<TransferDbContext>();


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

app.Run();
