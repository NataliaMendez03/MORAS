using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema_de_Gestion_Moras.Models;
using Sistema_de_Gestion_Moras.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Sistema_de_Gestion_Moras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }


        // GET: api/<PostController>
        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetAllPost()
        {
            return Ok(await _postService.GetAll());
        }

        // GET api/<PostController>/5
        [HttpGet("{idPost}")]
        public async Task<ActionResult<Post>> GetPost(int idPost)
        {
            var Post = await _postService.GetPost(idPost);
            if (Post == null)
            {
                return BadRequest("Post not found :(");
            }
            return Ok(Post);
        }

        // POST: api/Post
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(string namePost)
        {
            var PostToPut = await _postService.CreatePost(namePost);

            if (PostToPut != null)
            {
                return Ok(PostToPut);
            }
            else
            {
                return BadRequest("Error when inserting into the database :(");
            }


        }

        // PUT: api/Post/5
        [HttpPut("Update/{idPost}")]
        public async Task<ActionResult<Post>> PutPost(int idPost, string namePost)
        {
            var PostToPut = await _postService.UpdatePost(idPost, namePost);

            if (PostToPut != null)
            {
                return Ok(PostToPut);
            }
            else
            {
                return BadRequest("Error updating the database :(");
            }

        }

        // Delete: api/Post/5
        [HttpDelete("Delete/{idPost}")]
        public async Task<ActionResult<Post>> DeletePost(int idPost)
        {

            var PostToDelete = await _postService.DeletePost(idPost);

            if (PostToDelete != null)
            {
                return Ok(PostToDelete);
            }
            else
            {
                return BadRequest("Error updating the database :(");
            }
        }
    }

}