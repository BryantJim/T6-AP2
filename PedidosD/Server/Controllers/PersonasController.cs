using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedidosD.Shared.Models;

namespace PedidosD.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonasController : ControllerBase
    {
        private Contexto contexto;

        public PersonasController(Contexto contexto)
        {
            this.contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Personas>>> GetList()
        {
            List<Personas> Lista;
            try
            {
                Lista = await contexto.Personas.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }


        private async Task<ActionResult<bool>> Insertar(Personas persona)
        {
            bool guardar = false;
            try
            {
                contexto.Personas.Add(persona);
                guardar = await contexto.SaveChangesAsync() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            return guardar;
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<bool>> Eliminar(int id)
        {
            bool eliminado = false;
            try
            {
                var persona = await contexto.Personas.FindAsync(id);

                if (persona != null)
                {
                    contexto.Personas.Remove(persona);
                    eliminado = (await contexto.SaveChangesAsync() > 0);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return eliminado;
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<Personas>> Buscar(int id)
        {
            Personas persona = new Personas();
            try
            {
                var encontrado = await contexto.Personas.FindAsync(id);

                if (encontrado == null)
                    return new Personas();
                else
                    persona = encontrado;
            }
            catch (Exception)
            {
                throw;
            }
            return persona;
        }

        private async Task<ActionResult<bool>> Modificar([FromBody] Personas persona)
        {
            bool modificar = false;
            try
            {
                contexto.Personas.Update(persona);
                modificar = await contexto.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return modificar;
        }

        private bool Existe(int id)
        {
            bool existe;
            try
            {
                existe = contexto.Personas.Any(a => a.PersonaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Guardar(Personas persona)
        {
            if (Existe(persona.PersonaId))
                return await Modificar(persona);
            else
                return await Insertar(persona);
        }
    }
}
