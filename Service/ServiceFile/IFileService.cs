using Common.ApiResult;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.ServiceFile
{
    public interface IFileService
    {
        string Save(IFormFile file,string Folder);
        ServiceResult Delete(string fileName, string Folder);
    }
}
