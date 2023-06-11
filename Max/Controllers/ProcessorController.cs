using Max.Data;
using Max.Models;
using Max.Data;
using Max.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Max.Models.viewModels;
using System.ComponentModel.DataAnnotations.Schema;

namespace Max.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProcessorController : Controller
    {

        private IRepository repository; // field 
        public ProcessorController(IRepository repository) // repository
        {
            this.repository = repository;
        }

        //private void TestOneToMany()
        //{
        //    Manufacturer? manufacturer = repository.Manufacturers.FirstOrDefault(m => m.Id == 3); // Intel 

        //    // var intelProcessors = manufacturer.Processors; // TODO

        //    var intelProcessors = repository.Processors.Where(p => p.ManufacturerId == 3);
        //}


        //// database -> context -> repository -> controller -> view
        //private void TestManyToMany()
        //{
        //    repository.AddProcessorToCategory(1, 2);
        //}



        //public IActionResult Index()
        //{
        //    // TestOneToMany(); // HOMETASK
        //    // TestManyToMany();

        //    //if(HttpContext.Session.GetString("Login") == null)
        //    //{
        //    //    return RedirectToAction("Login", "User");
        //    //}

        //    IEnumerable<Processor> processors = repository.Processors;
        //    return View(processors);
        //}
        //===========================================================================================

        //[HttpGet]
        //public IActionResult AddProcessorToCategory()
        //{
        //    ViewBag.Processors = repository.Processors;
        //    ViewBag.Categories = repository.Categories;
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult AddProcessorToCategory(int ProcessorId, int CategoryId)
        //{
        //    ViewBag.Processors = repository.Processors;
        //    ViewBag.Categories = repository.Categories;
        //    repository.AddProcessorToCategory(ProcessorId, CategoryId);
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult AddCategories(int id)
        //{
        //    ViewBag.Processors = repository.Processors;
        //    ViewBag.Categories = repository.Categories;
        //    Processor? processor = repository.Processors.FirstOrDefault(p => p.Id == id);
        //    return View(processor);
        //}

        ////[HttpPost]
        ////public IActionResult AddCategories(int[] categoryIds, Processor processor)  // categories - updated
        ////{
        ////    // TODO in view @if(Model.Catego ... 

        ////    ViewBag.Processors = repository.Processors;
        ////    ViewBag.Categories = repository.Categories;

        ////    // TODO Save Categories  to DB
        ////    // repository.Categories = {1, 2, 3, 4};
        ////    // (processorFromDB.Categories = {2}
        ////    // categoryIds = {1, 3} selected in form


        ////    Processor? processorFromDB = repository.Processors
        ////            .FirstOrDefault(p => p.Id == processor.Id);

        ////    repository.AddCategoriesToProcessor(categoryIds, processorFromDB);

        ////    return View(processorFromDB);
        ////}




        [HttpGet("{id:int}")]
        public Processor? OneProcessor(int id)
        {
             return repository.Processors.SingleOrDefault(p => p.Id == id); // LINQ            
        }


        [HttpGet]  
        public IEnumerable<ProcessorViewModel> Index()
        {
            
            return repository.Processors.Select(p => new ProcessorViewModel
            {
                Description = p.Description,
                Frequency = p.Frequency,
                Name = p.Name
            });            
        }

      







        //[HttpGet]
        //public IActionResult Update(int id)
        //{
        //    ViewBag.Manufacturers = repository.Manufacturers;
        //    Processor? processor = repository.Processors.FirstOrDefault(processor => processor.Id == id);

        //    UpateProcessorViewModel model = new UpateProcessorViewModel
        //    {
        //        Id = processor.Id,
        //        Name = processor.Name,
        //        Description = processor.Description,
        //        Frequency = processor.Frequency
        //    };
        //    return View(model);
        //}


        //[HttpPost]
        //public IActionResult Update(UpateProcessorViewModel processorToUpdate)
        //{
        //    Processor? processor = repository.Processors
        //        .FirstOrDefault(processor => processor.Id == processorToUpdate.Id);
        //    SaveImage(processor, processorToUpdate.ImageFormFile);

        //    processor.Frequency = processorToUpdate.Frequency;
        //    processor.ManufacturerId = processorToUpdate.ManufacturerId;
        //    processor.Name = processorToUpdate.Name;
        //    processor.Description = processorToUpdate.Description;


        //    repository.Update(processor);
        //    ////return RedirectToAction("Index", "Processor");
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    Processor? p = repository.Processors.FirstOrDefault(p => p.Id == id);
        //    return View(p);
        //}



        //private bool Lambda1(Processor p)
        //{
        //    return p.Id == 2;
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var processor = repository.Processors.FirstOrDefault(p => p.Id == id);
        //    if (processor.ImageFileName != null)
        //    {
        //        string filePath = Path.Combine("wwwroot/images", processor.ImageFileName);
        //        System.IO.File.Delete(filePath);
        //    }
        //    repository.Delete(processor);
        //    return RedirectToAction("Index");
        //}


        //// localhost:54345/processor/create
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    ViewBag.Manufacturers = repository.Manufacturers;
        //    return View();
        //}



        [HttpPost]
        public IActionResult Create(ProcessorCreateViewModel model)
        {
            Processor processor = new Processor()
            {
                Name = model.Name,
                ManufacturerId = model.ManufacturerId,
                Description = model.Description,
                Frequency = model.Frequency,               
                Price = model.Price,
            };      
            // SaveImage(processor, processor.ImageFormFile);
            repository.Add(processor);
            return Ok();
        }


        //[HttpPost]
        //public IActionResult Create(RamCreateViewModel model)
        //{
        //    // SaveImage(ram, ram.ImageFormFile);
        //    Ram ram = new Ram
        //    {
        //        Name = model.Name,
        //        ManufacturerId = model.ManufacturerId,
        //        Description = model.Description,
        //        Frequency = model.Frequency,
        //        MemoryCapacity = model.MemoryCapacity,
        //        Price = model.Price,
        //    };
        //    repository.Add(ram);
        //    return Ok();
        //}


        private bool SaveImage(Processor processor, IFormFile formFile)
        {
            string filePath = "";
            string fileName = "";
            // processor.Manufacture = null
            //s =  processor.Manufacture.Name // exception  null.Name
            //  && - logic product, false = 0, true = 1
            if (formFile != null && formFile.Length > 0)
            {
                //Path.GetRandomFileName() = "e0sjauwn.0ma"
                fileName = Path.GetRandomFileName() + ".jpg";
                filePath = Path.Combine("wwwroot/images", fileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    formFile.CopyTo(stream);
                }
                processor.ImageFileName = fileName;
                return true;
            }
            return false;
        }




    }
}
