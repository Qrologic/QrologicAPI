#pragma checksum "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Home\Components\Service\Service.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b5ed6d6fc24a54a573bd33a1aa1a77d6bc5cd13d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Member_Views_Home_Components_Service_Service), @"mvc.1.0.view", @"/Areas/Member/Views/Home/Components/Service/Service.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b5ed6d6fc24a54a573bd33a1aa1a77d6bc5cd13d", @"/Areas/Member/Views/Home/Components/Service/Service.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33fefbd7ed14aa6beb546f1934b71252e92fbd33", @"/Areas/Member/Views/_ViewImports.cshtml")]
    public class Areas_Member_Views_Home_Components_Service_Service : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QroApi.MODEL.MemberServiceModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Home\Components\Service\Service.cshtml"
 if (Model.list != null)
{
    if (Model.list.Count > 0)
    {


#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"col-md-12\">\r\n            <div class=\"main-card \">\r\n                <div class=\"card-header-tab card-header myservice\" style=\"border-radius: 6px 6px 0px 0px; \">\r\n");
#nullable restore
#line 10 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Home\Components\Service\Service.cshtml"
                     foreach (var item in Model.list)
                    {
                        if (item.ServiceCode == "RC")
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a class=\"nav-link mr-2 mb-2 btn-icon btn btn-outline-light\"");
            BeginWriteAttribute("id", " id=\"", 538, "\"", 566, 2);
            WriteAttributeValue("", 543, "service-", 543, 8, true);
#nullable restore
#line 14 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Home\Components\Service\Service.cshtml"
WriteAttributeValue("", 551, item.ServiceId, 551, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" data-toggle=\"tab\" href=\"#home\"");
            BeginWriteAttribute("onclick", " onclick=\"", 598, "\"", 664, 6);
            WriteAttributeValue("", 608, "svc.ServicePopup(\'", 608, 18, true);
#nullable restore
#line 14 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Home\Components\Service\Service.cshtml"
WriteAttributeValue("", 626, item.ServiceId, 626, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 641, "\',", 641, 2, true);
            WriteAttributeValue(" ", 643, "\'", 644, 2, true);
#nullable restore
#line 14 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Home\Components\Service\Service.cshtml"
WriteAttributeValue("", 645, item.ServiceName, 645, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 662, "\')", 662, 2, true);
            EndWriteAttribute();
            WriteLiteral("><i");
            BeginWriteAttribute("class", " class=\"", 668, "\"", 710, 2);
#nullable restore
#line 14 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Home\Components\Service\Service.cshtml"
WriteAttributeValue("", 676, item.ServiceIcon, 676, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 693, "btn-icon-wrapper", 694, 17, true);
            EndWriteAttribute();
            WriteLiteral("></i>");
#nullable restore
#line 14 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Home\Components\Service\Service.cshtml"
                                                                                                                                                                                                                                                                     Write(item.ServiceName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 15 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Home\Components\Service\Service.cshtml"
                                                                                                                                                                                                                                                                                      
                        }
                        else if (item.ServiceCode == "DMT")
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a class=\"mr-2 nav-link  mb-2 btn-icon btn btn-outline-light\"");
            BeginWriteAttribute("id", " id=\"", 1223, "\"", 1251, 2);
            WriteAttributeValue("", 1228, "service-", 1228, 8, true);
#nullable restore
#line 19 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Home\Components\Service\Service.cshtml"
WriteAttributeValue("", 1236, item.ServiceId, 1236, 15, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" href=\"/Member/v2/dmt\"><i");
            BeginWriteAttribute("class", " class=\"", 1277, "\"", 1319, 2);
#nullable restore
#line 19 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Home\Components\Service\Service.cshtml"
WriteAttributeValue("", 1285, item.ServiceIcon, 1285, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1302, "btn-icon-wrapper", 1303, 17, true);
            EndWriteAttribute();
            WriteLiteral("></i>");
#nullable restore
#line 19 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Home\Components\Service\Service.cshtml"
                                                                                                                                                                                          Write(item.ServiceName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 20 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Home\Components\Service\Service.cshtml"
                        }
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </div>\r\n            </div>\r\n\r\n\r\n        </div>\r\n");
#nullable restore
#line 27 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Home\Components\Service\Service.cshtml"
    }
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QroApi.MODEL.MemberServiceModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
