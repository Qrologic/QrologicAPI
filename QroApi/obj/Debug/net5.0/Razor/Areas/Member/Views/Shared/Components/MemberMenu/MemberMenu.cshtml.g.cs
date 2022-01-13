#pragma checksum "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3446a3e9736a2cbe87dc3a88f2524ba12d7671b8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Member_Views_Shared_Components_MemberMenu_MemberMenu), @"mvc.1.0.view", @"/Areas/Member/Views/Shared/Components/MemberMenu/MemberMenu.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3446a3e9736a2cbe87dc3a88f2524ba12d7671b8", @"/Areas/Member/Views/Shared/Components/MemberMenu/MemberMenu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33fefbd7ed14aa6beb546f1934b71252e92fbd33", @"/Areas/Member/Views/_ViewImports.cshtml")]
    public class Areas_Member_Views_Shared_Components_MemberMenu_MemberMenu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QroApi.MODEL.MenuModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
 if (Model.listMenu != null)
{
    var parentList = Model.listMenu.Where(x => x.ParentId == 0 && x.Level == 1).OrderBy(x => x.Position).ToList();
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
     foreach (var parent in parentList)
    {


        var childList = Model.listMenu.Where(x => x.ParentId == parent.MenuId).OrderBy(x => x.Position).ToList();
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
         if (childList.Count == 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li>\r\n");
#nullable restore
#line 14 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
                  var area = parent.ControllerName.ToLower() == "account" ? "" : "/Member"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a");
            BeginWriteAttribute("href", " href=\"", 527, "\"", 581, 5);
#nullable restore
#line 15 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
WriteAttributeValue("", 534, area, 534, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 539, "/", 539, 1, true);
#nullable restore
#line 15 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
WriteAttributeValue("", 540, parent.ControllerName, 540, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 562, "/", 562, 1, true);
#nullable restore
#line 15 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
WriteAttributeValue("", 563, parent.ActionName, 563, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 582, "\"", 669, 7);
            WriteAttributeValue("", 592, "removeActiveClass(", 592, 18, true);
#nullable restore
#line 15 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
WriteAttributeValue("", 610, childList.Count, 610, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 626, ",`", 626, 2, true);
#nullable restore
#line 15 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
WriteAttributeValue("", 628, parent.MenuName, 628, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 644, "`,``,`", 644, 6, true);
#nullable restore
#line 15 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
WriteAttributeValue("", 650, parent.MenuIcon, 650, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 666, "`);", 666, 3, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <i");
            BeginWriteAttribute("class", " class=\"", 695, "\"", 734, 2);
            WriteAttributeValue("", 703, "metismenu-icon", 703, 14, true);
#nullable restore
#line 16 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
WriteAttributeValue(" ", 717, parent.MenuIcon, 718, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>");
#nullable restore
#line 16 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
                                                              Write(parent.MenuName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("                </a>\r\n            </li>\r\n");
#nullable restore
#line 20 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li");
            BeginWriteAttribute("id", " id=\"", 940, "\"", 964, 2);
            WriteAttributeValue("", 945, "menu_", 945, 5, true);
#nullable restore
#line 23 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
WriteAttributeValue("", 950, parent.MenuId, 950, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 965, "\"", 1011, 3);
            WriteAttributeValue("", 975, "menu.SetMenuInCookie(", 975, 21, true);
#nullable restore
#line 23 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
WriteAttributeValue("", 996, parent.MenuId, 996, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1010, ")", 1010, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 1012, "\"", 1037, 1);
#nullable restore
#line 23 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
WriteAttributeValue("", 1020, parent.ClassName, 1020, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <a href=\"javascript:void(0);\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1086, "\"", 1173, 7);
            WriteAttributeValue("", 1096, "removeActiveClass(", 1096, 18, true);
#nullable restore
#line 24 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
WriteAttributeValue("", 1114, childList.Count, 1114, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1130, ",`", 1130, 2, true);
#nullable restore
#line 24 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
WriteAttributeValue("", 1132, parent.MenuName, 1132, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1148, "`,``,`", 1148, 6, true);
#nullable restore
#line 24 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
WriteAttributeValue("", 1154, parent.MenuIcon, 1154, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1170, "`);", 1170, 3, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <i");
            BeginWriteAttribute("class", " class=\"", 1199, "\"", 1238, 2);
            WriteAttributeValue("", 1207, "metismenu-icon", 1207, 14, true);
#nullable restore
#line 25 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
WriteAttributeValue(" ", 1221, parent.MenuIcon, 1222, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>");
#nullable restore
#line 25 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
                                                              Write(parent.MenuName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <i class=\"metismenu-state-icon fa fa-angle-down caret-left opacity-5\"></i>\r\n                </a>\r\n\r\n");
#nullable restore
#line 29 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
                 foreach (var child in childList)
                {
                    var area = child.ControllerName.ToLower() == "account" ? "" : "/Member";

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <ul");
            BeginWriteAttribute("class", " class=\"", 1569, "\"", 1605, 2);
            WriteAttributeValue("", 1577, "mm-collapse", 1577, 11, true);
#nullable restore
#line 32 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
WriteAttributeValue(" ", 1588, child.ClassName, 1589, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                        <li>\r\n                            <a");
            BeginWriteAttribute("href", " href=\"", 1669, "\"", 1721, 5);
#nullable restore
#line 34 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
WriteAttributeValue("", 1676, area, 1676, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1681, "/", 1681, 1, true);
#nullable restore
#line 34 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
WriteAttributeValue("", 1682, child.ControllerName, 1682, 21, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1703, "/", 1703, 1, true);
#nullable restore
#line 34 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
WriteAttributeValue("", 1704, child.ActionName, 1704, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 1722, "\"", 1745, 2);
            WriteAttributeValue("", 1727, "menu_", 1727, 5, true);
#nullable restore
#line 34 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
WriteAttributeValue("", 1732, child.MenuId, 1732, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 1746, "\"", 1847, 9);
            WriteAttributeValue("", 1756, "menu.SubMenuActive(", 1756, 19, true);
#nullable restore
#line 34 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
WriteAttributeValue("", 1775, child.MenuId, 1775, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1788, ",`", 1788, 2, true);
#nullable restore
#line 34 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
WriteAttributeValue("", 1790, parent.MenuTitle, 1790, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1807, "`,`", 1807, 3, true);
#nullable restore
#line 34 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
WriteAttributeValue("", 1810, child.MenuTitle, 1810, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1826, "`,`", 1826, 3, true);
#nullable restore
#line 34 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
WriteAttributeValue("", 1829, parent.MenuIcon, 1829, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1845, "`)", 1845, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <i class=\"metismenu-icon\"></i> ");
#nullable restore
#line 35 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
                                                          Write(child.MenuName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                            </a>\r\n                        </li>\r\n                    </ul>\r\n");
#nullable restore
#line 39 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </li>\r\n");
#nullable restore
#line 41 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
         

    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Shared\Components\MemberMenu\MemberMenu.cshtml"
     
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script>

    $(function () {
        var menuId = sessionStorage.getItem(""ActiveSubMenu"");
        if (menuId != null || menuId != undefined) {
            $(`#menu_` + menuId).addClass('menu-active');
        }

        function removeActiveClass(cnt, firstLevelMenuName, secondLevelMenuName, menuicon) {
            sessionStorage.setItem(""firstLevelMenuName"", firstLevelMenuName);
            sessionStorage.setItem(""secondLevelMenuName"", secondLevelMenuName);
            sessionStorage.setItem(""menuicon"", menuicon);

            //var menuId = sessionStorage.getItem(""ActiveSubMenu"");
            //console.log(menuId);
            //if (cnt == 0) {
            //    $(`#menu_` + menuId).removeClass('menu-active');
            //    sessionStorage.removeItem(""ActiveSubMenu"");
            //}
        }
    });

</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QroApi.MODEL.MenuModel> Html { get; private set; }
    }
}
#pragma warning restore 1591