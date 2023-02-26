using Application.Interfaces;
using Domain.Entities;
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
    public class StatusController : CrudController<StatusPost>
    {
        private readonly IGenericService<StatusPost> _genericService;

        public StatusController(IGenericService<StatusPost> genericService) : base(genericService)
        {
            this._genericService = genericService;
        }

        /// <summary>
        /// Obtener todos los registros
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusPost>>> Get()
        {
            return (await _genericService.GetAllAsync()).ToList();
        }
    }
}
