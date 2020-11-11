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
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamosController : ControllerBase
    {
        private Contexto contexto;

        public PrestamosController(Contexto contexto)
        {
            this.contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prestamos>>> GetList()
        {
            List<Prestamos> Lista;
            try
            {
                Lista = await contexto.Prestamos.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }


        private async Task<ActionResult<bool>> Insertar(Prestamos prestamo)
        {
            bool guardar = false;
            try
            {
                Personas persona = new Personas();
                persona = await contexto.Personas.FindAsync(prestamo.PersonaId);
                prestamo.Balance += prestamo.Monto;
                persona.Balance += prestamo.Balance;
                contexto.Personas.Update(persona);

                contexto.Prestamos.Add(prestamo);
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
                var prestamo = await contexto.Prestamos.FindAsync(id);

                if (prestamo != null)
                {
                    Personas persona = new Personas();
                    persona = await contexto.Personas.FindAsync(prestamo.PersonaId);
                    persona.Balance -= prestamo.Balance;
                    contexto.Personas.Update(persona);

                    contexto.Prestamos.Remove(prestamo);
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
        public async Task<ActionResult<Prestamos>> Buscar(int id)
        {
            Prestamos prestamo = new Prestamos();
            try
            {
                var encontrado = await contexto.Prestamos.FindAsync(id);

                if (encontrado == null)
                    return new Prestamos();
                else
                    prestamo = encontrado;
            }
            catch (Exception)
            {
                throw;
            }
            return prestamo;
        }

        private async Task<ActionResult<bool>> Modificar([FromBody] Prestamos prestamo)
        {
            bool modificar = false;
            try
            {
                Personas persona = new Personas();
                persona = await contexto.Personas.FindAsync(prestamo.PersonaId);
                prestamo.Balance += prestamo.Monto;
                persona.Balance += prestamo.Balance;
                contexto.Personas.Update(persona);

                contexto.Prestamos.Update(prestamo);
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
                existe = contexto.Prestamos.Any(a => a.PrestamoId == id);
            }
            catch (Exception)
            {
                throw;
            }
            return existe;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Guardar(Prestamos prestamo)
        {
            if (Existe(prestamo.PrestamoId))
                return await Modificar(prestamo);
            else
                return await Insertar(prestamo);
        }
    }
}
