using TasksApi.Models;

namespace TasksApi.Services
{
    public interface IFiles
    {
        Task<FilesModel> UploadFile(FilesModel file);

        Task<string> UploadImage(IFormFile file);
    }
}
