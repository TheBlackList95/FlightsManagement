#pragma checksum "C:\Users\Zakaria\Desktop\SuiviDesVolsV1.0\Views\Shared\Partials\_Header.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eae6d69f194f31ada35ef2d20b85c7da841b5ef3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Partials__Header), @"mvc.1.0.view", @"/Views/Shared/Partials/_Header.cshtml")]
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
#line 2 "C:\Users\Zakaria\Desktop\SuiviDesVolsV1.0\Views\_ViewImports.cshtml"
using SuiviDesVols.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Zakaria\Desktop\SuiviDesVolsV1.0\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eae6d69f194f31ada35ef2d20b85c7da841b5ef3", @"/Views/Shared/Partials/_Header.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"08aea14641574e36e73ea9f8352bf6317cd07433", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Partials__Header : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/images/logo.png", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Flights", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "BookedFlights", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Zakaria\Desktop\SuiviDesVolsV1.0\Views\Shared\Partials\_Header.cshtml"
   
    var controller = ViewContext.RouteData.Values["controller"].ToString();
    var action = ViewContext.RouteData.Values["action"].ToString();

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<header id=\"header\" class=\"navbar-static-top\">\r\n    <div class=\"topnav hidden-xs\">\r\n        <div class=\"container\">\r\n            <ul class=\"quick-menu pull-right\">\r\n                <li>\r\n");
#nullable restore
#line 12 "C:\Users\Zakaria\Desktop\SuiviDesVolsV1.0\Views\Shared\Partials\_Header.cshtml"
                     if (signInManager.IsSignedIn(User))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <a href=\"#\">\r\n                            Bienvenue <b>");
#nullable restore
#line 15 "C:\Users\Zakaria\Desktop\SuiviDesVolsV1.0\Views\Shared\Partials\_Header.cshtml"
                                    Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</b>\r\n                        </a>\r\n");
#nullable restore
#line 17 "C:\Users\Zakaria\Desktop\SuiviDesVolsV1.0\Views\Shared\Partials\_Header.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </li>\r\n            </ul>\r\n\r\n            <ul class=\"quick-menu pull-left\">\r\n");
#nullable restore
#line 22 "C:\Users\Zakaria\Desktop\SuiviDesVolsV1.0\Views\Shared\Partials\_Header.cshtml"
                 if (signInManager.IsSignedIn(User))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li><a");
            BeginWriteAttribute("href", " href=\"", 822, "\"", 857, 1);
#nullable restore
#line 24 "C:\Users\Zakaria\Desktop\SuiviDesVolsV1.0\Views\Shared\Partials\_Header.cshtml"
WriteAttributeValue("", 829, Url.Action("LogOut","Home"), 829, 28, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"button yellow\"><i class=\"soap-icon-restricted\"></i> Se déconnecter</a></li>\r\n");
#nullable restore
#line 25 "C:\Users\Zakaria\Desktop\SuiviDesVolsV1.0\Views\Shared\Partials\_Header.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li><a");
            BeginWriteAttribute("href", " href=\"", 1029, "\"", 1063, 1);
#nullable restore
#line 28 "C:\Users\Zakaria\Desktop\SuiviDesVolsV1.0\Views\Shared\Partials\_Header.cshtml"
WriteAttributeValue("", 1036, Url.Action("Login","Home"), 1036, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"button yellow \"><i class=\"soap-icon-user\"></i> Se conencter</a></li>\r\n                    <li><a");
            BeginWriteAttribute("href", " href=\"", 1168, "\"", 1205, 1);
