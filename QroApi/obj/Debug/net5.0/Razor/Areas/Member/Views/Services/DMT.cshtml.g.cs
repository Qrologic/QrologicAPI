#pragma checksum "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Services\DMT.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e6aec6cbed758ae07b888be5c049f9b60de5d108"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Member_Views_Services_DMT), @"mvc.1.0.view", @"/Areas/Member/Views/Services/DMT.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e6aec6cbed758ae07b888be5c049f9b60de5d108", @"/Areas/Member/Views/Services/DMT.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33fefbd7ed14aa6beb546f1934b71252e92fbd33", @"/Areas/Member/Views/_ViewImports.cshtml")]
    public class Areas_Member_Views_Services_DMT : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("f1"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/CustomJS/DMT.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\Project\Recharge\QrologicApi-Latest\QroApi\QroApi\Areas\Member\Views\Services\DMT.cshtml"
  
    ViewData["Title"] = "DMT";
    Layout = "~/Areas/Member/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div class=\"col-sm-12\">\r\n    <div class=\"card card-body\" style=\"border-radius: 0px 0px 6px 6px;margin-bottom: 0px;\">\r\n        <div style=\"background-color:#fff;\" class=\"dmt-form add-bene-wrapper\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e6aec6cbed758ae07b888be5c049f9b60de5d1086444", async() => {
                WriteLiteral(@"
                <div class=""bene-list-wrapper"">
                    <div class=""row"">
                        <div class=""col-lg-12"">
                            <div class=""stepper-row"">
                                <h4>
                                    <span class=""color-black"">Domestic Money Transfer(DMT) </span>
                                </h4>
                                <div class=""heading-right-sec"" id=""dv-rem-detail"" style=""display:none;"">
                                    <div class=""sec"">
                                        <p>Name <span class=""text-secondary"" id=""sp-reg-rem-name""></span></p>
                                    </div>
                                    <div class=""sec"">
                                        <p>
                                            Total Limit<span class=""color-green"">
                                                <i class=""icon-rupee fs-10 pos-unset fa fa-rupee""></i>
                                                <s");
                WriteLiteral(@"pan class=""color-green"" id=""reg-rem-total-limit""></span>
                                            </span>
                                        </p>
                                    </div>
                                    <div class=""sec"">
                                        <p>
                                            Available Limit<span class=""text-danger"">
                                                <i class=""fa fa-rupee icon-rupee fs-10 pos-unset""></i>
                                                <span class=""text-danger"" id=""reg-rem-avl-limit""></span>
                                            </span>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div class=""f1-steps"" style=""display:none;"">
                    <div class=""f1-pr");
                WriteLiteral(@"ogress"">
                        <div class=""f1-progress-line"" data-now-value=""12.5"" data-number-of-steps=""4"" style=""width: 12.5%;""></div>
                    </div>
                    <div class=""f1-step active"">
                        <div class=""f1-step-icon"">1</div>
                    </div>
                    <div class=""f1-step"">
                        <div class=""f1-step-icon"">2</div>
                    </div>
                    <div class=""f1-step"">
                        <div class=""f1-step-icon"">3</div>
                    </div>
                    <div class=""f1-step"">
                        <div class=""f1-step-icon"">4</div>
                    </div>
                </div>
                <input type=""hidden"" id=""stateresp"" />
                <fieldset id=""field-1"" style=""display:block;"">
                    <div class=""row form-group"">
                        <div class=""col-md-3"">
                            <div class=""form-col pre-input"">
                        ");
                WriteLiteral(@"        <label for=""custMobileNo"">Enter Mobile Number<sup>*</sup></label>
                                <input type=""text"" placeholder=""Number"" class=""form-control"" maxlength=""10"" onkeypress=""return common.isNumberKey(event);"" onfocus=""dmt.ResetValidation('sp-rem-mobile');"" id=""remitter-mobile"" data-val=""true"">
                                <span id=""sp-rem-mobile"" class=""text-danger""></span>
                            </div>
                            <div class=""f1-buttons text-left"">
                                <button type=""button""  class=""btn btn-next btn-primary"" id=""btn-rem"" onclick=""dmt.RemitterDetails();"">Proceed</button>
                            </div>
                        </div>
                    </div>
                </fieldset>

                <fieldset id=""field-2"">
                    <div class=""row form-group"">
                        <div class=""col-12 col-sm-12 col-lg-12"">
                            <div class=""form-col"">
                                <");
                WriteLiteral(@"label for=""customerMobileNo"">Mobile Number</label>
                                <p><label for=""customerMobileNo"" id=""rem-mobile""></label></p>
                            </div>
                        </div>
                        <div class=""col-md-3"">
                            <div class=""form-col"">
                                <label for=""customerFirstName"">First Name <sup>*</sup></label>
                                <input type=""text"" placeholder=""First Name"" id=""rem-fname"" onkeypress=""dmt.ResetValidation('sp-rem-fname');"" class=""form-control"" data-val=""true"">
                                <span id=""sp-rem-fname"" class=""text-danger""></span>
                            </div>
                        </div>
                        <div class=""col-md-3"">
                            <div class=""form-col"">
                                <label for=""customerFirstName"">Last Name<sup>*</sup></label>
                                <input type=""text"" placeholder=""Last Name"" id=""rem-lna");
                WriteLiteral(@"me"" onkeypress=""dmt.ResetValidation('sp-rem-lname');"" class=""form-control"" data-val=""true"">
                                <span id=""sp-rem-lname"" class=""text-danger""></span>
                            </div>
                        </div>
                        <div class=""col-md-3"">
                            <div class=""form-col"">
                                <label for=""customerFirstName"">Date of Birth<sup>*</sup></label>
                                <input type=""date"" class=""form-control"" id=""rem-dob"" onfocus=""dmt.ResetValidation('sp-rem-dob');"" data-val=""true"">
                                <span id=""sp-rem-dob"" class=""text-danger""></span>
                            </div>
                        </div>
                        <div class=""col-md-3"">
                            <div class=""form-col"">
                                <label for=""customerFirstName"">Address<sup>*</sup></label>
                                <input type=""text"" placeholder=""Address"" id=""rem-address""");
                WriteLiteral(@" onkeypress=""dmt.ResetValidation('sp-rem-address');"" class=""form-control"" data-val=""true"">
                                <span id=""sp-rem-address"" class=""text-danger""></span>
                            </div>
                        </div>
                        <div class=""col-md-3"">
                            <div class=""form-col"">
                                <label for=""customerFirstName"">Pin Code <sup>*</sup></label>
                                <input type=""text"" placeholder=""Pin Code"" maxlength=""6"" onkeypress=""return common.isNumberKey(event);"" onfocus=""dmt.ResetValidation('sp-rem-pincode');"" id=""rem-pincode"" class=""form-control"" data-val=""true"">
                                <span id=""sp-rem-pincode"" class=""text-danger""></span>
                            </div>
                        </div>
                        <div class=""col-md-3"">
                            <div class=""form-col"">
                                <label for=""customerFirstName"">OTP<sup>*</sup></label>
");
                WriteLiteral(@"                                <input type=""text"" placeholder=""OTP"" onkeypress=""return common.isNumberKey(event);"" onfocus=""dmt.ResetValidation('sp-rem-otp');"" id=""rem-otp"" class=""form-control"" data-val=""true"">
                                <span id=""sp-rem-otp"" class=""text-danger""></span>
                            </div>
                        </div>
                    </div>
                    <div class=""f1-buttons text-left"">
                        <button type=""button"" class=""btn btn-next btn-primary"" id=""btn-rem-reg"" onclick=""dmt.RemitterRegistration()"">Submit</button>
                    </div>
                </fieldset>
                <fieldset id=""field-3"">

                    <div class=""add-beneficiary add-account-number-2"">
                        <div class=""recharge-cols-lt"">
                            <div class=""row form-group"">
                                <div class=""col-12 col-sm-12 col-lg-12"">
                                    <div class=""form-col beneficia");
                WriteLiteral("ry\">\r\n                                        <div class=\"account-beneficery\">\r\n");
                WriteLiteral(@"                                            <h5 class=""recharge-bill-payment--form-head  d-lg-inline-block"">Add Beneficiary</h5>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class=""row form-group"">
                                <div class=""col-12 col-sm-12 col-lg-12"">
                                    <div class=""form-col margin-class"">
                                        <div class=""mat-form-field-infix account-beneficery"">
                                            <label for=""customerFirstName"">Beneficiary Account Number <sup>*</sup></label>
                                            <input type=""text"" placeholder=""Beneficiary Account Number"" id=""reg-bene-account"" onkeypress=""dmt.ResetValidation('sp-val-beneaccount');"" class=""form-control"" data-val=""true"">
                                            <span id=""sp-val-beneaccount"" class");
                WriteLiteral(@"=""text-danger""></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=""row form-group"">
                                <div class=""col-12 col-sm-12 col-lg-12"">
                                    <div class=""form-col margin-class"">
                                        <label for=""customerFirstName"">Select Bank   <sup>*</sup></label>
                                        <select class=""form-control select2"" name=""bankname"" id=""reg-bene-bank"" onchange=""dmt.GetIfsc(this.value)"">
                                        </select>
                                        <span id=""sp-val-benebank"" class=""text-danger""></span>
                                    </div>
                                </div>
                            </div>
                            <div class=""row form-group"">
                                <div class=""co");
                WriteLiteral(@"l-12 col-sm-12 col-lg-12"">
                                    <div class=""form-col margin-class ifsc-btn"">
                                        <label for=""customerFirstName"">IFSC<sup>*</sup></label>
                                        <input type=""text"" placeholder=""IFSC"" id=""reg-bene-ifsc"" onkeypress=""dmt.ResetValidation('sp-val-beneifsc');"" class=""form-control"" data-val=""true"">
                                        <span id=""sp-val-beneifsc"" class=""text-danger""></span>
");
                WriteLiteral(@"                                    </div>
                                </div>
                            </div>
                            <div class=""row form-group"">
                                <div class=""col-12 col-sm-12 col-lg-12"">
                                    <div class=""form-col margin-class"">
                                        <div class=""mat-form-field-infix account-beneficery"">
                                            <label for=""customerFirstName"">Beneficiary Name <sup>*</sup></label>
                                            <input type=""text"" placeholder=""Beneficiary Name"" id=""reg-bene-name"" onkeypress=""dmt.ResetValidation('sp-val-benename');"" class=""form-control"" data-val=""true"">
                                            <span id=""sp-val-benename"" class=""text-danger""></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                 ");
                WriteLiteral(@"           <div class=""row form-group"">
                                <div class=""col-12 col-sm-12 col-lg-12"">
                                    <div class=""form-col margin-class"">
                                        <div class=""mat-form-field-infix account-beneficery"">
                                            <label for=""customerFirstName"">DOB <sup>*</sup></label>
                                            <input type=""date"" placeholder=""DOB"" id=""reg-bene-dob"" onkeypress=""dmt.ResetValidation('sp-val-benedob');"" class=""form-control"" data-val=""true"">
                                            <span id=""sp-val-benedob"" class=""text-danger""></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=""row form-group"">
                                <div class=""col-12 col-sm-12 col-lg-12"">
                                    <div class=""for");
                WriteLiteral(@"m-col margin-class"">
                                        <div class=""mat-form-field-infix account-beneficery"">
                                            <label for=""customerFirstName"">Address <sup>*</sup></label>
                                            <input type=""text"" placeholder=""Address"" id=""reg-bene-address"" onkeypress=""dmt.ResetValidation('sp-val-beneaddress');"" class=""form-control"" data-val=""true"">
                                            <span id=""sp-val-beneaddress"" class=""text-danger""></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=""row form-group"">
                                <div class=""col-12 col-sm-12 col-lg-12"">
                                    <div class=""form-col margin-class"">
                                        <div class=""mat-form-field-infix account-beneficery"">
                             ");
                WriteLiteral(@"               <label for=""customerFirstName"">Pincode <sup>*</sup></label>
                                            <input type=""text"" placeholder=""Pincode"" id=""reg-bene-pincode"" onkeypress=""dmt.ResetValidation('sp-val-benepincode');"" class=""form-control"" data-val=""true"">
                                            <span id=""sp-val-benepincode"" class=""text-danger""></span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=""row form-group"">
                                <div class=""col-6 col-sm-6 col-lg-6"">
                                    <div class=""f1-buttons text-left"">
                                        <button type=""button"" class=""btn btn-success""  id=""btn-bene-verify"" onclick=""dmt.VerifyBeneficiary()"">Verify</button>
                                    </div>
                                </div>
                               ");
                WriteLiteral(@" <div class=""col-6 col-sm-6 col-lg-6"">
                                    <div class=""f1-buttons text-right"">
                                        <button type=""button"" class=""btn btn-previous btn-primary"" onclick=""dmt.RegisterBeneficiary()"" id=""btn-bene-reg"">Submit</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""recharge-cols-rt"">
                            <div class=""last-recharge ng-star-inserted"" id=""style-3"">
                                <h4 class=""head--h5 head--h5-mobile ng-star-inserted""> Beneficiary</h4>
                                <div class=""loader-center"">
                                    <div class=""loader4""></div>
                                </div>
                                <ul id=""bene-list"">
                                </ul>
                            </div>
                        </div>
               ");
                WriteLiteral(@"         <div class=""clear""></div>
                    </div>
                   
                </fieldset>
                <fieldset id=""field-4"">
                    <div class=""row form-group"">
                        <div class=""col-12 col-lg-6"">
                            <div class=""form-col"">
                                <label for=""customerFirstName"">Beneficiary Name</label>
                                <p id=""p-b-name"">ManojSaini </p>
                                <input type=""hidden"" id=""hdn-b-name"" />
                            </div>
                        </div>
                        <div class=""col-12 col-lg-6"">
                            <div class=""form-col"">
                                <label for=""customerFirstName"">Account Number</label>
                                <p id=""p-b-accno"">54638100008092</p>
                                <input type=""hidden"" id=""hdn-b-accno"" />
                            </div>
                        </div>
          ");
                WriteLiteral(@"              <div class=""col-12 col-lg-6"">
                            <div class=""form-col"">
                                <label for=""customerFirstName"">Bank Name</label>
                                <p id=""p-b-bank"">BANK OF BARODA</p>
                                <input type=""hidden"" id=""hdn-b-bank"" />
                            </div>
                        </div>
                        <div class=""col-12 col-lg-6"">
                            <div class=""form-col"">
                                <label for=""customerFirstName"">IFSC Code   <sup>*</sup></label>
                                <p id=""p-b-ifsc"">BARB0chomux</p>
                                <input type=""hidden"" id=""hdn-b-ifsc"" />
                            </div>
                        </div>
                        <div class=""col-lg-12"" style=""display:none;"">
                            <div class=""form-col"">
                                <label for=""pinCode"">Select Transfer Type</label>
                  ");
                WriteLiteral("              <div class=\"radio-col\">\r\n                                    <label class=\"radio-row m-0 fw-500\">\r\n                                        IMPS\r\n                                        <input type=\"radio\" name=\"IMPS\" value=\"IMPS\"");
                BeginWriteAttribute("checked", " checked=\"", 19074, "\"", 19084, 0);
                EndWriteAttribute();
                WriteLiteral(@">
                                        <span class=""checkmark-radio""></span>
                                    </label>
                                </div>
                                <div class=""radio-col"">
                                    <label class=""radio-row m-0 fw-500"">
                                        NEFT
                                        <input type=""radio"" name=""NEFT"" value=""NEFT"">
                                        <span class=""checkmark-radio""></span>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class=""col-12 col-lg-6"">
                            <div class=""form-col pre-text"">
                                <label for=""pinCode"">
                                    Enter Amount You Wish To Transfer <sup>*</sup>
                                </label>
                                <input type=""text"" id=""amount""");
                WriteLiteral(" name=\"amount\" class=\"gc-w pl-10\" maxlength=\"6\" minlength=\"2\"");
                BeginWriteAttribute("required", " required=\"", 20170, "\"", 20181, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n                                <i class=\"icon-rupee fs-10\"></i>\r\n                                <button type=\"submit\"");
                BeginWriteAttribute("disabled", " disabled=\"", 20304, "\"", 20315, 0);
                EndWriteAttribute();
                WriteLiteral(@" class=""btn btn-disable btn-gc"">Get Charges</button>
                            </div>
                            <span class=""error-text""></span>
                        </div>
                    </div>
                    <div class=""f1-buttons text-left"">
                        <button type=""button"" class=""btn btn-previous btn-light"">Previous</button>
                        <button type=""button"" class=""btn btn-next btn-primary"">Next</button>
                    </div>
                </fieldset>
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n</div>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e6aec6cbed758ae07b888be5c049f9b60de5d10829971", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<script type=""text/javascript"">
    $(document).ready(function () {
        $("".add-account-number-1 #btn-toggle-1"").click(function () {
            $("".add-account-number-1"").addClass(""add-here"");
            $("".add-account-number-2"").removeClass(""add-here"");
        });
    });
    $(document).ready(function () {
        $("".add-account-number-2 #btn-toggle-1"").click(function () {
            $("".add-account-number-2"").addClass(""add-here"");
            $("".add-account-number-1"").removeClass(""add-here"");
        });
    });
</script>

");
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
