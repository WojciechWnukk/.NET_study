using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lab8.Data;
using Lab8.Models;
using Microsoft.AspNetCore.Authorization;

namespace Lab8.Controllers
{
    [Route("api/fox")]
    [ApiController]
    public class FoxesController : ControllerBase
    {
        private IFoxesRepository _repo;

        public FoxesController(IFoxesRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new JsonResult(_repo.Get(id));
        }

        [HttpPut("love/{id}")]
        public IActionResult Love(int id)
        {
            var fox = _repo.Get(id);
            if (fox == null)
                return NotFound();
            fox.Loves++;
            _repo.Update(id, fox);
            return Ok(fox);
        }

        [HttpPut("hate/{id}")]
        public IActionResult Hate(int id)
        {
            var fox = _repo.Get(id);
            if (fox == null)
                return NotFound();
            fox.Hates++;
            _repo.Update(id, fox);
            return Ok(fox);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var sortedFoxes = _repo.GetAll()
             .OrderByDescending(fox => fox.Loves)
             .ThenBy(fox => fox.Hates)
             .ToList();

            return new JsonResult(sortedFoxes);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Fox fox)
        {
            _repo.Add(fox);
            return CreatedAtAction(nameof(Get), new { id = fox.Id },
            fox);
        }
    }
}