using MoneyManager.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace MoneyManager.Domain.Specs
{
    public static class UserSpecs
    {
        public static Expression<Func<User, bool>> GetById(long id)
        {
            return x => x.Id == id;
        }

        public static Expression<Func<User, bool>> GetByIdentifier(Guid identifier)
        {
            return x => x.Identifier == identifier;
        }
    }
}