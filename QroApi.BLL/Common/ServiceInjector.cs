using System;
using System.Collections.Generic;
using System.Text;
using QroApi.Service;
using QroApi.BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using QroApi.DLL;


namespace QroApi.BLL
{
    public class ServiceInjector
    {
        public ServiceInjector(IServiceCollection services)
        {
            services.AddScoped(typeof(IAccountService), typeof(AccountService));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(ISQLHelper), typeof(SQLHelper));
            services.AddScoped(typeof(IUtilityService), typeof(UtilityService));
            services.AddScoped(typeof(IMenu), typeof(Menu));
            services.AddScoped(typeof(IRecharge), typeof(Recharge));
            services.AddScoped(typeof(IUtility), typeof(Utility));
            services.AddScoped(typeof(IMember), typeof(Member));
            services.AddHttpContextAccessor();
            services.AddScoped(typeof(ICookies), typeof(Cookies));
            services.AddScoped(typeof(IWallet), typeof(Wallet));
            services.AddScoped(typeof(IMemberService), typeof(MemberService));
            services.AddScoped(typeof(ISettings), typeof(Settings));
            services.AddScoped(typeof(ICommonClass), typeof(CommonClass));
            services.AddScoped(typeof(IDMT), typeof(DMT));
            services.AddScoped(typeof(IDashboard), typeof(Dashboard));
            services.AddScoped(typeof(IProfile), typeof(Profile));
            services.AddScoped(typeof(IdmtApiService), typeof(dmtApiService));
        }
    }
}
