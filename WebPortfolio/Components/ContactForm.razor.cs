using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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
        [Inject]
        private IJSRuntime JS { get; set; }

        private ContactFormModel contact = new ContactFormModel();

        private Notification deliveryNotification = new Notification();

        private async void HandleValidSubmit()
        {
            await JS.InvokeVoidAsync("showLoadingSpinner");

            var message = $"Hi {contact.Name}!\n" +
                $"Thank you for contacting me! I'll consider your request and reply as soon as I can." +
                $"\nSincerely, Ildar";

            try
            {
                // Email to contact
                await EmailService.SendAsync("Contact Request To Ildar", message, contact.Email, contact.Name);
                // Email to myself to notify
                await EmailService.SendAsync("Contact Request To Ildar from " + contact.Name,
                    contact.Name + " wants to contact you." +
                    "\nEmail: " + contact.Email +
                    "\nPhone Number: " + contact.PhoneNumber +
                    "\nMessage: " + contact.Message);

                deliveryNotification.SetSuccess();
            }
            catch (Exception e)
            {
                deliveryNotification.SetFailure(e.Message);
            }

            StateHasChanged();

            await JS.InvokeVoidAsync("showNotification");

            if (contact.Id == 0)
            {
                Db.Add(contact);
                await Db.SaveChangesAsync();
            }
        }

        class Notification
        {
            public bool Success { get; set; }
            public String Message { get; set; }
            public Boolean Show { get; private set; }
            public void SetSuccess()
            {
                Success = true;
                Message = "Thanks! Your request was sent successfully!";
                Show = true;
            }
            public void SetFailure(String m)
            {
                Success = false;
                Message = "Unfortunately, your message was not sent with error: " + m;
                Show = true;
            }
        }
    }
}
