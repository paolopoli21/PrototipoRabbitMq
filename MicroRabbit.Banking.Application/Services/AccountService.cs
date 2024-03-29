﻿using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Models;
using MicroRabbit.Domain.Core.Bus;

namespace MicroRabbit.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountService _accountService;
        private readonly IEventBus _bus;

        public AccountService(IAccountService accountService, IEventBus bus)
        {
            _accountService = accountService;
            _bus = bus;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accountService.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(accountTransfer.FromAccount, accountTransfer.ToAccount, accountTransfer.TransferAmount);    
            _bus.SendCommand(createTransferCommand);
        }
    }
}
