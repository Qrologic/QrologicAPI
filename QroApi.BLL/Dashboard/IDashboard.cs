using QroApi.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.BLL
{
    public interface IDashboard:IDisposable
    {
        Task<DashboardModel> GetAdminDashboardByMsrNo(int msrno);
        Task<DashboardModel> GetMemberDashboardByMsrNo(int msrno);
    }
}
