#pragma checksum "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Settings\Company.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ce519094084fcd8a717772d361c7b5ca672c3662"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Settings_Company), @"mvc.1.0.view", @"/Areas/Admin/Views/Settings/Company.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ce519094084fcd8a717772d361c7b5ca672c3662", @"/Areas/Admin/Views/Settings/Company.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33fefbd7ed14aa6beb546f1934b71252e92fbd33", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Settings_Company : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QroApi.MODEL.CompanyModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("accept", new global::Microsoft.AspNetCore.Html.HtmlString("image/png, image/jpeg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("required", new global::Microsoft.AspNetCore.Html.HtmlString("required"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdateCompanyLogo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Settings", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax", new global::Microsoft.AspNetCore.Html.HtmlString("true"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-method", new global::Microsoft.AspNetCore.Html.HtmlString("POST"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-begin", new global::Microsoft.AspNetCore.Html.HtmlString("OnBegin"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-failure", new global::Microsoft.AspNetCore.Html.HtmlString("OnFailure"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-success", new global::Microsoft.AspNetCore.Html.HtmlString("OnSuccess"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_13 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-ajax-complete", new global::Microsoft.AspNetCore.Html.HtmlString("OnComplete"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_14 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "UpdateCompanyFevicon", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_15 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/CustomJS/Settings.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Settings\Company.cshtml"
  
    ViewData["Title"] = "Company";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<style>
    .modal-backdrop.show {
        display: none !important;
    }

    .modal-dialog {
        height: auto !important;
    }
</style>

<section class=""content"">
    <div class=""row"">
        <div class=""col-md-8 company-table"">
            <div class=""box"">
                <div class=""box-body"">
                    <div class=""pull-right"">
                        <span class=""pull-right text-primary edit-link"" data-config-id=""accountDetailsDisplayInfo"">
                            <a class=""btn btn-default btn-xs"" href=""javascript:void(0);"" data-toggle=""modal"" data-target=""#exampleModal"" onclick=""setting.CompanyPopup('Admin');""><i class=""fa fa-pencil""></i></a>
                        </span>
                    </div>
                    <div class=""clearfix""></div>
                    <div class=""row"">
                        <div class=""col-md-11"">
                            <table class=""table table-details"">
                                <tbody>

                    ");
            WriteLiteral("                <tr>\r\n                                        <td class=\"ft-600\">Website Url</td>\r\n                                        <td><span class=\"help-text\">");
#nullable restore
#line 34 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Settings\Company.cshtml"
                                                               Write(Model.WebsiteUrl);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                                    </tr>\r\n                                    <tr>\r\n                                        <td class=\"ft-600\">Company Name</td>\r\n                                        <td><span class=\"help-text\">");
#nullable restore
#line 38 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Settings\Company.cshtml"
                                                               Write(Model.CompanyName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                                    </tr>\r\n                                    <tr>\r\n                                        <td class=\"ft-600\">Company Owner</td>\r\n                                        <td><span class=\"help-text\">");
#nullable restore
#line 42 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Settings\Company.cshtml"
                                                               Write(Model.CompanyOwner);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></td>
                                    </tr>

                                    <tr>
                                        <td class=""ft-600"">
                                            CIN
                                        </td>
                                        <td><span class=""help-text"">");
#nullable restore
#line 49 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Settings\Company.cshtml"
                                                               Write(Model.CIN);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                                    </tr>\r\n\r\n\r\n                                    <tr>\r\n                                        <td class=\"ft-600\">PAN</td>\r\n                                        <td><span class=\"help-text\">");
#nullable restore
#line 55 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Settings\Company.cshtml"
                                                               Write(Model.PanNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                                    </tr>\r\n\r\n                                    <tr>\r\n                                        <td class=\"ft-600\">TAN</td>\r\n                                        <td><span class=\"help-text\">");
#nullable restore
#line 60 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Settings\Company.cshtml"
                                                               Write(Model.TanNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                                    </tr>\r\n\r\n                                    <tr>\r\n                                        <td class=\"ft-600\">GST No</td>\r\n                                        <td><span class=\"help-text\">");
#nullable restore
#line 65 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Settings\Company.cshtml"
                                                               Write(Model.GstNo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                                    </tr>\r\n\r\n                                    <tr>\r\n                                        <td class=\"ft-600\">Address</td>\r\n                                        <td><span class=\"help-text\">");
#nullable restore
#line 70 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Settings\Company.cshtml"
                                                               Write(Model.Address);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                                    </tr>\r\n                                    <tr>\r\n                                        <td class=\"ft-600\">Company Email</td>\r\n                                        <td><span class=\"help-text\">");
#nullable restore
#line 74 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Settings\Company.cshtml"
                                                               Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                                    </tr>\r\n                                    <tr>\r\n                                        <td class=\"ft-600\">Company Mobile</td>\r\n                                        <td><span class=\"help-text\">");
#nullable restore
#line 78 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Settings\Company.cshtml"
                                                               Write(Model.Mobile);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></td>\r\n                                    </tr>\r\n\r\n                                    <tr>\r\n                                        <td class=\"ft-600\">Copyright</td>\r\n                                        <td><span class=\"help-text\">");
