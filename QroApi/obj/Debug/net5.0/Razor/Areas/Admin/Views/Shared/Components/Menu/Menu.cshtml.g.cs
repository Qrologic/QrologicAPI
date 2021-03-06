#pragma checksum "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d7fb921f8893a0b80d15fd88c6864d5d34dc203"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared_Components_Menu_Menu), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/Components/Menu/Menu.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d7fb921f8893a0b80d15fd88c6864d5d34dc203", @"/Areas/Admin/Views/Shared/Components/Menu/Menu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33fefbd7ed14aa6beb546f1934b71252e92fbd33", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared_Components_Menu_Menu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QroApi.MODEL.MenuModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div");
            BeginWriteAttribute("class", " class=\"", 35, "\"", 89, 3);
            WriteAttributeValue("", 43, "app-sidebar", 43, 11, true);
            WriteAttributeValue(" ", 54, "sidebar-shadow", 55, 15, true);
#nullable restore
#line 2 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
WriteAttributeValue(" ", 69, Model.SidebarClass, 70, 19, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n    <div class=\"app-header__logo\">\r\n");
            WriteLiteral(@"        <div class=""header__pane ml-auto"">
            <div>
                <button type=""button"" class=""hamburger close-sidebar-btn hamburger--elastic"" data-class=""closed-sidebar"">
                    <span class=""hamburger-box"">
                        <span class=""hamburger-inner""></span>
                    </span>
                </button>
            </div>
        </div>
    </div>
    <div class=""app-header__mobile-menu"">
        <div>
            <button type=""button"" class=""hamburger hamburger--elastic mobile-toggle-nav"">
                <span class=""hamburger-box"">
                    <span class=""hamburger-inner""></span>
                </span>
            </button>
        </div>
    </div>
    <div class=""app-header__menu"">
        <span>
            <button type=""button"" class=""btn-icon btn-icon-only btn btn-primary btn-sm mobile-toggle-header-nav"">
                <span class=""btn-icon-wrapper"">
                    <i class=""fa fa-ellipsis-v fa-w-6""></i>
              ");
            WriteLiteral("  </span>\r\n            </button>\r\n        </span>\r\n    </div>\r\n    <div class=\"scrollbar-sidebar ps ps--active-y\">\r\n        <div class=\"app-sidebar__inner\">\r\n            <ul id=\"menu\" class=\"vertical-nav-menu metismenu\">\r\n");
#nullable restore
#line 38 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
                 if (Model.listMenu != null)
                {
                    var parentList = Model.listMenu.Where(x => x.ParentId == 0 && x.Level == 1).OrderBy(x => x.Position).ToList();
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
                     foreach (var parent in parentList)
                    {
                        var childList = Model.listMenu.Where(x => x.ParentId == parent.MenuId).OrderBy(x => x.Position).ToList();
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
                         if (childList.Count == 0)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li>\r\n");
#nullable restore
#line 47 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
                                  var area = parent.ControllerName.ToLower() == "account" ? "" : "/Admin"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <a");
            BeginWriteAttribute("href", " href=\"", 2112, "\"", 2166, 5);
#nullable restore
#line 48 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
WriteAttributeValue("", 2119, area, 2119, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2124, "/", 2124, 1, true);
#nullable restore
#line 48 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
WriteAttributeValue("", 2125, parent.ControllerName, 2125, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2147, "/", 2147, 1, true);
#nullable restore
#line 48 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
WriteAttributeValue("", 2148, parent.ActionName, 2148, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 2167, "\"", 2254, 7);
            WriteAttributeValue("", 2177, "removeActiveClass(", 2177, 18, true);
#nullable restore
#line 48 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
WriteAttributeValue("", 2195, childList.Count, 2195, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2211, ",`", 2211, 2, true);
#nullable restore
#line 48 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
WriteAttributeValue("", 2213, parent.MenuName, 2213, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2229, "`,``,`", 2229, 6, true);
#nullable restore
#line 48 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
WriteAttributeValue("", 2235, parent.MenuIcon, 2235, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2251, "`);", 2251, 3, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <i");
            BeginWriteAttribute("class", " class=\"", 2296, "\"", 2335, 2);
            WriteAttributeValue("", 2304, "metismenu-icon", 2304, 14, true);
#nullable restore
#line 49 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
WriteAttributeValue(" ", 2318, parent.MenuIcon, 2319, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>");
#nullable restore
#line 49 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
                                                                              Write(parent.MenuName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("                                </a>\r\n                            </li>\r\n");
#nullable restore
#line 53 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li");
            BeginWriteAttribute("id", " id=\"", 2653, "\"", 2677, 2);
            WriteAttributeValue("", 2658, "menu_", 2658, 5, true);
#nullable restore
#line 56 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
WriteAttributeValue("", 2663, parent.MenuId, 2663, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 2678, "\"", 2724, 3);
            WriteAttributeValue("", 2688, "menu.SetMenuInCookie(", 2688, 21, true);
#nullable restore
#line 56 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
WriteAttributeValue("", 2709, parent.MenuId, 2709, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2723, ")", 2723, 1, true);
            EndWriteAttribute();
            BeginWriteAttribute("class", " class=\"", 2725, "\"", 2750, 1);
#nullable restore
#line 56 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
WriteAttributeValue("", 2733, parent.ClassName, 2733, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <a href=\"javascript:void(0);\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2815, "\"", 2902, 7);
            WriteAttributeValue("", 2825, "removeActiveClass(", 2825, 18, true);
#nullable restore
#line 57 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
WriteAttributeValue("", 2843, childList.Count, 2843, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2859, ",`", 2859, 2, true);
#nullable restore
#line 57 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
WriteAttributeValue("", 2861, parent.MenuName, 2861, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2877, "`,``,`", 2877, 6, true);
#nullable restore
#line 57 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
WriteAttributeValue("", 2883, parent.MenuIcon, 2883, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2899, "`);", 2899, 3, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                    <i");
            BeginWriteAttribute("class", " class=\"", 2944, "\"", 2983, 2);
            WriteAttributeValue("", 2952, "metismenu-icon", 2952, 14, true);
#nullable restore
#line 58 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
WriteAttributeValue(" ", 2966, parent.MenuIcon, 2967, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></i>");
#nullable restore
#line 58 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
                                                                              Write(parent.MenuName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                    <i class=\"metismenu-state-icon fa fa-angle-down caret-left opacity-5\"></i>\r\n                                </a>\r\n\r\n");
#nullable restore
#line 62 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
                                 foreach (var child in childList)
                                {
                                    var area = child.ControllerName.ToLower() == "account" ? "" : "/Admin";

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <ul");
            BeginWriteAttribute("class", " class=\"", 3409, "\"", 3445, 2);
            WriteAttributeValue("", 3417, "mm-collapse", 3417, 11, true);
#nullable restore
#line 65 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
WriteAttributeValue(" ", 3428, child.ClassName, 3429, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                                        <li>\r\n                                            <a");
            BeginWriteAttribute("href", " href=\"", 3541, "\"", 3593, 5);
#nullable restore
#line 67 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
WriteAttributeValue("", 3548, area, 3548, 5, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3553, "/", 3553, 1, true);
#nullable restore
#line 67 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
WriteAttributeValue("", 3554, child.ControllerName, 3554, 21, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3575, "/", 3575, 1, true);
#nullable restore
#line 67 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
WriteAttributeValue("", 3576, child.ActionName, 3576, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("id", " id=\"", 3594, "\"", 3617, 2);
            WriteAttributeValue("", 3599, "menu_", 3599, 5, true);
#nullable restore
#line 67 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
WriteAttributeValue("", 3604, child.MenuId, 3604, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 3618, "\"", 3719, 9);
            WriteAttributeValue("", 3628, "menu.SubMenuActive(", 3628, 19, true);
#nullable restore
#line 67 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
WriteAttributeValue("", 3647, child.MenuId, 3647, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3660, ",`", 3660, 2, true);
#nullable restore
#line 67 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
WriteAttributeValue("", 3662, parent.MenuTitle, 3662, 17, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3679, "`,`", 3679, 3, true);
#nullable restore
#line 67 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
WriteAttributeValue("", 3682, child.MenuTitle, 3682, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3698, "`,`", 3698, 3, true);
#nullable restore
#line 67 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
WriteAttributeValue("", 3701, parent.MenuIcon, 3701, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3717, "`)", 3717, 2, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                                <i class=\"metismenu-icon\"></i> ");
#nullable restore
#line 68 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
                                                                          Write(child.MenuName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </a>\r\n                                        </li>\r\n                                    </ul>\r\n");
#nullable restore
#line 72 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </li>\r\n");
#nullable restore
#line 74 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 74 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
                         

                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 76 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Shared\Components\Menu\Menu.cshtml"
                     
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </ul>


        </div>
        <div class=""ps__rail-x"" style=""left: 0px; bottom: 0px;"">
            <div class=""ps__thumb-x"" tabindex=""0"" style=""left: 0px; width: 0px;""></div>
        </div>
        <div class=""ps__rail-y"" style=""top: 0px; height: 533px; right: 0px;"">
            <div class=""ps__thumb-y"" tabindex=""0"" style=""top: 0px; height: 300px;""></div>
        </div>
    </div>
</div>

<script>

    $(document).ready(function() {
        var menuId = sessionStorage.getItem(""ActiveSubMenu"");
        if (menuId != null || menuId != undefined) {
            $(`#menu_` + menuId).addClass('menu-active');
        }
        //else {
        //    $(`#menu_` + menuId).removeClass('menu-active');
        //}

        //$('#menu li').each(function () {
        //    if ($(this).hasClass(""mm-active"")) {
        //        $(this).removeClass(""mm-active"")
        //        if ($(this).children(""ul"").hasClass(""mm-show"")) {
        //            $(this).children(""ul"").removeClass(");
            WriteLiteral(@"""mm-show"")
        //        }
        //    }

          
        //});
        //$('#menu li a').each(function () {
        //    $(this).attr(""aria-expanded"", false);
        //});

    });

    function removeActiveClass(cnt, firstLevelMenuName, secondLevelMenuName,menuicon) {
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
