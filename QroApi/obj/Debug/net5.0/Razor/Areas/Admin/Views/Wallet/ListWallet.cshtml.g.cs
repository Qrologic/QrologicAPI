#pragma checksum "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Wallet\ListWallet.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "404958dea6e9e1cdc6ea7a927bce9beb932ed554"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Wallet_ListWallet), @"mvc.1.0.view", @"/Areas/Admin/Views/Wallet/ListWallet.cshtml")]
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
#line 1 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\_ViewImports.cshtml"
using QroApi;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\_ViewImports.cshtml"
using QroApi.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\_ViewImports.cshtml"
using QroApi.BLL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\_ViewImports.cshtml"
using QroApi.DLL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\_ViewImports.cshtml"
using QroApi.MODEL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\_ViewImports.cshtml"
using QroApi.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Wallet\ListWallet.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Wallet\ListWallet.cshtml"
using Newtonsoft.Json.Linq;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"404958dea6e9e1cdc6ea7a927bce9beb932ed554", @"/Areas/Admin/Views/Wallet/ListWallet.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33fefbd7ed14aa6beb546f1934b71252e92fbd33", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Wallet_ListWallet : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/CustomJS/Utility.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/CustomJS/Wallet.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Wallet\ListWallet.cshtml"
  
    ViewData["Title"] = "List Wallet";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 9 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Wallet\ListWallet.cshtml"
  
    JObject obj = JObject.Parse(JsonConvert.SerializeObject(new WalletResponse(), Formatting.Indented, new JsonSerializerSettings
    { PreserveReferencesHandling = PreserveReferencesHandling.Objects }));
    obj.Remove("$id");
    obj.Remove("Id");
    List<string>
    termsList = new List<string>();
    foreach (var columnName in obj)
    {
        termsList.Add(columnName.Key.Trim());
    }
    string[] columnArray = termsList.ToArray();

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    .modal-backdrop.fade.show {
        display: none !important;
    }

    .modal-dialog {
        height: auto !important;
    }
