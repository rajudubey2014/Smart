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
        public TicketCombine GetTicketsDetails(int ticket_no)
        {
            List<TicketDescriptionCL> lstTicketDetails = new List<TicketDescriptionCL>();
            List<TicketCL> lstTicket = new List<TicketCL>();
            var obj = new TicketCombine();

            try
            {
                var dt = ticketDB.GetTicketDetails(ticket_no);
                if (dt.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Tables[0].Rows)
                    {
                        TicketCL ticketDetailsCL = new TicketCL();
                        ticketDetailsCL.Title = row["title"].ToString();
                        ticketDetailsCL.TicketNo = (int)row["ticket_no"];
                        ticketDetailsCL.CreatedOn = row["created_on"].ToString();
                        ticketDetailsCL.UserName = row["username"].ToString();

                        lstTicket.Add(ticketDetailsCL);
                    }
                    obj.ticketCLs = lstTicket;
                }
                if (dt.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Tables[1].Rows)
                    {
                        TicketDescriptionCL ticketDetailsCL = new TicketDescriptionCL();
                       
                        ticketDetailsCL.TicketNo = (int)row["ticket_no"];
                        ticketDetailsCL.Description = row["description"].ToString();
                        ticketDetailsCL.CreatedOn = row["created_on"].ToString();
                        ticketDetailsCL.UserName = row["username"].ToString();

                        lstTicketDetails.Add(ticketDetailsCL);
                    }
                    obj.ticketDescriptions = lstTicketDetails;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return obj;
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
        public void CreateTicketDetails(TicketCombine ticketCombine)
        {
            try
            {
                ticketDB.CreateTicketDescription(ticketCombine);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
