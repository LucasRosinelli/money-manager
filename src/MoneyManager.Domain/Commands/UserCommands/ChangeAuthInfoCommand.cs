using MoneyManager.Domain.Contracts.Commands;
using System;

namespace MoneyManager.Domain.Commands.UserCommands
{
    public class ChangeAuthInfoCommand : ICommand
    {
        public Guid Identifier { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public ChangeAuthInfoCommand()
        {
        }

        public ChangeAuthInfoCommand(Guid identifier, string login, string password)
        {
            this.Identifier = identifier;
            this.Login = login;
            this.Password = password;
        }
    }
}