</style>
<section class=""content"">
    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""main-card mb-2 card"">
                <div class=""card-body"">
                    <input type=""hidden"" id=""hdnArea"" />
                    <a href=""javascript:void(0)"" data-toggle=""modal"" data-target=""#exampleModal"" onclick=""wallet.AddFundPopup('Cr','Admin')"" class=""mb-2 mr-2 btn-pill btn btn-primary"">Credit Balance</a>
                    <a href=""javascript:void(0)"" data-toggle=""modal"" data-target=""#exampleModal"" onclick=""wallet.AddFundPopup('Dr','Admin')"" class=""mb-2 mr-2 btn-pill btn btn-danger"">Debit Balance</a>
                </div>
            </div>
            <div class=""main-card mb-3 card"">
                <div class=""card-body"">
                    <div class=""row"">
                        <div class=""col-md-9 col-6 form-gr");
            WriteLiteral("oup\">\r\n                            <a id=\"ancModal\" href=\"#\" data-target=\"#AddFilter\"");
            BeginWriteAttribute("class", " class=\"", 1737, "\"", 1745, 0);
            EndWriteAttribute();
            WriteLiteral(" data-toggle=\"modal\" aria-expanded=\"true\"");
            BeginWriteAttribute("style", " style=\"", 1787, "\"", 1795, 0);
            EndWriteAttribute();
            WriteLiteral(@" data-placement=""auto"" data-original-title=""Conditional Filters"">
                                <i class=""fa fa-filter""></i>&nbsp;Filter
                            </a>
                        </div>
                        <div class=""col-md-3 col-6  form-group"" style=""display:none;"">
                            <div id=""reportrange"" style=""background: #fff; cursor: pointer; padding: 5px 10px; border: 1px solid #ccc; width: 100%"">
                                <i class=""fa fa-calendar""></i>&nbsp;<span></span><i class=""fa fa-caret-down""></i>
                            </div>
                        </div>
                        <div class=""col-md-12"">
                            <div class=""table-responsive"">
                                <table id=""myTable"" class=""display nowrap dataTable dtr-inline collapsed"">
                                    <thead>
                                        <tr>
");
#nullable restore
#line 60 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Wallet\ListWallet.cshtml"
                                             foreach (var item in columnArray)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <th>");
#nullable restore
#line 62 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Wallet\ListWallet.cshtml"
                                               Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 63 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Wallet\ListWallet.cshtml"
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
<div class=""modal bnr-modal fade Filter-modal"" id=""AddFilter"" tabindex=""-1"" role=""dialog"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""modeltitleAddFilter"">Search Filter</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>
            </div>
            <div class=""modal-body clearfix"">
                <div class=""dvfilterBody-col"" data-table=""dvfilterBody"" style=""max-height:400px;overflow: auto;"">
                    <div class=""form-group col-xs-12 "">
                        <d");
            WriteLiteral(@"iv class=""row"">
                            <div class=""col-md-4"">
                                <label class=""control-label"">Role</label>
                                <select id=""UserRole-Search"" name=""UserRole-Search"" class=""form-control"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "404958dea6e9e1cdc6ea7a927bce9beb932ed55411264", async() => {
                WriteLiteral("Select Role");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                </select>
                            </div>
                            <div class=""col-md-4"">
                                <label class=""control-label"">MemberId</label>
                                <input id=""MemberId-Search"" name=""MemberId-Search"" type=""text"" placeholder=""MemberId"" class=""form-control"">
                            </div>
                            <div class=""col-md-4"">
                                <label class=""control-label"">Name</label>
                                <input id=""Name-Search"" name=""Name-Search"" type=""text"" placeholder=""Name"" class=""form-control"">
                            </div>
                        </div>
                    </div>
                    <div class=""form-group col-xs-12"">
                        <div class=""row"">
                            <div class=""col-md-6"">
                                <label class=""control-label"">Mobile</label>
                                <input id=""Mobile-Searc");
            WriteLiteral(@"h"" name=""Mobile-Search"" type=""text"" placeholder=""Mobile"" class=""form-control"">
                            </div>
                            <div class=""col-md-6"">
                                <label class=""control-label"">Email</label>
                                <input id=""Email-Search"" name=""Email-Search"" type=""text"" placeholder=""Email"" class=""form-control"">
                            </div>
                        </div>
                    </div>
                    <div class=""form-group col-xs-12"">
                        <div class=""row"">
                            <div class=""col-md-12"" style=""text-align:right;"">
                                <button id=""btnSearch"" type=""button"" class=""btn btn-flat btn-success"" title=""Search Record"">
                                    <i class=""fa fa-search"" aria-hidden=""true""></i> Search
                                </button>
                            </div>
                        </div>
                    </div>
                <");
            WriteLiteral("/div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "404958dea6e9e1cdc6ea7a927bce9beb932ed55414690", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "404958dea6e9e1cdc6ea7a927bce9beb932ed55415730", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
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
    <script type=""text/javascript"">
        $(function () {
            menu.BindBreadCrumb(0);
            var data = {};
            var id = 0, area = `Admin`;
            data[""option1""] = utility.GetQueryStringValue('role');
            common.Filter(area, ""Wallet"", ""GetWalletList"", data, ""myTable"",0);
            $(""#btnSearch"").click(function () {
                data[""option1""] = $(""#UserRole-Search"").val();
                data[""option3""] = $(""#MemberId-Search"").val();
                data[""option4""] = $(""#Name-Search"").val();
                data[""option5""] = $(""#Mobile-Search"").val();
                data[""option6""] = $(""#Email-Search"").val();
                common.Filter(area, ""Wallet"", ""GetWalletList"", data, ""myTable"", 1);
                $("".close"").click();
            });
            $(""#ancModal"").click(function () {
                utility.GetRoleForRegistration(id, 'UserRole-Search', area);
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
