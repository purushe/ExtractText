#pragma checksum "C:\Users\Evince\Downloads\TextReader\TextReader\Views\UserProfile\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4ad7a272c6e4c79934ffdfb72a27ef5e7cc8a4e9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_UserProfile_Index), @"mvc.1.0.view", @"/Views/UserProfile/Index.cshtml")]
namespace AspNetCore
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
#line 1 "C:\Users\Evince\Downloads\TextReader\TextReader\Views\_ViewImports.cshtml"
using TextReader;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Evince\Downloads\TextReader\TextReader\Views\_ViewImports.cshtml"
using TextReader.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4ad7a272c6e4c79934ffdfb72a27ef5e7cc8a4e9", @"/Views/UserProfile/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68fc69799e2c63a0d1ad3a8a937bd120272610b7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_UserProfile_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProfileViewModel>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<!-- Hero Start -->
<div class=""container-fluid pt-5 bg-primary hero-header"">
    <div class=""container pt-5"">
        <div class=""row g-5 pt-5"">
            <div class=""col-lg-6 align-self-center text-center text-lg-start mb-lg-5"">
                <h1 class=""display-4 text-white mb-4 animated slideInRight"">Account Settings</h1>
                <nav aria-label=""breadcrumb"">
                    <ol class=""breadcrumb justify-content-center justify-content-lg-start mb-0"">
                        <li class=""breadcrumb-item""><a class=""text-white"" href=""#"">Home</a></li>
                        <li class=""breadcrumb-item""><a class=""text-white"" href=""#"">User</a></li>
                        <li class=""breadcrumb-item text-white active"" aria-current=""page"">Account</li>
                    </ol>
                </nav>
            </div>
            <div class=""col-lg-6 align-self-end text-center text-lg-end"">
                <img class=""img-fluid"" src=""/assets/img/hero-img.png""");
            BeginWriteAttribute("alt", " alt=\"", 1024, "\"", 1030, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""max-height: 300px;"">
            </div>
        </div>
    </div>
</div>

<section class=""section about-section gray-bg"" id=""about"">
    <div class=""container"">
        <div class=""row align-items-center flex-row-reverse"">
            <div class=""col-lg-6"">
                <div class=""about-text go-to"">
                    <h4 class=""dark-color"">");
#nullable restore
#line 29 "C:\Users\Evince\Downloads\TextReader\TextReader\Views\UserProfile\Index.cshtml"
                                      Write(Model.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 29 "C:\Users\Evince\Downloads\TextReader\TextReader\Views\UserProfile\Index.cshtml"
                                                       Write(Model.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                    <div class=\"row about-list\">\r\n                        <div class=\"col-md-6\">\r\n                            <div class=\"media\">\r\n                                <label>UserName</label>\r\n                                <p>");
#nullable restore
#line 34 "C:\Users\Evince\Downloads\TextReader\TextReader\Views\UserProfile\Index.cshtml"
                              Write(Model.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            </div>
                            <div class=""media"">
                                <label>DOB</label>
                                <p>09 Jan 1999</p>
                            </div>
                            <div class=""media"">
                                <label>Residence</label>
                                <p>India</p>
                            </div>
                            <div class=""media"">
                                <label>Address</label>
                                <p>Gaya, Bihar</p>
                            </div>
                        </div>
                        <div class=""col-md-6"">
                            <div class=""media"">
                                <label>E-mail</label>
                                <p>");
#nullable restore
#line 52 "C:\Users\Evince\Downloads\TextReader\TextReader\Views\UserProfile\Index.cshtml"
                              Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                            <div class=\"media\">\r\n                                <label>Phone</label>\r\n                                <p>");
#nullable restore
#line 56 "C:\Users\Evince\Downloads\TextReader\TextReader\Views\UserProfile\Index.cshtml"
                              Write(Model.PhoneNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>
                            </div>
                            <div class=""media"">
                                <label>Skype</label>
                                <p>live:.cid.df923d3dc67ecef7</p>
                            </div>
                            <div class=""media"">
                                <label>Freelance</label>
                                <p>Available</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class=""col-lg-6"">
                <div class=""about-avatar"">
                    <img src=""https://bootdey.com/img/Content/avatar/avatar7.png""");
            BeginWriteAttribute("title", " title=\"", 3439, "\"", 3447, 0);
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 3448, "\"", 3454, 0);
            EndWriteAttribute();
            WriteLiteral(@">
                </div>
            </div>
        </div>
        <div class=""counter"">
            <div class=""row"">
                <div class=""col-6 col-lg-3"">
                    <div class=""count-data text-center"">
                        <h6 class=""count h2"" data-to=""500"" data-speed=""500"">500</h6>
                        <p class=""m-0px font-w-600"">Happy Clients</p>
                    </div>
                </div>
                <div class=""col-6 col-lg-3"">
                    <div class=""count-data text-center"">
                        <h6 class=""count h2"" data-to=""150"" data-speed=""150"">150</h6>
                        <p class=""m-0px font-w-600"">Project Completed</p>
                    </div>
                </div>
                <div class=""col-6 col-lg-3"">
                    <div class=""count-data text-center"">
                        <h6 class=""count h2"" data-to=""850"" data-speed=""850"">850</h6>
                        <p class=""m-0px font-w-600"">Photo Capture</p>
        ");
            WriteLiteral(@"            </div>
                </div>
                <div class=""col-6 col-lg-3"">
                    <div class=""count-data text-center"">
                        <h6 class=""count h2"" data-to=""190"" data-speed=""190"">190</h6>
                        <p class=""m-0px font-w-600"">Telephonic Talk</p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>
");
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProfileViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591