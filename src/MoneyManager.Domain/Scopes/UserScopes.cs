using MoneyManager.Domain.Entities;
using MoneyManager.Domain.Enums;

namespace MoneyManager.Domain.Scopes
{
    public static class UserScopes
    {
        public static bool RegisterIsValid(this User entity)
        {
            return true;
        }

        public static bool ChangeAuthInfoIsValid(this User entity, string login, string password)
        {
            return true;
        }

        public static bool ChangeBasicInfoIsValid(this User entity, string fullName)
        {
            return true;
        }

        public static bool ActivateIsValid(this User entity)
        {
            return entity.Status != DefaultState.Active;
        }

        public static bool DeactivateIsValid(this User entity)
        {
            return entity.Status != DefaultState.Inactive;
        }
    }
}