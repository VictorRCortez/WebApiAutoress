using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using System.Runtime.CompilerServices;
using WebApiAutores.Entidades;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController: ControllerBase
    {
        public readonly ApplicationdbContext context;

        public AutoresController(ApplicationdbContext context)
        {
            this.context = context;   
        }

        //accion para responder
        [HttpGet]
        public async Task<ActionResult<List<Autor>>> Get()
        {


            //return new List<Autor>() {
            //    new Autor() { Id = 1, Nombre = "Mario" },
            //    new Autor() { Id = 2, Nombre = "Lesly"},
            //};

            return await context.Autores.ToListAsync();

        }

        [HttpPost]
        public async Task<ActionResult> Post(Autor autor)
        {
            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")] //api/autores/1
        public async Task<ActionResult> Put(Autor autor, int id)
        {
            if(autor.Id != id)
            {
                return BadRequest("El id del autor no coincide con el id de la URL");
            }

            var existe = await context.Autores.AnyAsync(x => x.Id == id);
            if (!existe)
            {
                return NotFound();
            }

            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Autores.AnyAsync(x => x.Id == id);   
            if(!existe) 
            {
                return NotFound();

            }
            context.Remove(new Autor { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
        
    }
}
