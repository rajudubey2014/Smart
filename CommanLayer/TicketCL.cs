using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanLayer
{
    public class TicketCL
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int TicketNo { get; set; }
        public string CreatedOn { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string UserName { get; set; }

    }
}
