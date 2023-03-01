﻿using CommanLayer;
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using UtilityLayer;

namespace DataAccessLayer
{
    public class TicketDB
    {
        public DataTable GetTicket(int ticket_no)
        {
            DataTable dataTable = new DataTable();
            var parameters = new ArrayList();
            var sqlParameter = new SqlParameter();
            try
            {
                if(ticket_no != 0)
                {
                    sqlParameter = new SqlParameter();
                    sqlParameter.SqlDbType = SqlDbType.Int;
                    sqlParameter.ParameterName = "@ticket_no";
                    sqlParameter.Value = ticket_no;
                    parameters.Add(sqlParameter);
                }
                dataTable = DBConfig.ExecuteSpDataTable("sp_get_ticket", parameters);
            }
            catch(Exception)
            {
                throw;
            }
            return dataTable;
        }

        public void CreateTicketDescription(TicketCL ticketCL)
        {
            var parameters = new ArrayList();
            var sqlParameter = new SqlParameter();
            try
            {

                sqlParameter = new SqlParameter();
                sqlParameter.SqlDbType = SqlDbType.VarChar;
                sqlParameter.ParameterName = "@title";
                sqlParameter.Value = ticketCL.Title;
                parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter();
                sqlParameter.SqlDbType = SqlDbType.Int;
                sqlParameter.ParameterName = "@ticket_no";
                sqlParameter.Value = ticketCL.TicketNo;
                parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter();
                sqlParameter.SqlDbType = SqlDbType.VarChar;
                sqlParameter.ParameterName = "@description";
                sqlParameter.Value = ticketCL.Description;
                parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter();
                sqlParameter.SqlDbType = SqlDbType.VarChar;
                sqlParameter.ParameterName = "@username";
                sqlParameter.Value = ticketCL.UserName;
                parameters.Add(sqlParameter);

                DBConfig.ExecuteSpExecuteNonQuery("sp_create_ticket", parameters);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CreateTicket(TicketCL ticketCL)
        {
            var parameters = new ArrayList();
            var sqlParameter = new SqlParameter();
            try
            {
                
                sqlParameter = new SqlParameter();
                sqlParameter.SqlDbType = SqlDbType.VarChar;
                sqlParameter.ParameterName = "@title";
                sqlParameter.Value = ticketCL.Title;
                parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter();
                sqlParameter.SqlDbType = SqlDbType.Int;
                sqlParameter.ParameterName = "@ticket_no";
                sqlParameter.Value = ticketCL.TicketNo;
                parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter();
                sqlParameter.SqlDbType = SqlDbType.VarChar;
                sqlParameter.ParameterName = "@description";
                sqlParameter.Value = ticketCL.Description;
                parameters.Add(sqlParameter);

                sqlParameter = new SqlParameter();
                sqlParameter.SqlDbType = SqlDbType.VarChar;
                sqlParameter.ParameterName = "@username";
                sqlParameter.Value = ticketCL.UserName;
                parameters.Add(sqlParameter);

                DBConfig.ExecuteSpExecuteNonQuery("sp_create_ticket", parameters);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
