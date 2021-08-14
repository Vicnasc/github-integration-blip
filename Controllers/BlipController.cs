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
        public async Task<IActionResult> GetAvatar()
        {
            try
            {
                return Ok(await _repository.GetPicture());
            }
            catch (Exception err)
            {
                Console.Out.WriteLine(err);
                return BadRequest();
            }
        }

        [HttpGet("repo/{pos}/title")]
        public async Task<IActionResult> GetRepositoryTitle(int pos)
        {
            try
            {
                return Ok(await _repository.GetTitle(pos));
            }
            catch (Exception err)
            {
                Console.Out.WriteLine(err);
                return BadRequest();
            }
        }

        [HttpGet("repo/{pos}/description")]
        public async Task<IActionResult> GetRepositoryDescription(int pos)
        {
            try
            {
                return Ok(await _repository.GetDescription(pos));
            }
            catch (Exception err)
            {
                Console.Out.WriteLine(err);
                return BadRequest();
            }
        }
    }
}