using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPortfolio.Models;
using WebPortfolio.Services;

namespace WebPortfolio.Components
{
    public partial class ContactForm
    {
        [Inject]
        private PortfolioContext Db { get; set; }
        [Inject]
        private IEmailService EmailService { get; set; }

        private ContactFormModel contact = new ContactFormModel();

        private async void HandleValidSubmit()
        {
            Db.Add(contact);
            await Db.SaveChangesAsync();

            var message = $"Hi {contact.Name}!\n" +
                $"Thank you for contacting me! I'll consider your request and reply as soon as I can." +
                $"\nSincerely, Ildar";

            await EmailService.SendAsync("Contact Request To Ildar", message, contact.Email, contact.Name);
        }
    }
}
