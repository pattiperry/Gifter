using System;
using Microsoft.AspNetCore.Mvc;
using Gifter.Repositories;
using Gifter.Models;

namespace Gifter.Controllers
{
    //this determines my route in my url-it uses the name of my controller
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public PostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_postRepository.GetAll());
        }

        [HttpGet("GetWithComments")]
        //in my url it looks like
        // /api/post/getwithcomments
        public IActionResult GetWithComments()
        {
            var posts = _postRepository.GetAllWithComments();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _postRepository.GetById(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpGet("GetPostByIdWithComments/{id}")]
        public IActionResult GetPostByIdWithComments(int id)
        {
            var post = _postRepository.GetPostByIdWithComments(id);
            if(post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }

        [HttpPost]
        public IActionResult Post(Post post)
        {
            _postRepository.Add(post);
            return CreatedAtAction("Get", new { id = post.Id }, post);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            _postRepository.Update(post);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _postRepository.Delete(id);
            return NoContent();
        }

        [HttpGet("search")]
        public IActionResult Search(string q, bool sortDesc)
        {
            return Ok(_postRepository.Search(q, sortDesc));
        }

        [HttpGet("hottest")]
        public IActionResult Hottest(DateTime since, bool sortDesc)
        {
            return Ok(_postRepository.Hottest(since, sortDesc));
        }
    }
}
