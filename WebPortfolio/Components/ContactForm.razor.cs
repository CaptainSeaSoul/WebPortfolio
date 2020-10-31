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
        public PortfolioContext Db { get; set; }
        [Inject]
        public MailKitEmailService EmailService { get; set; }

        private ContactFormModel contact = new ContactFormModel();

        private async void HandleValidSubmit()
        {
            Db.Add(contact);
            await Db.SaveChangesAsync();
            // todo what's the message?
            await EmailService.SendAsync("Contact Request To Ildar", "", contact.Email, contact.Name);
        }
    }
}
