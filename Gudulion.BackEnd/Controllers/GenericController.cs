using Gudulion.BackEnd.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gudulion.BackEnd.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class GenericController<T> : ControllerBase where T : class, IEntityWithId
{
    private readonly DbContext _context;

    public GenericController(MainDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<T>>> GetAll([FromQuery] int pageSize, [FromQuery] int pageNumber)
    {
        return await _context.Set<T>().Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<T>> GetById(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);

        if (entity == null)
        {
            return NotFound();
        }

        return entity;
    }

    [HttpPost]
    public virtual async Task<ActionResult<T>> Create(T entity)
    {
        _context.Set<T>().Add(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<T>> Update(int id, T entity)
    {
        if (id != entity.Id)
        {
            return BadRequest();
        }

        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<T>> Delete(int id)
    {
        var entity = await _context.Set<T>().FindAsync(id);

        if (entity == null)
        {
            return NotFound();
        }

        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();

        return entity;
    }
}