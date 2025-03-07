using Microsoft.AspNetCore.Http;

namespace MovieReservation.Service.Abstracts
{
    public interface IFileService
    {
        public Task<string> UploadImageAsync(string Location, IFormFile file);
        public string DeleteImage(string Location);
        public bool ImageExists(string Location);
    }
}
