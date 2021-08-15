using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Reposiories;
using Microsoft.AspNetCore.Mvc;
using Octokit;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlipController : ControllerBase
    {
        private readonly IGithubRepository _repository;
        public BlipController(IGithubRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("avatar")]
        public IActionResult GetAvatar()
        {
            try
            {
                // return Ok(new { Avatar = await _repository.GetPicture() });
                return Redirect("https://avatars.githubusercontent.com/u/4369522?v=4");
            }
            catch (Exception err)
            {
                Console.Out.WriteLine(err);
                return BadRequest();
            }
        }

        [HttpGet("repo/{pos}")]
        public async Task<IActionResult> GetRepository(int pos)
        {
            try
            {
                return Ok(new { Title = await _repository.GetTitle(pos), Description = await _repository.GetDescription(pos) });
            }
            catch (Exception err)
            {
                Console.Out.WriteLine(err);
                return BadRequest();
            }
        }
    }
}