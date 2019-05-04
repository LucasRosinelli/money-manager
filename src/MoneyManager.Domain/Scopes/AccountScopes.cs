using MoneyManager.Domain.Entities;
using MoneyManager.Domain.Enums;

namespace MoneyManager.Domain.Scopes
{
    public static class AccountScopes
    {
        public static bool RegisterIsValid(this Account entity)
        {
            return true;
        }

        public static bool ChangeInfoIsValid(this Account entity, string shortName, string longName, string color, string icon)
        {
            return true;
        }

        public static bool ActivateIsValid(this Account entity)
        {
            return entity.Status != DefaultState.Active;
        }

        public static bool DeactivateIsValid(this Account entity)
        {
            return entity.Status != DefaultState.Inactive;
        }
    }
}