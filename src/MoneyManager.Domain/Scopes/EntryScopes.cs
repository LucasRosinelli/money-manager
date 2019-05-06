using MoneyManager.Domain.Entities;
using MoneyManager.Domain.Enums;
using System;

namespace MoneyManager.Domain.Scopes
{
    public static class EntryScopes
    {
        public static bool RegisterIsValid(this Entry entity)
        {
            return true;
        }

        public static bool ChangeInfoIsValid(this Entry entity, string description, DateTime date, float value)
        {
            return true;
        }

        public static bool ActivateIsValid(this Entry entity)
        {
            return entity.Status != DefaultState.Active;
        }

        public static bool DeactivateIsValid(this Entry entity)
        {
            return entity.Status != DefaultState.Inactive;
        }
    }
}