using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SiteRentWebApp
{
    public class AppUser : IdentityUser
    {
        public string Region { get; set; }
        public string Filial { get; set; }
    }
}

