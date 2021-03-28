using QwestAPI.Models;
using QwestAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;


namespace QwestAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService service)
        {
            _userService = service;
        }

        [HttpGet]
        public ActionResult<List<User>> Get() =>
            _userService.Get();


        [HttpGet("{id}", Name = "GetUser")]
        public ActionResult<User> Get(string id)
        {
            var refUser = _userService.Get(id);
            return (refUser == null) ? NotFound() : Ok(refUser);
        }

        [HttpPost]
        public ActionResult<User> Create(User userIn)
        {
            if(userIn == null)
                return BadRequest();
            
            var createdItem = _userService.Create(userIn);
            return CreatedAtRoute("GetUser", new {id = userIn.Id.ToString()}, userIn);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, User userIn)
        {
            var refUser = _userService.Get(id);
            if(refUser == null)
                return NotFound();
            
            _userService.Update(id, userIn);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var refUser = _userService.Get(id);
            if(refUser == null)
                return NotFound();
            
            _userService.Remove(refUser.Id);
            return NoContent();
        } 
    }
}