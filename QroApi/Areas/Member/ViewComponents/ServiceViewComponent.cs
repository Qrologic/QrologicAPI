using QroApi.BLL;
using QroApi.Core;
using QroApi.MODEL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QroApi.Areas.Member.ViewComponents
{
    [ViewComponent(Name = "Service")]
    public class ServiceViewComponent: ViewComponent
    {
        private readonly IMemberService _iMemberService; 
     
        public ServiceViewComponent(IMemberService iMemberService)
        {
            _iMemberService = iMemberService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {          
            var model = await _iMemberService.GetServiceByPackageId(Convert.ToInt32(User.Identity.GetDetailOf("MsrNo")==""?"0": User.Identity.GetDetailOf("MsrNo")));           
            return await Task.FromResult((IViewComponentResult)View("Service", model));
        }
    }
}
