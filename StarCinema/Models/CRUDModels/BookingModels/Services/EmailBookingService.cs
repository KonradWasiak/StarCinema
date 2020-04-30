using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using StarCinema.DomainModels;

namespace StarCinema.Models.CRUDModels.BookingModels.Services
{
    public class EmailBookingService : IEmailBookingService
    {
        private readonly BookingEmailSettings _settings;
        private readonly IBookingService _bookingService;

        public EmailBookingService(IOptions<BookingEmailSettings> settings, IBookingService bookingService)
        {
            _settings = settings.Value;
            _bookingService = bookingService;
        }

        public void SendBookingConfirmationEmail(string email, Booking booking)
        {
            MailMessage message = new MailMessage();

            using (SmtpClient smtp = new SmtpClient(_settings.MailServer))
            {


                message.From = new MailAddress(_settings.Sender);
                message.To.Add(new MailAddress(email));
                message.Subject = "Booking";
                message.IsBodyHtml = true;
                message.Body = "Your booking code: " + _bookingService.GetBookingHash(booking);
                smtp.Port = _settings.MailPort;
                smtp.Host = _settings.MailServer;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(_settings.Sender, _settings.Password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
        }

    }
}
