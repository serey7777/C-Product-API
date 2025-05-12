using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductWebAPI_With_DB.DataCon;
using ProductWebAPI_With_DB.models;

namespace ProductWebAPI_With_DB.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public object Get()
        {
            int count = _context.Products.ToList().Count;

            if (count > 0)
            {
                return Ok(_context.Products.ToList());
            }
            else
            {
                return NotFound("Product is Empty");
            }
        }
        [HttpGet("{id}"), HttpGet("id={id}")]
        public object Get(int id)
        { 
            var pros = _context.Products.FirstOrDefault(x => x.Id == id);
            if (pros != null)
            {
                return Ok(pros);
            }
            else
            {
                return NotFound($"Product id = {id} not found");
            }
        }
        [HttpGet("name = {name}")]
        public object Post(string name)
        {
            var pros = _context.Products.Where(x => x.Name.ToLower() == name.ToLower()).ToList();
            if (pros != null || pros.Count() == 0)
            {
                return NotFound($"Product Name = {name} not found");
            }
            
            return Ok(pros);

        }

        [HttpPost]
        public object Save([FromBody] Product product)
        {
            product.Id = 0;
            _context.Products.Add(product);
            _context.SaveChanges();

            // Fix for CS1501: Use the CreatedAtAction method to provide the location of the created resource
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }
        [HttpPut]
        public object Put(int id, [FromBody] Product product)
        {
            var pro = _context.Products.FirstOrDefault(x => x.Id == id);
            if (pro != null)
            {
                pro.Name = product.Name;
                pro.Price = product.Price;
                pro.Qty = product.Qty;
                _context.SaveChanges();
                return Ok(pro);
            }
            else
            {
                product.Id = 0;
                _context.Products.Add(product);
                _context.SaveChanges();
                return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
            }
        }
        [HttpDelete("{id}"), HttpDelete("id={id}")]
        public object Delete(int id)
        {
            var pro = _context.Products.FirstOrDefault(x => x.Id == id);
            if (pro != null) { 
                _context.Products.Remove(pro);
                _context.SaveChanges();
                return Ok(pro);
            }
            else
            {
                return NotFound($"Product id = {id} not found");
            }
        }
    }
}
