using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrudController<T> : ControllerBase where T : class
    {
        private readonly IGenericService<T> _genericService;

        public CrudController(IGenericService<T> genericService)
        {
            this._genericService = genericService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<T>>> Get()
        {
            return (await _genericService.GetAllAsync()).ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get(int id)
        {
            var entity = await _genericService.GetByIdAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _genericService.DeleteAsync(id);
            return NoContent();
        }
    }
}
