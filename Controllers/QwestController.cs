using QwestAPI.Models;
using QwestAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace QwestAPI.Controllers
{
    [Route("api/user/{user_id}")]
    [ApiController]
    public class QwestController: ControllerBase
    {
        private readonly IQwestService _qwestService;

        public QwestController(IQwestService service)
        {
            _qwestService = service;
        }

        [HttpGet]
        public ActionResult<List<TodoItem>> Get(string user_id) =>
            _qwestService.Get(user_id);


        [HttpGet("{id}", Name = "GetItem")]
        public ActionResult<TodoItem> Get(string user_id, string id)
        {
            var item = _qwestService.Get(user_id, id);

            return item == null ? NotFound() : Ok(item);
        }

        [HttpPost]
        public ActionResult<TodoItem> Create(string user_id, TodoItem item)
        {
            if(item == null)
                return BadRequest();

            var createdItem = _qwestService.Create(user_id, item);
            return CreatedAtRoute(
                routeName: "GetItem", 
                routeValues: new { user_id = user_id, id = createdItem.Id.ToString() }, 
                value: createdItem);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string user_id, string id, TodoItem itemIn)
        {
            var item = _qwestService.Get(user_id, id);

            if (item == null)
                return NotFound();

            _qwestService.Update(user_id, itemIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string user_id, string id)
        {
            var item = _qwestService.Get(user_id, id);

            if (item == null)
                return NotFound();

            _qwestService.Remove(user_id, item.Id);

            return NoContent();
        }
    }
}