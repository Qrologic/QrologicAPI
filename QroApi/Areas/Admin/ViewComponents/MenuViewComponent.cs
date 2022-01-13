using QroApi.BLL;
using QroApi.Core;
using QroApi.MODEL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QroApi.Areas.Admin.ViewComponents
{
    [ViewComponent(Name = "Menu")]
    public class MenuViewComponent:ViewComponent
    {
        private readonly IMenu _iMenu;
        private readonly ICookies _iCookies;

        MenuModel model = new MenuModel();
        List<MenuModel> ListMenu = new List<MenuModel>();
        public MenuViewComponent(IMenu imenu, ICookies iCookies)
        {
            _iMenu = imenu;
            _iCookies = iCookies;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menuId = _iCookies.GetCookie("ActiveMenu");
            var model =await  _iMenu.BindAdminMenu(User.Identity.GetDetailOf("UserId"));
            if (menuId != null && model.listMenu !=null)
            {
                model.listMenu.Where(w => w.MenuId == Convert.ToInt32(menuId)).ToList().ForEach(i => i.ClassName = "mm-active");                
                model.listMenu.Where(w => w.ParentId == Convert.ToInt32(menuId)).ToList().ForEach(i => i.ClassName = "mm-show");
            }
            return await Task.FromResult((IViewComponentResult)View("Menu", model));
        }
    }
}
