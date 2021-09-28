using System.Collections.Generic;
using System.Linq;
using ITOSOFTWARE.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITOSOFTWARE.Controllers
{
 
    [Route("api/v1/[controller]")]
    public class EmpleadoController : Controller
    {
        private readonly LibraryDbContext _context;

        public EmpleadoController(LibraryDbContext context)
        {
            _context = context; 
        }
    
        [HttpGet]
        public List<Empleado> Obtener(){
            return _context.Empleado.ToList();

        }

        //Buscar por ID
        [HttpGet("{id:int}")]
        public IActionResult ObtenerEmpleadoPorId(int id){
        
        var Empleado= this._context.Empleado.SingleOrDefault(ct=> ct.Id ==id);
            if(Empleado != null){
                return Ok(Empleado);
            }else{
                return NotFound();
            }

        }
        
        //Buscar por nombre 

        [HttpGet("{Nombre}")]
        public IActionResult ObtenerEmpleadoNombre(string Nombre){
        var Empleado = this._context.Empleado.SingleOrDefault(ct => ct.Nombre.Contains(Nombre));

            if(Empleado == null){
                return new NoContentResult();
            }else {
                return Ok(Empleado);
            }
        }

        //Agregar Empleado
        [HttpPost]
        public IActionResult AgregarEmpleado([FromBody] Empleado empleado){
        
        if(!this.ModelState.IsValid){
            return BadRequest();
        }
            this._context.Empleado.Add(empleado);
            this._context.SaveChanges();
            return Created($"Empleado/{empleado.Nombre}", empleado);
        }
        
        //Actualizar Empleado
        [HttpPut("{id}")]
        public IActionResult ActualizarEmpleado(int id, [FromBody] Empleado empleado){

        var target = _context.Empleado.FirstOrDefault(ct=> ct.Id == id);
            if(target == null)
            {
                return NotFound();
            }
            else
            {
                target.Nombre = empleado.Nombre;
                target.Dependencia = empleado.Dependencia;

                _context.Empleado.Update(target);
                _context.SaveChanges();
                 return Ok();
            }

        }

        //Eliminar Empleado
        [HttpDelete("{id}")]
        public IActionResult EliminarEmpleado(int id){
            var target = _context.Empleado.FirstOrDefault(ct=> ct.Id == id);
            if(!this.ModelState.IsValid){
                return BadRequest();
            }
            else{
                _context.Empleado.Remove(target);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}