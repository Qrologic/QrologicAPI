#pragma checksum "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Home\Profile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "435ae581210e3d19f9e5f8cef2dac3565bc55a42"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Home_Profile), @"mvc.1.0.view", @"/Areas/Admin/Views/Home/Profile.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"435ae581210e3d19f9e5f8cef2dac3565bc55a42", @"/Areas/Admin/Views/Home/Profile.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33fefbd7ed14aa6beb546f1934b71252e92fbd33", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Home_Profile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QroApi.MODEL.ProfileModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/CustomJS/Utility.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/CustomJS/Member.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Home\Profile.cshtml"
  
    ViewData["Title"] = "Profile";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("<section class=\"content-header\">\r\n    <h1> <i class=\"lnr-apartment opacity-6\"></i> Profile </h1>\r\n    <ol class=\"breadcrumb\">\r\n        <li><a href=\"/Admin/Home/\"><i class=\"fa fa-user-circle-o\"></i>Home</a></li>\r\n        <li");
            BeginWriteAttribute("class", " class=\"", 359, "\"", 367, 0);
            EndWriteAttribute();
            WriteLiteral(@"> Profile
        <li>
    </ol>
</section>
<section class=""content"">
    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""main-card mb-3 "">
                <div class=""my-profile-wrapper"">
                    <div class=""my-profile card-white"">
                        <h3>My Details <span style=""float:right;"">
    <a href=""javascript:void(0);"" data-toggle=""modal"" data-target=""#exampleModal""");
            BeginWriteAttribute("onclick", " onclick=\"", 798, "\"", 839, 3);
            WriteAttributeValue("", 808, "member.EmployeePopup(", 808, 21, true);
#nullable restore
#line 21 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Home\Profile.cshtml"
WriteAttributeValue("", 829, Model.Id, 829, 9, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 838, ")", 838, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Update Profile</a>\r\n</span></h3>\r\n                        <div class=\"row\">\r\n\r\n                            <div class=\"col-6 col-sm-4 col-lg-3 mb-15\">\r\n                                <h4>Role</h4>\r\n                                <p>");
#nullable restore
#line 27 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Home\Profile.cshtml"
                              Write(Model.RoleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                            <div class=\"col-6 col-sm-4 col-lg-3 mb-15\">\r\n                                <h4>Name</h4>\r\n                                <p>");
#nullable restore
#line 31 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Home\Profile.cshtml"
                              Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                            <div class=\"col-6 col-sm-4 col-lg-3 mb-15\">\r\n                                <h4>Email</h4>\r\n                                <p>");
#nullable restore
#line 35 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Home\Profile.cshtml"
                              Write(Model.Email);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                            <div class=\"col-6 col-sm-4 col-lg-3 mb-15\">\r\n                                <h4>Mobile</h4>\r\n                                <p>");
#nullable restore
#line 39 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Home\Profile.cshtml"
                              Write(Model.Mobile);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n\r\n                            <div class=\"col-6 col-sm-4 col-lg-3 mb-15\">\r\n                                <h4>Address</h4>\r\n                                <p>");
#nullable restore
#line 44 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Home\Profile.cshtml"
                              Write(Model.FullAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                            <div class=\"col-6 col-sm-4 col-lg-3 mb-15\">\r\n                                <h4>PanNumber</h4>\r\n                                <p>");
#nullable restore
#line 48 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Home\Profile.cshtml"
                              Write(Model.PanNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                            <div class=\"col-6 col-sm-4 col-lg-3 mb-15\">\r\n                                <h4>AadhaarNumber</h4>\r\n                                <p>");
#nullable restore
#line 52 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Home\Profile.cshtml"
                              Write(Model.AadhaarNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                            <div class=\"col-6 col-sm-4 col-lg-3 mb-15\">\r\n                                <h4>Balance</h4>\r\n                                <p><span class=\"icon-rupee pos-unset fs-10\"></span>");
#nullable restore
#line 56 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Home\Profile.cshtml"
                                                                              Write(Model.Balance);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                            <div class=\"col-6 col-sm-4 col-lg-3 mb-15\">\r\n                                <h4>DOJ</h4>\r\n                                <p>");
#nullable restore
#line 60 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Home\Profile.cshtml"
                              Write(Model.DOJ);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                            <div class=\"col-6 col-sm-4 col-lg-3 mb-15\">\r\n                                <h4>Status</h4>\r\n                                <p class=\"color-red\">");
#nullable restore
#line 64 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Home\Profile.cshtml"
                                                Write(Model.Status);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            </div>\r\n                            <div class=\"col-6 col-sm-4 col-lg-3 mb-15\">\r\n                                 </div>\r\n                        </div>\r\n                    </div>\r\n");
            WriteLiteral("                </div>\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "435ae581210e3d19f9e5f8cef2dac3565bc55a4211592", async() => {
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
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "435ae581210e3d19f9e5f8cef2dac3565bc55a4212692", async() => {
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QroApi.MODEL.ProfileModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
