using MoneyManager.Domain.Contracts.Commands;

namespace MoneyManager.Domain.Commands.UserCommands
{
    public class RegisterCommand : ICommand
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }

        public RegisterCommand()
        {
        }

        public RegisterCommand(string login, string password, string fullName)
        {
            this.Login = login;
            this.Password = password;
            this.FullName = fullName;
        }
    }
}