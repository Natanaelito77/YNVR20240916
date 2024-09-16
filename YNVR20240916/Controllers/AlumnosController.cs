using Microsoft.AspNetCore.Mvc;
using YNVR20240916.Models;
using System.Collections.Generic;
using System.Linq;

namespace YNVR20240916.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlumnosController : ControllerBase
    {
        private static readonly List<Alumno> Alumnos = new List<Alumno>();
        private static int _nextId = 1;

        // GET: api/alumnos
        [HttpGet]
        public ActionResult<IEnumerable<Alumno>> Get()
        {
            return Ok(Alumnos);
        }

        // GET: api/alumnos/5
        [HttpGet("{id}")]
        public ActionResult<Alumno> Get(int id)
        {
            var alumno = Alumnos.FirstOrDefault(a => a.Id == id);
            if (alumno == null)
                return NotFound();

            return Ok(alumno);
        }

        // POST: api/alumnos
        [HttpPost]
        public ActionResult<Alumno> Post([FromBody] Alumno alumno)
        {
            if (alumno == null)
                return BadRequest();

            alumno.Id = _nextId++;
            Alumnos.Add(alumno);

            return CreatedAtAction(nameof(Get), new { id = alumno.Id }, alumno);
        }

        // PUT: api/alumnos/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Alumno alumno)
        {
            var existingAlumno = Alumnos.FirstOrDefault(a => a.Id == id);
            if (existingAlumno == null)
                return NotFound();

            existingAlumno.Nombre = alumno.Nombre;
            existingAlumno.Apellido = alumno.Apellido;

            return NoContent();
        }

        // DELETE: api/alumnos/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var alumno = Alumnos.FirstOrDefault(a => a.Id == id);
            if (alumno == null)
                return NotFound();

            Alumnos.Remove(alumno);

            return NoContent();
        }
    }
}







