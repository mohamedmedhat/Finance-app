using api.Interfaces;
using Microsoft.AspNetCore.Http;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        public CommentController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository; 
        }

        [HttpGet]
        public async  Task<IActionResult> Get() 
        {
            var comments = await _commentRepository.GetAllAsync();
            var commentDto = comments.Select(s => s.ToCommentDto());
            return Ok(commentDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comments = await _commentRepository.GetByIdAsync(id);
            if(comments == null)
            {
                return NotFound();
            }
            return Ok(comments.ToCommentDto());
        }
    }
}
