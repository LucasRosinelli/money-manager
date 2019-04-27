using MoneyManager.Domain.Commands.Contracts;
using System;

namespace MoneyManager.Domain.Commands.UserCommands
{
    public class ChangeBasicInfoCommand : ICommand
    {
        public Guid Identifier { get; set; }
        public string FullName { get; set; }

        public ChangeBasicInfoCommand()
        {
        }

        public ChangeBasicInfoCommand(Guid identifier, string fullName)
        {
            this.Identifier = identifier;
            this.FullName = fullName;
        }
    }
}