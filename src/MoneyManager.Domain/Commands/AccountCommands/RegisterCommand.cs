using MoneyManager.Domain.Contracts.Commands;
using System;

namespace MoneyManager.Domain.Commands.AccountCommands
{
    public class RegisterCommand : ICommand
    {
        public Guid User { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }

        public RegisterCommand()
        {
        }

        public RegisterCommand(Guid user, string shortName, string longName, string color, string icon)
        {
            this.User = user;
            this.ShortName = shortName;
            this.LongName = longName;
            this.Color = color;
            this.Icon = icon;
        }
    }
}