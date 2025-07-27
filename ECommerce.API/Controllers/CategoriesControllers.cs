using MediatR;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Application.DTOs;
using ECommerce.Application.Features.Categories.Queries.GetCategoryList;
using ECommerce.Application.Features.Categories.Queries.GetCategoryById;
using ECommerce.Application.Features.Categories.Commands.CreateCategory;
using ECommerce.Application.Features.Categories.Commands.UpdateCategory;
using ECommerce.Application.Features.Categories.Commands.DeleteCategory;

namespace ECommerce.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/categories
    [HttpGet]
    public async Task<ActionResult<List<CategoryDto>>> GetAll()
    {
        var result = await _mediator.Send(new GetCategoryListQuery());
        return Ok(result);
    }

    // GET: api/categories/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDto>> GetById(Guid id)
    {
        var result = await _mediator.Send(new GetCategoryByIdQuery(id));
        return result is not null ? Ok(result) : NotFound();
    }

    // POST: api/categories
    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateCategoryDto dto)
    {
        var command = new CreateCategoryCommand(dto);
        var id = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, id);
    }

    // PUT: api/categories/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(Guid id, [FromBody] UpdateCategoryDto dto)
    {
        if (id != dto.Id)
            return BadRequest("ID mismatch");

        var success = await _mediator.Send(new UpdateCategoryCommand(dto));
        return success ? NoContent() : NotFound();
    }

    // DELETE: api/categories/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
        var success = await _mediator.Send(new DeleteCategoryCommand(id));
        return success ? NoContent() : BadRequest("Cannot delete category with existing products.");
    }
}
