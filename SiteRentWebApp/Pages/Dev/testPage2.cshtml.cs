using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SiteRentWebApp.Pages
{
    [Authorize]
    [IEFilterAttribute]
    public class testPage2 : PageModel
    {
        public void OnGet()
        {

        }
    }   
}
