using FireForgetEntityFramework.Entities;
using FireForgetEntityFramework.Helpers;
using FireForgetEntityFramework.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FireForgetEntityFramework.Controllers;

[ApiController]
[Route("todo")]
public class TodoController : ControllerBase
{
    private readonly TodoContext _context;
    private readonly FireForget _fireForget;

    public TodoController(TodoContext context, FireForget fireForget)
    {
        _context = context;
        _fireForget = fireForget;
    }

    [HttpPost]
    public async Task<ActionResult<Todo>> Create(Todo request)
    {
        // insert new Todo
        var todo = new Todo
        {
            Description = request.Description
        };
        
        await _context.AddAsync(todo);
        await _context.SaveChangesAsync();
        
        // insert TodoHistory in background
        _fireForget.Execute<TodoContext>(async ctx =>
        {
            var history = new TodoHistory
            {
                TodoId = todo.Id,
                Date = DateTime.Now,
                Remarks = "Todo created"
            };

            await ctx.AddAsync(history);
            await ctx.SaveChangesAsync();
            
            // dispose the TodoContext
            await ctx.DisposeAsync();
        });
        
        return Ok(todo);
    }
}