using DataAccessLayer;
using System;
using CommanLayer;

namespace BusinessLayer
{
    public class AccountBL
    {
        AccountDB accountDB = new AccountDB();
        public int LoginUser(UserAuthoCL userAuthoCL)
        {
            return accountDB.LoginUser(userAuthoCL);
        }
    }
}
