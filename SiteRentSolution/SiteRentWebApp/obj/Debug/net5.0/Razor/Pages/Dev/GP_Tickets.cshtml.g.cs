#pragma checksum "C:\Users\DTolokonnikov\source\repos\SiteRentAppWebrep\SiteRentSolution\SiteRentWebApp\Pages\Dev\GP_Tickets.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "adcc9f7d569d8efebb865a65784492cc37fc4180"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SiteRentWebApp.Pages.Dev.Pages_Dev_GP_Tickets), @"mvc.1.0.razor-page", @"/Pages/Dev/GP_Tickets.cshtml")]
namespace SiteRentWebApp.Pages.Dev
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\DTolokonnikov\source\repos\SiteRentAppWebrep\SiteRentSolution\SiteRentWebApp\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DTolokonnikov\source\repos\SiteRentAppWebrep\SiteRentSolution\SiteRentWebApp\Pages\_ViewImports.cshtml"
using SiteRentWebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\DTolokonnikov\source\repos\SiteRentAppWebrep\SiteRentSolution\SiteRentWebApp\Pages\_ViewImports.cshtml"
using SiteRentWebApp.Data;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"adcc9f7d569d8efebb865a65784492cc37fc4180", @"/Pages/Dev/GP_Tickets.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7404baf9111dd40442127c679e5ad2ea5441fccd", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Dev_GP_Tickets : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\DTolokonnikov\source\repos\SiteRentAppWebrep\SiteRentSolution\SiteRentWebApp\Pages\Dev\GP_Tickets.cshtml"
   Layout = "/Pages/Shared/_TestLayout.cshtml"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Tickets</h1>\r\n<p>");
#nullable restore
#line 7 "C:\Users\DTolokonnikov\source\repos\SiteRentAppWebrep\SiteRentSolution\SiteRentWebApp\Pages\Dev\GP_Tickets.cshtml"
Write(Model.name.Split("|")[0]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>");
#nullable restore
#line 8 "C:\Users\DTolokonnikov\source\repos\SiteRentAppWebrep\SiteRentSolution\SiteRentWebApp\Pages\Dev\GP_Tickets.cshtml"
Write(Model.name.Split("|")[1]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>");
#nullable restore
#line 9 "C:\Users\DTolokonnikov\source\repos\SiteRentAppWebrep\SiteRentSolution\SiteRentWebApp\Pages\Dev\GP_Tickets.cshtml"
Write(Model.name.Split("|")[2]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>");
#nullable restore
#line 10 "C:\Users\DTolokonnikov\source\repos\SiteRentAppWebrep\SiteRentSolution\SiteRentWebApp\Pages\Dev\GP_Tickets.cshtml"
Write(Model.name.Split("|")[3]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n<p>");
#nullable restore
#line 11 "C:\Users\DTolokonnikov\source\repos\SiteRentAppWebrep\SiteRentSolution\SiteRentWebApp\Pages\Dev\GP_Tickets.cshtml"
Write(Model.name.Split("|")[4]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n<table>\r\n    <tr>\r\n        <th>Ticket</th>\r\n        <th>Reg</th>\r\n        <th>AAB</th>\r\n        <th>CREATED</th>\r\n        <th>H</th>\r\n    </tr>\r\n\r\n    <tr>\r\n        <th>");
#nullable restore
#line 23 "C:\Users\DTolokonnikov\source\repos\SiteRentAppWebrep\SiteRentSolution\SiteRentWebApp\Pages\Dev\GP_Tickets.cshtml"
        Write(Model.name.Split("|")[0]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n        <th>");
#nullable restore
#line 24 "C:\Users\DTolokonnikov\source\repos\SiteRentAppWebrep\SiteRentSolution\SiteRentWebApp\Pages\Dev\GP_Tickets.cshtml"
        Write(Model.name.Split("|")[1]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n        <th>");
#nullable restore
#line 25 "C:\Users\DTolokonnikov\source\repos\SiteRentAppWebrep\SiteRentSolution\SiteRentWebApp\Pages\Dev\GP_Tickets.cshtml"
        Write(Model.name.Split("|")[2]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n        <th>");
#nullable restore
#line 26 "C:\Users\DTolokonnikov\source\repos\SiteRentAppWebrep\SiteRentSolution\SiteRentWebApp\Pages\Dev\GP_Tickets.cshtml"
        Write(Model.name.Split("|")[3]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n        <th>");
#nullable restore
#line 27 "C:\Users\DTolokonnikov\source\repos\SiteRentAppWebrep\SiteRentSolution\SiteRentWebApp\Pages\Dev\GP_Tickets.cshtml"
        Write(Model.name.Split("|")[4]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n    </tr>\r\n</table>\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GP_Tickets> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GP_Tickets> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<GP_Tickets>)PageContext?.ViewData;
        public GP_Tickets Model => ViewData.Model;
    }
}
#pragma warning restore 1591