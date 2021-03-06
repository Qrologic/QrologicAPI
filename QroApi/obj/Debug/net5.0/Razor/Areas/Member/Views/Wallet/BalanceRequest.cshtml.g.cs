#pragma checksum "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Wallet\BalanceRequest.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9cc926cc8d7e2c3fe4872b2e5bab423ba9f80e12"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Member_Views_Wallet_BalanceRequest), @"mvc.1.0.view", @"/Areas/Member/Views/Wallet/BalanceRequest.cshtml")]
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
#line 1 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\_ViewImports.cshtml"
using QroApi;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\_ViewImports.cshtml"
using QroApi.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\_ViewImports.cshtml"
using QroApi.BLL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\_ViewImports.cshtml"
using QroApi.DLL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\_ViewImports.cshtml"
using QroApi.MODEL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\_ViewImports.cshtml"
using QroApi.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Wallet\BalanceRequest.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Wallet\BalanceRequest.cshtml"
using Newtonsoft.Json.Linq;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9cc926cc8d7e2c3fe4872b2e5bab423ba9f80e12", @"/Areas/Member/Views/Wallet/BalanceRequest.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33fefbd7ed14aa6beb546f1934b71252e92fbd33", @"/Areas/Member/Views/_ViewImports.cshtml")]
    public class Areas_Member_Views_Wallet_BalanceRequest : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/CustomJS/Wallet.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Wallet\BalanceRequest.cshtml"
  
    ViewData["Title"] = "BalanceRequest";
    Layout = "~/Areas/Member/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 9 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Wallet\BalanceRequest.cshtml"
  
    JObject obj = JObject.Parse(JsonConvert.SerializeObject(new BalanceRequestList(), Formatting.Indented, new JsonSerializerSettings
    { PreserveReferencesHandling = PreserveReferencesHandling.Objects }));
    obj.Remove("$id");

    List<string>
    termsList = new List<string>();
    foreach (var columnName in obj)
    {
        termsList.Add(columnName.Key.Trim());
    }
    string[] columnArray = termsList.ToArray();

    ViewData["Title"] = "Balance Request";
    var userRole = User.Identity.GetDetailOf("Role");

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<section class=""content"">
    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""main-card mb-3 card"">
                <div class=""card-header"">
                    <a href=""javascript:void(0);"" data-toggle=""modal"" data-target=""#exampleModal"" onclick=""wallet.OpenRequestPopup(0);"">
                        <i class=""fa fa-plus-circle""></i>&nbsp;New Request
                    </a>
                    <div class=""btn-actions-pane-right"">
                        <div role=""group"" class=""btn-group-sm nav btn-group"">

");
#nullable restore
#line 37 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Wallet\BalanceRequest.cshtml"
                             if (userRole.ToString().ToLower() != "retailer")
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a data-toggle=\"tab\" href=\"#tab-eg1-0\" class=\"btn-shadow active btn btn-primary\">Self</a>\r\n                                <a data-toggle=\"tab\" href=\"#tab-eg1-1\" class=\"btn-shadow  btn btn-primary\">Downline</a>\r\n");
#nullable restore
#line 41 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Wallet\BalanceRequest.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        </div>
                    </div>
                </div>
                <div class=""card-body"">
                    <div class=""tab-content"">
                        <div class=""tab-pane active"" id=""tab-eg1-0"" role=""tabpanel"">
                            <div class=""table-responsive"">
                                <table id=""myTable"" class=""display nowrap dataTable dtr-inline collapsed "">
                                    <thead>
                                        <tr>
");
#nullable restore
#line 53 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Wallet\BalanceRequest.cshtml"
                                             foreach (var item in columnArray)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <th>");
#nullable restore
#line 55 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Wallet\BalanceRequest.cshtml"
                                               Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 56 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Wallet\BalanceRequest.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        </tr>
                                    </thead>
                                </table>
                            </div>
                        </div>
                        <div class=""tab-pane"" id=""tab-eg1-1"" role=""tabpanel"">
                            <div class=""table-responsive"">
                                <table id=""myTable2"" class=""display nowrap dataTable dtr-inline collapsed "" style=""width:100%;"">
                                    <thead>
                                        <tr>
");
#nullable restore
#line 67 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Wallet\BalanceRequest.cshtml"
                                             foreach (var item in columnArray)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <th>");
#nullable restore
#line 69 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Wallet\BalanceRequest.cshtml"
                                               Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 70 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Wallet\BalanceRequest.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                        </tr>
                                    </thead>
                                </table>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

    </div>

</section>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9cc926cc8d7e2c3fe4872b2e5bab423ba9f80e1210538", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script>
        $(document).ready(function () {
            menu.BindBreadCrumb(0);
            $.when(table.BindPostTable(`/Member/Wallet/LoadBalanceRequest`, `myTable`)).then(function () {                
                table.BindPostTable(`/Member/Wallet/LoadDownlineBalanceRequest`, `myTable2`)
            });
        });
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
