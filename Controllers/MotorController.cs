using Microsoft.AspNetCore.Mvc;
using Services;
using Models;
using DTO;

namespace trabajo_1ev.Controllers
{
    [ApiController]
    [Route("api/v1/motores")]
    public class MotorController : ControllerBase
    {
        private readonly IMotorService _motorService;

        public MotorController(IMotorService motorService)
        {
            _motorService = motorService;
        }

        // --- 1. GET (Read - Lista) ---
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Motor>>> GetMotores()
        {
            var motores = await _motorService.GetAllAsync();
            return Ok(motores);
        }

        // --- 2. GET (Read - Detalle) ---
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Motor>> GetMotor(int id)
        {
            var motor = await _motorService.GetByIdAsync(id);


            if (motor == null)
            {
                return NotFound($"No se encontró el motor con id {id}");
            }

            return Ok(motor);
        }

        // --- 3. POST (Create) ---
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Motor>> CreateMotor([FromBody] MotorCreateDTO motorDto)
        {
            if (motorDto == null)
            {
                return BadRequest("El cuerpo de la solicitud no puede estar vacío");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nuevoMotor = await _motorService.CreateAsync(motorDto);

            // Retorna un 201 Created y la url para consultar el nuevo objeto
            return CreatedAtAction(nameof(GetMotor), new { id = nuevoMotor.IdMotor }, nuevoMotor);
        }

        // --- 4. PUT (Update) ---
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Motor>> UpdateMotor(int id, [FromBody] MotorCreateDTO motorDto)
        {
            if (motorDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var motorActualizado = await _motorService.UpdateAsync(id, motorDto);

            if (motorActualizado == null)
            {
                return NotFound($"No se puede actualizar. El motor con id {id} no existe.");
            }

            return Ok(motorActualizado);
        }

        // --- 5. DELETE (Delete) ---
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteMotor(int id)
        {
            var borrado = await _motorService.DeleteAsync(id);

            if (!borrado)
            {
                return NotFound($"No se encontró el motor con id {id} para borrar.");
            }

            return NoContent(); // 204 Sin contenido (éxito al borrar)
        }
    }
}