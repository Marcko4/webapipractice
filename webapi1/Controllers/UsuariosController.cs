using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi1.Models;

namespace webapi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly Data.AppDbContext _context; //definir el contexto
        public UsuariosController(Data.AppDbContext context) //inyecion de dependecias 
        {
            _context = context; //asignar el contexto
        }

        [HttpGet("listar")] // api/usuarios/listar
        public async Task<ActionResult<IEnumerable<usuario>>> ListarUsuario() //metodo para listar usuarios
        {
            var usuarios = await _context.usuarios.ToListAsync(); //consultar la lista de usuarios en la base de datos
            return Ok(usuarios); // 200 //devuelve la lista de usuarios

        }
        [HttpPost("guardar")] //api/usuarios/guardar
        public async Task<ActionResult<usuario>> GuardarUsuario(usuario usuario)
        {
            usuario.fecha_creacion = DateTime.UtcNow;
            _context.usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created, usuario);
        }
        [HttpPut("editar/{id}")] //api/usuarios/editar
        public async Task<ActionResult> ActualizarUsuario (int id, usuario usuario)
        {
            var usuarioActualizado = await _context.usuarios.FindAsync(id);

            if (usuarioActualizado == null )
            {
                return NotFound();
            }

            usuarioActualizado.nombre = usuario.nombre;
            usuarioActualizado.apellido = usuario.apellido;
            usuarioActualizado.correo = usuario.correo;
            usuarioActualizado.username = usuario.username;

            await _context.SaveChangesAsync();
            return Ok(usuarioActualizado);
        }


    }

    }

