#pragma checksum "C:\Users\Evince\Downloads\TextReader\TextReader\Views\GPT\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e0c7bb41ca97f78a314cf8174efdbe69168d6ca1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_GPT_Index), @"mvc.1.0.view", @"/Views/GPT/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0c7bb41ca97f78a314cf8174efdbe69168d6ca1", @"/Views/GPT/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"68fc69799e2c63a0d1ad3a8a937bd120272610b7", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_GPT_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "GPT", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "GetAnswer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<!-- Hero Start -->
<div class=""container-fluid pt-5 bg-primary hero-header"">
    <div class=""container pt-5"">
        <div class=""row g-5 pt-5"">
            <div class=""col-lg-6 align-self-center text-center text-lg-start mb-lg-5"">
                <h1 class=""display-4 text-white mb-4 animated slideInRight"">Chat-GPT</h1>
                <nav aria-label=""breadcrumb"">
                    <ol class=""breadcrumb justify-content-center justify-content-lg-start mb-0"">
                        <li class=""breadcrumb-item""><a class=""text-white"" href=""#"">Home</a></li>
                        <li class=""breadcrumb-item text-white active"" aria-current=""page"">Chat-GPT</li>
                    </ol>
                </nav>
            </div>
            <div class=""col-lg-6 align-self-end text-center text-lg-end"">
                <img class=""img-fluid"" src=""/assets/img/hero-img.png""");
            BeginWriteAttribute("alt", " alt=\"", 909, "\"", 915, 0);
            EndWriteAttribute();
            WriteLiteral(@" style=""max-height: 300px;"">
            </div>
        </div>
    </div>
</div>
<!-- Hero End -->
<div class=""row g-0"">
    <div class=""col-12 col-lg-5 col-xl-3 border-right"" style=""width:20%"">

        <div class=""px-4 d-none d-md-block"">
            <div class=""py-2 px-4 border-bottom d-none d-lg-block"">
                <div class=""d-flex align-items-center py-1"">
                    <div class=""flex-grow-1 pl-3"">
                        <h4 class=""h4"">New Chat</h4>
                    </div>
                    <div class=""flex-grow-1 mb-7"">
                        <i class=""fas fa-edit fa-lg""></i>
                    </div>
                </div>
            </div>
        </div>

        <a href=""#"" class=""list-group-item list-group-item-action border-0"">
            <div class=""d-flex align-items-start"">
                <div class=""flex-grow-1 ml-3"">
                    Tell me About Bihar
                </div>
            </div>
        </a>
        <a href=""#"" class=""lis");
            WriteLiteral(@"t-group-item list-group-item-action border-0"">
            <div class=""d-flex align-items-start"">
                <div class=""flex-grow-1 ml-3"">
                    Is AI the future
                </div>
            </div>
        </a>
        <a href=""#"" class=""list-group-item list-group-item-action border-0"">
            <div class=""d-flex align-items-start"">
                <div class=""flex-grow-1 ml-3"">
                    Who is Mahendra Singh Dhoni
                </div>
            </div>
        </a>
        <a href=""#"" class=""list-group-item list-group-item-action border-0"">
            <div class=""d-flex align-items-start"">
                <div class=""flex-grow-1 ml-3"">
                    Who is the President of India
                </div>
            </div>
        </a>
        <a href=""#"" class=""list-group-item list-group-item-action border-0"">
            <div class=""d-flex align-items-start"">
                <div class=""flex-grow-1 ml-3"">
                    Who was Fo");
            WriteLiteral(@"under of Computer
                </div>
            </div>
        </a>
        <a href=""#"" class=""list-group-item list-group-item-action border-0"">
            <div class=""d-flex align-items-start"">
                <div class=""flex-grow-1 ml-3"">
                    How many State in India
                </div>
            </div>
        </a>
        <a href=""#"" class=""list-group-item list-group-item-action border-0"">
            <div class=""d-flex align-items-start"">
                <div class=""flex-grow-1 ml-3"">
                    Where is Capital of India
                </div>
            </div>
        </a>

        <hr class=""d-block d-lg-none mt-1 mb-0"">
    </div>
    <div class=""col-12 col-lg-7 col-xl-9"" style=""width:80%"">
        <div class=""py-2 px-4 border-bottom d-none d-lg-block"">
            <div class=""d-flex align-items-center py-1"">
                <div class=""flex-grow-1 pl-3"">
                    <h4 class=""h4"">Chat-GPT</h4>
                </div>
            ");
            WriteLiteral("</div>\r\n        </div>\r\n        <div class=\"position-relative\">\r\n");
#nullable restore
#line 100 "C:\Users\Evince\Downloads\TextReader\TextReader\Views\GPT\Index.cshtml"
             if (ViewBag.ChatHistory != null)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"chat-messages\">\r\n");
#nullable restore
#line 103 "C:\Users\Evince\Downloads\TextReader\TextReader\Views\GPT\Index.cshtml"
                     if (((List<ChatMessage>)ViewBag.ChatHistory).Count > 0)
                    {
                        foreach (var message in ViewBag.ChatHistory as List<ChatMessage>)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div");
            BeginWriteAttribute("class", " class=\"", 4411, "\"", 4462, 3);
            WriteAttributeValue("", 4419, "chat-message-", 4419, 13, true);
#nullable restore
#line 107 "C:\Users\Evince\Downloads\TextReader\TextReader\Views\GPT\Index.cshtml"
WriteAttributeValue("", 4432, message.Sender.ToLower(), 4432, 25, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 4457, "pb-4", 4458, 5, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <div>\r\n                                    <div class=\"text-muted small text-nowrap mt-2\">");
#nullable restore
#line 109 "C:\Users\Evince\Downloads\TextReader\TextReader\Views\GPT\Index.cshtml"
                                                                              Write(message.Timestamp.ToString("h:mm tt"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                </div>\r\n                                <div");
            BeginWriteAttribute("class", " class=\"", 4710, "\"", 4813, 6);
            WriteAttributeValue("", 4718, "flex-shrink-1", 4718, 13, true);
            WriteAttributeValue(" ", 4731, "bg-light", 4732, 9, true);
            WriteAttributeValue(" ", 4740, "rounded", 4741, 8, true);
            WriteAttributeValue(" ", 4748, "py-2", 4749, 5, true);
            WriteAttributeValue(" ", 4753, "px-3", 4754, 5, true);
#nullable restore
#line 111 "C:\Users\Evince\Downloads\TextReader\TextReader\Views\GPT\Index.cshtml"
WriteAttributeValue(" ", 4758, message.Sender.ToLower() == "you" ? "mr-3" : "ml-3", 4759, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <div class=\"font-weight-bold mb-1\">");
#nullable restore
#line 112 "C:\Users\Evince\Downloads\TextReader\TextReader\Views\GPT\Index.cshtml"
                                                                  Write(message.Sender);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                                    ");
#nullable restore
#line 113 "C:\Users\Evince\Downloads\TextReader\TextReader\Views\GPT\Index.cshtml"
                               Write(message.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 116 "C:\Users\Evince\Downloads\TextReader\TextReader\Views\GPT\Index.cshtml"
                        }
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n");
#nullable restore
#line 119 "C:\Users\Evince\Downloads\TextReader\TextReader\Views\GPT\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"chat-messages\" style=\"padding: 204px;\">\r\n                    <div>\r\n                        <p>No messages yet. Ask a question to start the conversation.</p>\r\n                    </div>\r\n                </div>\r\n");
#nullable restore
#line 127 "C:\Users\Evince\Downloads\TextReader\TextReader\Views\GPT\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n        <div class=\"flex-grow-0 py-3 px-4 border-top\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e0c7bb41ca97f78a314cf8174efdbe69168d6ca112807", async() => {
                WriteLiteral(@"
                <div class=""row g-3"">
                    <div class=""col-12"">
                        <div class=""form-floating"">
                            <input type=""text"" class=""form-control"" id=""msg"" name=""prompt"" placeholder=""Message ChatGPT..."">
                            <label for=""prompt"">Message ChatGPT...</label>
                            <button class=""btn btn-primary mb-6"" type=""submit""><i class=""fa fa-paper-plane fs-5""></i></button>
                        </div>
                    </div>
                </div>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        </div>
    </div>
</div>


<style>
    .mb-6 {
        margin-top: -85px;
        margin-left: 972px;
    }

    .mb-7 {
        margin-top: -12px;
        margin-left: 41px;
    }

    /* Adjust New Chat area */
    .col-12.col-lg-5.col-xl-3.border-right {
        width: 20%;
    }

    /* Adjust ChatGPT area */
    .col-12.col-lg-7.col-xl-9 {
        width: 80%;
    }

    /* Add styles for the chat messages area */
    .chat-messages {
        max-height: 400px; /* You can adjust the max height as needed */
        overflow-y: auto;
    }

    /* Add styles for the chat input area */
    /*.flex-grow-0.py-3.px-4.border-top {
            position: sticky;
            bottom: 0;
            background-color: white;
        }*/


</style>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591