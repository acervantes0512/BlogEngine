using Application.DTOs;
using Application.Implementations;
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
    public class PostController : CrudController<Post>
    {
        private readonly IPostService _postService;

        public PostController(IGenericService<Post> genericService, IPostService postService) : base(genericService)
        {
            this._postService = postService;
        }

        [HttpPost]
        public async Task<ActionResult> Crear([FromBody] PostDto requestPost)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _postService.addPost(requestPost);

            return Ok();
        }
    }
}
