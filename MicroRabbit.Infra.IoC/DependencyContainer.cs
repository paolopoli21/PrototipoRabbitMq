using MediatR;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Services;
using MicroRabbit.Banking.Data.Context;
using MicroRabbit.Banking.Data.Repository;
using MicroRabbit.Banking.Domain.CommandHandlers;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Infra.Bus;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Application.Services;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Data.Repository;
using MicroRabbit.Transfer.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MicroRabbit.Infra.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();
            //services.AddTransient<IRequestHandler<CreateTransferCommand, bool>, TransferCommandHandler>();
            // Domain Bus
            services.AddTransient<IEventBus, RabbitMQBus>();
            //services.Configure<RabbitMQSettings>(c => configuration.GetSection("RabbitMQSettings"));

            //// Domain Events
            //services.AddTransient<IEventHandler<TransferCreatedEvent>, TransferEventHandler>();

            //// Application Services
            //services.AddTransient<ITransferService, TransferService>();
            //services.AddTransient<IAccountService, AccountService>();
            //services.AddTransient<ITransferService, TransferService>();
            //// Data
            
            
            //services.AddTransient<IAccountRepository, AccountRepository>();
            //services.AddTransient<ITransferRepository, TransferRepository>();
            //services.AddTransient<BankingDbContext>();
            //services.AddTransient<TransferDbContext>();
            return services;

        }
    }
}
