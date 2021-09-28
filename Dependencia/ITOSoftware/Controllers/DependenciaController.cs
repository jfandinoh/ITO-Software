using System.Collections.Generic;
using System.Linq;
using ITOSOFTWARE.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITOSOFTWARE.Controllers
{
 
    [Route("api/v1/[controller]")]
    public class DependenciaController : Controller
    {
        private readonly LibraryDbContext _context;

        public DependenciaController(LibraryDbContext context)
        {
            _context = context; 
        }
    
        [HttpGet]
        public List<Dependencia> Get(){
            return _context.Dependencia.ToList();

        }

        //Buscar por ID
        [HttpGet("{id:int}")]
        public IActionResult GetDependenciaPorId(int id){
        
        var dependencia= this._context.Dependencia.SingleOrDefault(ct=> ct.Id ==id);
            if(dependencia != null){
                return Ok(dependencia);
            }else{
                return NotFound();
            }

        }
        
        //Buscar por nombre 

        [HttpGet("{Nombre}")]
        public IActionResult ObtenerDependenciaNombre(string Nombre){
        var Dependencia = this._context.Dependencia.SingleOrDefault(ct => ct.Nombre.Contains(Nombre));

            if(Dependencia == null){
                return new NoContentResult();
            }else {
                return Ok(Dependencia);
            }
        }

        //Agregar Dependencia
        [HttpPost]
        public IActionResult AgregarDependencia([FromBody] Dependencia dependencia){
        
        if(!this.ModelState.IsValid){
            return BadRequest();
        }
            this._context.Dependencia.Add(dependencia);
            this._context.SaveChanges();
            return Created($"Dependencia/{dependencia.Nombre}", dependencia);
        }
        
        //Actualizar Dependencia
        [HttpPut("{id}")]
        public IActionResult ActualizarDependencia(int id, [FromBody] Dependencia dependencia){

        var target = _context.Dependencia.FirstOrDefault(ct=> ct.Id == id);
            if(target == null)
            {
                return NotFound();
            }
            else
            {
                target.Nombre = dependencia.Nombre;

                _context.Dependencia.Update(target);
                _context.SaveChanges();
                 return Ok();
            }

        }

        //Eliminar Dependencia
        [HttpDelete("{id}")]
        public IActionResult EliminarDependencia(int id){
            var target = _context.Dependencia.FirstOrDefault(ct=> ct.Id == id);
            if(!this.ModelState.IsValid){
                return BadRequest();
            }
            else{
                _context.Dependencia.Remove(target);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}