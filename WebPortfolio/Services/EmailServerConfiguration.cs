﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebPortfolio.Services
{
    public class EmailServerConfiguration
    {
        public string SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string SmtpUsername { get; set; }
        public string SmtpPassword { get; set; }
        public string EmailOwnerName { get; set; }
        public string SenderEmailAddress { get; set; }

        public EmailServerConfiguration(int _smtpPort = 587)
        {
            SmtpPort = _smtpPort;
        }
        
        public EmailServerConfiguration()
        {
            SmtpPort = 587;
        }
    }
}