#nullable restore
#line 29 "C:\Users\Zakaria\Desktop\SuiviDesVolsV1.0\Views\Shared\Partials\_Header.cshtml"
WriteAttributeValue("", 1175, Url.Action("Register","Home"), 1175, 30, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("><i class=\"soap-icon-friends\"></i> S\'enregistrer</a></li>\r\n");
#nullable restore
#line 30 "C:\Users\Zakaria\Desktop\SuiviDesVolsV1.0\Views\Shared\Partials\_Header.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </ul>
        </div>
    </div>

    <div class=""main-header"">
        <a href=""#mobile-menu-01"" data-toggle=""collapse"" class=""mobile-menu-toggle"">
            Mobile Menu Toggle
        </a>

        <div class=""container"">
            <h1 class=""logo navbar-brand"">
                <a href=""#"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "eae6d69f194f31ada35ef2d20b85c7da841b5ef39253", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ImageTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper);
#nullable restore
#line 43 "C:\Users\Zakaria\Desktop\SuiviDesVolsV1.0\Views\Shared\Partials\_Header.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_ImageTagHelper.Src = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </a>\r\n            </h1>\r\n\r\n            <nav id=\"main-menu\" role=\"navigation\">\r\n                <ul class=\"menu\">\r\n                    <li");
            BeginWriteAttribute("class", " class=\"", 1844, "\"", 1930, 2);
            WriteAttributeValue("", 1852, "menu-item-has-children", 1852, 22, true);
#nullable restore
#line 49 "C:\Users\Zakaria\Desktop\SuiviDesVolsV1.0\Views\Shared\Partials\_Header.cshtml"
WriteAttributeValue(" ", 1874, controller.Equals("Flights") ? "active-link-bg" : "", 1875, 55, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eae6d69f194f31ada35ef2d20b85c7da841b5ef311892", async() => {
                WriteLiteral("\r\n                            <i class=\"soap-icon-grid\"></i> Accueil\r\n                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 50 "C:\Users\Zakaria\Desktop\SuiviDesVolsV1.0\Views\Shared\Partials\_Header.cshtml"
AddHtmlAttributeValue("", 2012, controller.Equals("Flights") ? "active-link-fg" : "", 2012, 55, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    </li>\r\n\r\n");
#nullable restore
#line 55 "C:\Users\Zakaria\Desktop\SuiviDesVolsV1.0\Views\Shared\Partials\_Header.cshtml"
                     if (signInManager.IsSignedIn(User))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <li");
            BeginWriteAttribute("class", " class=\"", 2306, "\"", 2398, 2);
            WriteAttributeValue("", 2314, "menu-item-has-children", 2314, 22, true);
#nullable restore
#line 57 "C:\Users\Zakaria\Desktop\SuiviDesVolsV1.0\Views\Shared\Partials\_Header.cshtml"
WriteAttributeValue(" ", 2336, controller.Equals("BookedFlights") ? "active-link-bg" : "", 2337, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eae6d69f194f31ada35ef2d20b85c7da841b5ef314712", async() => {
                WriteLiteral("\r\n                                <i class=\"soap-icon-plane\"></i> Mes réservations");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "class", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 58 "C:\Users\Zakaria\Desktop\SuiviDesVolsV1.0\Views\Shared\Partials\_Header.cshtml"
AddHtmlAttributeValue("", 2490, controller.Equals("BookedFlights") ? "active-link-fg" : "", 2490, 61, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                        </li>\r\n");
#nullable restore
#line 61 "C:\Users\Zakaria\Desktop\SuiviDesVolsV1.0\Views\Shared\Partials\_Header.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n            </nav>\r\n        </div>\r\n\r\n        <nav id=\"mobile-menu-01\" class=\"mobile-menu collapse\">\r\n            <ul id=\"mobile-primary-menu\" class=\"menu\">\r\n                <li class=\"menu-item-has-children\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eae6d69f194f31ada35ef2d20b85c7da841b5ef317186", async() => {
                WriteLiteral("Accueil");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 71 "C:\Users\Zakaria\Desktop\SuiviDesVolsV1.0\Views\Shared\Partials\_Header.cshtml"
                     if (signInManager.IsSignedIn(User))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eae6d69f194f31ada35ef2d20b85c7da841b5ef318849", async() => {
                WriteLiteral("Mes réservations");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 74 "C:\Users\Zakaria\Desktop\SuiviDesVolsV1.0\Views\Shared\Partials\_Header.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </li>
            </ul>
        </nav>
    </div>

    <div id=""travelo-login"" class=""travelo-login-box travelo-box"">
        <div class=""row text-center"">
            <div class=""col-md-12"">
                <div class=""logo-title"">
                    <div class=""icon-logo"">
                        <i class=""soap-icon-plane-right yellow-color""></i>
                    </div>
                    <h4>Artza Technologies</h4>
                </div>
            </div>
        </div>

        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "eae6d69f194f31ada35ef2d20b85c7da841b5ef320976", async() => {
                WriteLiteral(@"
            <div class=""form-group"">
                <input type=""email"" class=""input-text full-width"" placeholder=""Adresse éléctronique"">
            </div>

            <div class=""form-group"">
                <input type=""password"" class=""input-text full-width"" placeholder=""Mot de passe"">
            </div>

            <div class=""seperator""></div>

            <div class=""form-group"">
                <button type=""submit"" class=""full-width"">Se connecter</button>
            </div>
        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    </div>\r\n</header>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<IdentityUser> signInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591