#nullable restore
#line 83 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Settings\Company.cshtml"
                                                               Write(Model.Copyright);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</span></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class=""col-md-4 logo-change-1"">
            <div class=""box box-warning"">
                <div class=""box-header with-border"">
                    <i class=""fa fa-bullhorn""></i>
                    <h3 class=""box-title"">Logo</h3>
                </div>
                <div class=""box-body"">
                    <div class=""row"">
                        <div class=""col-xs-12 col-md-8 col-md-offset-2 text-center"">
                            <img class=""img-responsive margin-auto""");
            BeginWriteAttribute("src", " src=\"", 4758, "\"", 4808, 2);
            WriteAttributeValue("", 4764, "../../images/uploadimages/", 4764, 26, true);
#nullable restore
#line 101 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Settings\Company.cshtml"
WriteAttributeValue("", 4790, Model.CompanyLogo, 4790, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Full logo for printing\">\r\n                            <div class=\"margin-bottom-10\">\r\n");
            WriteLiteral(@"                            </div>
                            <button type=""button"" class=""btn btn-warning btn-flat"" data-toggle=""modal"" data-target=""#upload-business-logo-modal"">
                                <i class=""fa fa-pencil"" aria-hidden=""true""></i> Change Logo
                            </button>
                            <div class=""modal"" id=""upload-business-logo-modal"">
                                <div class=""modal-dialog"">
                                    <div class=""modal-content"">
                                        <div class=""modal-header"">
                                            <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                                                <span aria-hidden=""true"">??</span>
                                            </button>
                                            <h4 class=""modal-title text-center"">Upload Logo</h4>
                                        </div>
                             ");
            WriteLiteral("           ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ce519094084fcd8a717772d361c7b5ca672c366219745", async() => {
                WriteLiteral(@"
                                            <div class=""modal-body"">
                                                <div class=""box-body"">
                                                    <div class=""form-group"">
                                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ce519094084fcd8a717772d361c7b5ca672c366220285", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 122 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Settings\Company.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 122 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Settings\Company.cshtml"
                                                                                     WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ce519094084fcd8a717772d361c7b5ca672c366222798", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 123 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Settings\Company.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ImageFile);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
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
                                            <div class=""modal-footer"">
                                                <button type=""submit"" class=""btn btn-success"">Upload Logo</button>
                                            </div>
                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
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
                        </div>
                    </div>
                </div>
            </div>
            <div class=""box box-success"">
                <div class=""box-header with-border"">
                    <i class=""fa fa-bullhorn""></i>
                    <h3 class=""box-title"">Favicon</h3>
                </div>
                <div class=""box-body"">
                    <div class=""row"">

                        <div class=""col-xs-12 col-md-8 col-md-offset-2 text-center favicon-logo"">
                            <img class=""img-responsive margin-auto""");
            BeginWriteAttribute("src", " src=\"", 8081, "\"", 8106, 2);
            WriteAttributeValue("", 8087, "/", 8087, 1, true);
#nullable restore
#line 147 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Settings\Company.cshtml"
WriteAttributeValue("", 8088, Model.FeviconIcon, 8088, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Fevicon\">\r\n                            <div class=\"margin-bottom-10\">\r\n");
            WriteLiteral(@"                            </div>
                            <button type=""button"" class=""btn btn-warning btn-flat"" data-toggle=""modal"" data-target=""#upload-business-favicon-modal"">
                                <i class=""fa fa-pencil"" aria-hidden=""true""></i> Change Favicon
                            </button>
                            <div class=""modal"" id=""upload-business-favicon-modal"">
                                <div class=""modal-dialog"">
                                    <div class=""modal-content"">
                                        <div class=""modal-header"">
                                            <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                                                <span aria-hidden=""true"">??</span>
                                            </button>
                                            <h4 class=""modal-title text-center"">Upload Favicon</h4>
                                        </div>
                 ");
            WriteLiteral("                       ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ce519094084fcd8a717772d361c7b5ca672c366229569", async() => {
                WriteLiteral(@"
                                            <div class=""modal-body"">
                                                <div class=""box-body"">
                                                    <div class=""form-group"">
                                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ce519094084fcd8a717772d361c7b5ca672c366230109", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#nullable restore
#line 168 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Settings\Company.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 168 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Settings\Company.cshtml"
                                                                                     WriteLiteral(Model.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                                                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ce519094084fcd8a717772d361c7b5ca672c366232622", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 169 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Settings\Company.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ImageFile);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
                                                        <span class=""help-block text-light-blue"">Upload 48*48 '.ico' format image</span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class=""modal-footer"">
                                                <button type=""submit"" class=""btn btn-success"">Upload Favicon</button>
                                            </div>
                                        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_14.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_14);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Area = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_13);
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
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</section>
");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ce519094084fcd8a717772d361c7b5ca672c366237412", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_15);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script>\r\n        $(document).ready(function () {\r\n            menu.BindBreadCrumb(0);\r\n        });\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QroApi.MODEL.CompanyModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
