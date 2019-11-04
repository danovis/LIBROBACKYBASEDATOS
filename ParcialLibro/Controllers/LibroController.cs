using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParcialLibro.Models;
namespace ParcialLibro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly LibroContext _context;

         public LibroController(LibroContext context)
{
        _context = context;
       if (_context.libroItems.Count() == 0)
          {
  
       _context.libroItems.Add(new LibroItem {  Titulo = "Priorizar el proyecto", Precio_Venta = 0, Popular= true });
      _context.libroItems.Add(new LibroItem {  Titulo = "Calendario el proyecto", Precio_Venta = 0, Popular = true });
      _context.SaveChanges();
}
}

// GET: api/Task
[HttpGet]
public async Task<ActionResult<IEnumerable<LibroItem>>> GetLibroItems()
{
return await _context.libroItems.ToListAsync();
}

// GET: api/Task/5
[HttpGet("{id}")]
public async Task<ActionResult<LibroItem>> GetLibroItem(int id)
{
var libroItem = await _context.libroItems.FindAsync(id);
if (libroItem == null)
{
return NotFound();
}
return libroItem;
}

// POST: api/Task
[HttpPost]
public async Task<ActionResult<LibroItem>> PostLibroItem(LibroItem item)
{
_context.libroItems.Add(item);
await _context.SaveChangesAsync();
return CreatedAtAction(nameof(GetLibroItem), new { id = item.Id }, item);
}

// PUT: api/Task/5
[HttpPut("{id}")]
public async Task<IActionResult> PutLibroItem(int id, LibroItem
item)
{
if (id != item.Id)
{
return BadRequest();
}
_context.Entry(item).State = EntityState.Modified;
await _context.SaveChangesAsync();
return NoContent();
}

// DELETE: api/Todo/5
[HttpDelete("{id}")]
public async Task<IActionResult> DeleteLibroItem(int id)
{
var libroItem = await
_context.libroItems.FindAsync(id);
if (libroItem == null)
{
return NotFound();
}

_context.libroItems.Remove(libroItem);
await _context.SaveChangesAsync();
return NoContent();
}



    }
}