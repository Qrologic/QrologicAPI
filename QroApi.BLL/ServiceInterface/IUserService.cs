using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QroApi.MODEL;
using System.Linq.Expressions;

namespace QroApi.BLL
{
    public interface IUserService : IDisposable
    {
       public Task<Result> User_Register(UserRegistration model);
       public Task<Result> GetSponserDetails(string SponsorId);
    }
}
