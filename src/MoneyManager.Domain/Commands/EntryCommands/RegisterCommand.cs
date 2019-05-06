using MoneyManager.Domain.Contracts.Commands;
using System;

namespace MoneyManager.Domain.Commands.EntryCommands
{
    public class RegisterCommand : ICommand
    {
        public Guid Account { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public float Value { get; set; }

        public RegisterCommand()
        {
        }

        public RegisterCommand(Guid account, string description, DateTime date, float value)
        {
            this.Account = account;
            this.Description = description;
            this.Date = date;
            this.Value = value;
        }
    }
}