using QroApi.MODEL;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QroApi.BLL
{
   public interface ICommonClass:IDisposable
    {
        Task<Result> AddEditLayout(LayoutModel model);
        Task<Result> GetLayout(int msrNo);
        Task<string> UploadImage(string path, IFormFile imageFile);
        Task<string> UploadFevicon(string path, IFormFile imageFile);
    }
}
