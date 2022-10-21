//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Ksb.Domain;
//using Ksb.BusinessObject;

//namespace Ksb.Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class ChildrenController : ControllerBase
//    {
//        private readonly IChildrenBO _context;

//        public ChildrenController(IChildrenBO context)
//        {
//            _context = context;
//        }

//        // GET: api/Children
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Children>>> GetChildren()
//        {
//            var item = await _context.GetAllAsync();
//            return Ok(item);
//        }

//        // GET: api/Children/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Children>> GetChildren(int id)
//        {
//            var children = await _context.GetByIdAsync(id);

//            if (children == null)
//            {
//                return NotFound();
//            }

//            return children;
//        }

//        // PUT: api/Children/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutChildren(int id, Children children)
//        {
//            if (id != children.Id)
//            {
//                return BadRequest();
//            }

//            try
//            {
//                await _context.UpdateAsync(children);
//            }
//            catch (Exception )
//            {
//                throw;
//            }

//            return NoContent();
//        }

//        // POST: api/Children
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<Children>> PostChildren(Children children)
//        {
//            await _context.AddAsync(children);

//            return children;
//        }

//        // DELETE: api/Children/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteChildren(int id)
//        {
//            await _context.DeleteAsync(id);
//            return NoContent();
//        }

//    }
//}
