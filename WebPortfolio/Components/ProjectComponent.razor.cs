using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPortfolio.Models;

namespace WebPortfolio.Components
{
    public partial class ProjectComponent
    {
        [Parameter]
        public Project Project { get; set; }
    }
}
