using Entities.Base;
using Entities.Types;
using System.Data;

namespace Services.Interfaces;

public interface IAccountRepository
{
    AccountBase GetById(Guid id);
    List<AccountBase> GetAll();

    bool Update(AccountBase account);
    bool Delete(Guid id);

    bool Add(AccountBase account);
}