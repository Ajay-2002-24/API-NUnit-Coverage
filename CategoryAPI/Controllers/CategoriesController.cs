using Microsoft.AspNetCore.Http;        
using Microsoft.AspNetCore.Mvc;          //-------API LAYER (Controller)-----------
using CategoryServices;
using CategoryModels;

namespace CategoryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _service;    //--->DI Injected service
        public CategoriesController(ICategoryService service) { _service = service; }
        [HttpGet] public IActionResult GetAll() => Ok(_service.GetAll());  // For GET all -- Calls business logic
        [HttpGet("{id}")]
        public IActionResult GetById(int id)  // GET by ID
        {                     
            var cat = _service.GetById(id);
            if (cat == null) return NotFound();
            return Ok(cat);
        }
        [HttpGet("search")]
        public IActionResult Search([FromQuery] string name) =>   // Search
            Ok(_service.SearchByName(name ?? ""));

        [HttpPost]
        public IActionResult Add(Category category)
        {
            try
            {
                var added = _service.Add(category);
                return CreatedAtAction(nameof(GetById), new { id = added.CategoryID }, added);
            }
            catch (Exception ex)
            {
                // Add logging for diagnostics and return error message in the response
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]        // PUT
        public IActionResult Update(int id, Category category)
        {    
            if (id != category.CategoryID) return BadRequest();
            var updated = _service.Update(category);
            if (!updated) return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {                  
            var deleted = _service.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}
