using Max.Data;
using Max.Models;
using Max.Models.viewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Runtime.InteropServices;

namespace Max.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RamController : Controller
    {
        IRepository repository;
        
        public RamController(IRepository repository)
        {
            this.repository = repository;           
        }
 
        [Authorize(Roles = "user,moderator")]
        [HttpGet]   // GET /ram
        public IEnumerable<Ram> Index()
        {
            IEnumerable<Ram> rams = repository.Rams;
            return rams;
        }

        [Authorize(Roles = "user")]
        [HttpGet("{id:int}")]
        // [HttpGet("{id}")]   // GET /ram/1
        public Ram? OneRam(int id)
        {
            Ram? ram = repository.Rams.FirstOrDefault(ram => ram.Id == id);
            return ram;
        }


        #region

        //[HttpGet]
        //public IActionResult Update(int id)
        //{
        //    ViewBag.Manufacturers = repository.Manufacturers;
        //    Ram? ram = repository.Rams.FirstOrDefault(ram => ram.Id == id);

        //    UpateRamViewModel model = new UpateRamViewModel
        //    {
        //        Id = ram.Id,
        //        Name = ram.Name,
        //        MemoryCapacity = ram.MemoryCapacity,
        //        Frequency = ram.Frequency,
        //        Description = ram.Description,

        //    };
        //    return View(model);
        //}


        //[HttpPost]
        //public IActionResult Update(UpateRamViewModel ramToUpdate)
        //{
        //    Ram? ram = repository.Rams
        //        .FirstOrDefault(ram => ram.Id == ramToUpdate.Id);
        //    SaveImage(ram, ramToUpdate.ImageFormFile);

        //    ram.Name = ramToUpdate.Name;
        //    ram.MemoryCapacity = ramToUpdate.MemoryCapacity;
        //    ram.Frequency = ramToUpdate.Frequency;
        //    ram.Description = ramToUpdate.Description;
        //    ram.ManufacturerId = ramToUpdate.ManufacturerId;


        //    repository.Update(ram);
        //    ////return RedirectToAction("Index", "Processor");
        //    return RedirectToAction("Index");
        //}


        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    Ram? r = repository.Rams.FirstOrDefault(r => r.Id == id);
        //    return View(r);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var ram = repository.Rams.FirstOrDefault(r => r.Id == id);
        //    if(ram.ImageFileName != null)
        //    {
        //        string filePath = Path.Combine("wwwroot/images", ram.ImageFileName);
        //        System.IO.File.Delete(filePath);
        //    }
        //    repository.Delete(ram);
        //    return RedirectToAction("Index");
        //}


        //[HttpGet]
        //public IActionResult Create()
        //{
        //    ViewBag.Manufacturers = repository.Manufacturers;
        //    return View();
        //}
        #endregion
        
        [Authorize(Roles = "moderator")]
        [HttpPost]
        public IActionResult Create(RamCreateViewModel model)
        {
            // SaveImage(ram, ram.ImageFormFile);
            Ram ram = new Ram
            {
                Name = model.Name,
                ManufacturerId = model.ManufacturerId,
                Description = model.Description,
                Frequency = model.Frequency,
                MemoryCapacity = model.MemoryCapacity,    
                Price = model.Price, 
            };
            repository.Add(ram);          
            return Ok();
        }


        private bool SaveImage(Ram ram, IFormFile formFile)
        {
            string filePath = "";
            string fileName = "";
            if (formFile != null && formFile.Length > 0)
            {
                fileName = Path.GetRandomFileName() + ".jpg";
                filePath = Path.Combine("wwwroot/images", fileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    formFile.CopyTo(stream);
                }
                ram.ImageFileName = fileName;
                return true;
            }
            return false;
        }
    }
}
