using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarCinema.Models.CRUDModels.BookingModels
{
    public class BookingEmailSettings
    {
        public string MailServer { get; set; }
        public int MailPort { get; set; }
        public string SenderName { get; set; }
        public string Sender { get; set; }
        public string Password { get; set; }
    }
}
