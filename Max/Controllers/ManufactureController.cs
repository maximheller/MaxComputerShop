using Max.Data;
using Max.Models;
using Max.Models.viewModels;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Max.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManufacturerController : Controller
    {
        IRepository repository;
        
        public ManufacturerController(IRepository repository)
        {
            this.repository = repository;           
        }               


        [HttpGet]   // GET /manufacture
        public IEnumerable<Manufacturer> Index()
        {
            IEnumerable<Manufacturer> manufacturers = repository.Manufacturers;
            return manufacturers;
        }

      

    }
}
