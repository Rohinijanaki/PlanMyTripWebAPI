using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanMyTrip.Data;
using PlanMyTrip.Models;

namespace PlanMyTrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackageImageController : ControllerBase
    {
        private readonly PMTDbContext Database;
        private readonly IWebHostEnvironment _hostEnvironment;
        public PackageImageController(PMTDbContext Database, IWebHostEnvironment hostEnvironment)
        {
            this.Database = Database;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Image
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await Database.PackageImageTable.ToListAsync());
        }

        [HttpPost]

        public async Task<IActionResult> Create([Bind("ImageId,ImageName")] PackageImage imageModel)
        {
            if (ModelState.IsValid)
            {
                //Save image to wwwroot/image
                string wwwRootPath = _hostEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
                string extension = Path.GetExtension(imageModel.ImageFile.FileName);
                imageModel.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await imageModel.ImageFile.CopyToAsync(fileStream);
                }
                //Insert record
                Database.Add(imageModel);
                await Database.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return Ok(imageModel);

        }
    }
}
