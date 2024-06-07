using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace SampleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private static List<string> _items = new List<string> { "Item1", "Item2", "Item3" };

        // GET: api/sample
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return _items;
        }

        // GET: api/sample/1
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id < 0 || id >= _items.Count)
            {
                return NotFound();
            }

            return _items[id];
        }

        // POST: api/sample
        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            _items.Add(value);
            return CreatedAtAction(nameof(Get), new { id = _items.Count - 1 }, value);
        }

        // PUT: api/sample/1
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            if (id < 0 || id >= _items.Count)
            {
                return NotFound();
            }

            _items[id] = value;
            return NoContent();
        }

        // DELETE: api/sample/1
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= _items.Count)
            {
                return NotFound();
            }

            _items.RemoveAt(id);
            return NoContent();
        }
    }
}
