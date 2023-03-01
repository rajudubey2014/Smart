using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommanLayer;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using UtilityLayer;

namespace DataAccessLayer
{
    public class AccountDB
    {
        public int LoginUser(UserAuthoCL userAuthoCL)
        {
            int result = 0;
            var parameters = new ArrayList();
            var sqlParameter = new SqlParameter();
            try
            {
                sqlParameter = new SqlParameter();
                sqlParameter.SqlDbType = SqlDbType.VarChar;
                sqlParameter.ParameterName = "@email";
                sqlParameter.Value = userAuthoCL.Email;
                parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter();
                sqlParameter.SqlDbType = SqlDbType.VarChar;
                sqlParameter.ParameterName = "@password";
                sqlParameter.Value = userAuthoCL.Password;
                parameters.Add(sqlParameter);

                result = DBConfig.ExecuteSpExecuteScalar("sp_user_login", parameters);

            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
