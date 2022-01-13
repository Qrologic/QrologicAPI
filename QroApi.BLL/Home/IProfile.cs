using QroApi.MODEL;
using System;
using System.Threading.Tasks;

namespace QroApi.BLL
{
    public interface IProfile:IDisposable
    {
        Task<ProfileModel> getAdmiProfile(int userId);
    }
}