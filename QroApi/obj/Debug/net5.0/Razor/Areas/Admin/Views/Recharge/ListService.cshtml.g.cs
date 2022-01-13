#pragma checksum "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Recharge\ListService.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f5b4d68a1fbc3c16e5e4e40e28908920c1792e8b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Recharge_ListService), @"mvc.1.0.view", @"/Areas/Admin/Views/Recharge/ListService.cshtml")]
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
#line 2 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Recharge\ListService.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Recharge\ListService.cshtml"
using Newtonsoft.Json.Linq;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f5b4d68a1fbc3c16e5e4e40e28908920c1792e8b", @"/Areas/Admin/Views/Recharge/ListService.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33fefbd7ed14aa6beb546f1934b71252e92fbd33", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Recharge_ListService : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<QroApi.MODEL.ServiceList>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Recharge\ListService.cshtml"
  
    ViewData["Title"] = "List Service";
    Layout = "~/Areas/Admin/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Recharge\ListService.cshtml"
  
    JObject obj = JObject.Parse(JsonConvert.SerializeObject(new ServiceList(), Formatting.Indented, new JsonSerializerSettings
    { PreserveReferencesHandling = PreserveReferencesHandling.Objects }));
    obj.Remove("$id");

    List<string>
    termsList = new List<string>();
    foreach (var columnName in obj)
    {
        termsList.Add(columnName.Key.Trim());
    }
    string[] columnArray = termsList.ToArray();

    ViewData["Title"] = "List Service";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<section class=""content"">
    <div class=""row"">

        <div class=""col-md-12"">

            <div class=""main-card mb-3 card"">
                <div class=""card-body"">
                    <div class=""row"">
                        <div class=""col-md-12 text-right form-group"">
                            <a");
            BeginWriteAttribute("class", " class=\"", 992, "\"", 1000, 0);
            EndWriteAttribute();
            WriteLiteral(" href=\"javascript:void(0);\" data-toggle=\"modal\" data-target=\"#exampleModal\" onclick=\"rc.ServicePopup(0);\">\r\n                                <i class=\"fa fa-plus-circle\"></i>&nbsp;Add New Service\r\n                            </a>\r\n");
            WriteLiteral(@"
                        </div>
                        <div class=""col-md-12"">
                            <div class=""table-responsive"">
                                <table id=""myTable"" class=""display nowrap dataTable dtr-inline collapsed "">
                                    <thead>
                                        <tr>
");
#nullable restore
#line 51 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Recharge\ListService.cshtml"
                                             foreach (var item in columnArray)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <th>");
#nullable restore
#line 53 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Recharge\ListService.cshtml"
                                               Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n");
#nullable restore
#line 54 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Admin\Views\Recharge\ListService.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                        </tr>
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
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n\r\n    <script>\r\n        $(document).ready(function () {\r\n            menu.BindBreadCrumb(0);\r\n            table.BindPostTable(`/Admin/Recharge/LoadServiceList`, `myTable`);\r\n        });\r\n    </script>\r\n");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QroApi.MODEL.ServiceList> Html { get; private set; }
    }
}
#pragma warning restore 1591
