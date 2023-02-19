using Common.ApiResult;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace Service.ServiceFile
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _environment;
        public FileService(IWebHostEnvironment environment)
        {
            _environment= environment;
        }
        public ServiceResult Delete(string fileName, string Folder)
        {
            try
            {

                var Path = $"{_environment.WebRootPath}\\File\\{Folder}\\{fileName}"; ;
                if (File.Exists(Path))
                {
                    File.Delete(Path);
                    return new ServiceResult(ResponseStatus.Success,null);
                }
                else
                {
                    return new ServiceResult(ResponseStatus.NotFound,null);
                }
            }
            catch (Exception)
            {
                return new ServiceResult(ResponseStatus.ServerError,null);

            }
        }
        public string Save(IFormFile file, string Folder)
        {
            try
            {
                FileInfo fileinfo = new FileInfo(file.Name);
                var extes= file.FileName.Split('.');
                var fileName = Guid.NewGuid()+"."+extes[1];
                var FolderDiyrectory = $"{_environment.WebRootPath}\\File\\{Folder}";
                var Paht = Path.Combine(FolderDiyrectory, fileName);
                var MemoryStream = new MemoryStream();
                file.OpenReadStream().CopyToAsync(MemoryStream);
                if (!Directory.Exists(FolderDiyrectory))
                {
                    Directory.CreateDirectory(FolderDiyrectory);
                }
                 using (var filesave = new FileStream(Paht, FileMode.Create, FileAccess.Write))
                {
                    MemoryStream.WriteTo(filesave);
                }
                return fileName;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
