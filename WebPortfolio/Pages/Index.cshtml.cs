using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebPortfolio.Models;

namespace WebPortfolio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public PortfolioContext Db;

        public IEnumerable<Sertificate> Sertificates { get; private set; }
        public IEnumerable<Skill> Skills { get; private set; }
        public IEnumerable<Language> Languages { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, PortfolioContext db)
        {
            _logger = logger;
            Db = db;
        }

        public void OnGet()
        {
            Sertificates = Db.Sertificates;
            Skills = Db.Skills;
            Languages = Db.Languages;
        }
    }
}
