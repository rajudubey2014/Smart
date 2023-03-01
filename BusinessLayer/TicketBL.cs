using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommanLayer;
using System.Data;

namespace BusinessLayer
{


    public class TicketBL
    {
        TicketDB ticketDB = new TicketDB();
        public List<TicketCL> GetTickets(int ticket_no=0)
        {
            List<TicketCL> lstTicket = new List<TicketCL>();
            try
            {
                var dt = ticketDB.GetTicket(ticket_no);
                if(dt.Rows.Count > 0)
                {
                    foreach(DataRow row in dt.Rows)
                    {
                        TicketCL ticketCL = new TicketCL();
                        ticketCL.Title = row["title"].ToString();
                        ticketCL.TicketNo = (int)row["ticket_no"];
                        ticketCL.CreatedOn = row["created_on"].ToString();
                        ticketCL.UserName = row["username"].ToString();

                        lstTicket.Add(ticketCL);
                    }
                }
            }
            catch(Exception)
            {
                throw;
            }
            return lstTicket;
        }

        public void CreateTicket(TicketCL ticketCL)
        {
            try
            {
                ticketDB.CreateTicket(ticketCL);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
