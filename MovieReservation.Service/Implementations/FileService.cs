using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Service.Implementations
{
    public class FileService : IFileService
    {

        #region Fields
        private readonly IWebHostEnvironment _webHostEnvironment;

        #endregion

        #region Constructors
        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }


        #endregion


        #region Functions
        public async Task<string> UploadImageAsync(string Location, IFormFile file)
        {


            if (file != null)
            {
                var Extention = Path.GetExtension(file.FileName);
                var fileName = Guid.NewGuid().ToString().Replace("-", string.Empty) + Extention;
                var path = _webHostEnvironment.WebRootPath + "/" + Location + "/";
                try
                {
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    using (FileStream fileStream = File.Create(path + fileName))
                    {
                        await file.CopyToAsync(fileStream);
                        await fileStream.FlushAsync();
                        return $"/{Location}/{fileName}";

                    }
                }
                catch (Exception)
                {
                    return "FailedToUploadImage";
                }
            }
            else
            {
                return "NoImage";
            }

        }


        public string DeleteImage(string imagePath)
        {
            try
            {
                var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, imagePath.TrimStart('/'));
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                    return "ImageDeleted";
                }
                return "ImageNotFound";
            }
            catch (Exception)
            {
                return "FailedToDeleteImage";
            }
        }


        public bool ImageExists(string Location)
        {
            var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, Location.TrimStart('/'));
            return File.Exists(fullPath);
        }



        #endregion
    }
}
