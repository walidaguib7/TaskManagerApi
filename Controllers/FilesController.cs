
using Microsoft.AspNetCore.Mvc;
using TasksApi.Services;

namespace TasksApi.Controllers
{
    [Route("api/Upload")]
    [ApiController]
    public class FilesController(IFiles filesService) : ControllerBase
    {
        private readonly IFiles _filesService = filesService;


        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var Image = await _filesService.UploadImage(file);
            if (Image == null) return NotFound();
            await _filesService.UploadFile(new Models.FilesModel { Path = Image });
            return Created();
        }
    }
}
