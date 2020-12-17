using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Data;
using WebApplication2.Data.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("applicatioin/json")]
    public class ProductsController : ControllerBase
    {
        private readonly IApplicationRepository _repository;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IApplicationRepository repository, ILogger<ProductsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        [Produces("application/json")]
        public ActionResult<IEnumerable<Product>> Get()
        {
            try
            {
                var result = _repository.GetAllProducts();
                return Ok(result);
            }
            catch(Exception ex) 
            {
                _logger.LogError($"Failed to get products: {ex}");
                return BadRequest("Failed to get products");
            
            }
          
        }



    }
}
