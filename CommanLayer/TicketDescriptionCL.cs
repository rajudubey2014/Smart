using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanLayer
{
    public class TicketDescriptionCL
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int TicketNo { get; set; }
        public string CreatedOn { get; set; }
        
        public string Description { get; set; }
        public string UserName { get; set; }

    }

    public class TicketCombine
    {
        public List<TicketCL> ticketCLs { get; set; }
        public List<TicketDescriptionCL> ticketDescriptions { get; set; }
        public int TicketNo { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }

    }
}
