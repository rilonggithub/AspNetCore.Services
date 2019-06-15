using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DataService.Controllers
{
    [Route("[controller]")]
    public class ValuesController : Controller
    {
        private static Random Rnd = new Random();
        private static readonly Dictionary<string, string> _values = new Dictionary<string, string>()
        {
            {  "a", " from Data Service Value " + Rnd.Next(10, 1000) },
            {  "b", " from Data Service Value " + Rnd.Next(10, 1000) },
            {  "c", " from Data Service Value " + Rnd.Next(10, 1000) },
            {  "d", " from Data Service Value " + Rnd.Next(10, 1000) },
            {  "e", " from Data Service Value " + Rnd.Next(10, 1000) },
            {  "f", " from Data Service Value " + Rnd.Next(10, 1000) },
            {  "g", " from Data Service Value " + Rnd.Next(10, 1000) },
        };

        [Authorize]
        [HttpGet("")]
        public IActionResult Get()
        {
            return Json(_values);
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            if (_values.TryGetValue(id, out string value))
            {
                return Json(value);
            }

            return NotFound();
        }
        
        [HttpPost("{id}")]
        public bool Post(string id, [FromBody]string value)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (_values.ContainsKey(id))
            {
                return false;
            }

            _values.Add(id, value);

            return true;
        }
        
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]string value)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (_values.ContainsKey(id))
            {
                _values[id] = value;
                return Ok();
            }
            
            return NotFound();
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            if (_values.ContainsKey(id))
            {
                _values.Remove(id);
                return Ok();
            }

            return NotFound();
        }
    }
}