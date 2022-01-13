using QroApi.MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.BLL
{
    public interface IAccountService : IDisposable
    { 
        public Task<Result> Login(LoginRequest LoginRequest);

    }
}
