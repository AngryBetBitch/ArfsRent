#pragma checksum "C:\Users\DTolokonnikov\source\repos\SiteRentAppWebrep\SiteRentSolution\SiteRentWebApp\Pages\Dev\test_login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52133489a20f320b9a808d7e1944020b9a9cd0a3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(SiteRentWebApp.Pages.Dev.Pages_Dev_test_login), @"mvc.1.0.razor-page", @"/Pages/Dev/test_login.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"52133489a20f320b9a808d7e1944020b9a9cd0a3", @"/Pages/Dev/test_login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7404baf9111dd40442127c679e5ad2ea5441fccd", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Dev_test_login : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("#"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\Users\DTolokonnikov\source\repos\SiteRentAppWebrep\SiteRentSolution\SiteRentWebApp\Pages\Dev\test_login.cshtml"
   Layout = null; 

#line default
#line hidden
#nullable disable
            WriteLiteral("<!DOCTYPE html>\r\n<!-- Created by CodingLab |www.youtube.com/c/CodingLabYT-->\r\n<html lang=\"en\" dir=\"ltr\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "52133489a20f320b9a808d7e1944020b9a9cd0a34536", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <!--<title> Login and Registration Form in HTML & CSS | CodingLab </title>-->
    <link rel=""stylesheet"" href=""/css/styletest.css"">
    <!-- Fontawesome CDN Link -->
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "52133489a20f320b9a808d7e1944020b9a9cd0a35903", async() => {
                WriteLiteral(@"
    <div class=""container"">
        <input type=""checkbox"" id=""flip"">
        <div class=""cover"">
            <div class=""front"">
                <!--<img src=""images/frontImg.jpg"" alt="""">-->
            </div>
            
        </div>
        <div class=""forms"">
            <div class=""form-content"">
                <div class=""login-form"">
                    <div class=""title"">
                        Login
                        <img src=""https://pbs.twimg.com/media/DnSfUUIW0AA2tff.jpg:large"" width=""80"" height=""80""></p>
                    </div>
                   
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "52133489a20f320b9a808d7e1944020b9a9cd0a36805", async() => {
                    WriteLiteral(@"
                        <div class=""input-boxes"">
                            <div class=""input-box"">
                                <i class=""fas fa-envelope""></i>
                                <input type=""text"" placeholder=""Enter your email"" required>
                            </div>
                            <div class=""input-box"">
                                <i class=""fas fa-lock""></i>
                                <input type=""password"" placeholder=""Enter your password"" required>
                            </div>
                            <div class=""text""><a href=""#"">Forgot password?</a></div>
                            <div class=""button input-box"">
                                <input type=""submit"" value=""Sumbit"">
                            </div>
                            <div class=""text sign-up-text"">Don't have an account? <label for=""flip"">Submit now</label></div>
                        </div>
                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </div>\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<testLoginPage3> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<testLoginPage3> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<testLoginPage3>)PageContext?.ViewData;
        public testLoginPage3 Model => ViewData.Model;
    }
}
#pragma warning restore 1591