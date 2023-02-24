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

        [HttpGet]
        [Route("GetByUserId")]
        public async Task<ActionResult<IEnumerable<Post>>> GetByUserId(int id)
        {
            IEnumerable<Post> rta = await _postService.getPostsByUserId(id);

            if (rta == null)
            {
                return NotFound();
            }

            return rta.ToList();
        }

        [HttpGet]
        [Route("GetPostsEditedByUserId")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostsEditedByUserId(int id)
        {
            IEnumerable<Post> rta = await _postService.getPostsEditedByUserId(id);

            if (rta == null)
            {
                return NotFound();
            }

            return rta.ToList();
        }

        [HttpGet]
        [Route("GetPostsByStatus")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPostsByStatus(int id)
        {
            IEnumerable<Post> rta = await _postService.GetPostsByStatus(id);

            if (rta == null)
            {
                return NotFound();
            }

            return rta.ToList();
        }

    }
}
