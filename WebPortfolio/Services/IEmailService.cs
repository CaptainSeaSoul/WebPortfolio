using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPortfolio.Services
{
    interface IEmailService
    {
        Task SendAsync(String subject, String content, String address, String name);
    }
}
