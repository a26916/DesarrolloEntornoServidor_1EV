using DTO;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace trabajo_1ev.Controllers;

[ApiController]
[Route("api/v1/motores")]
public class MotorController : ControllerBase
{
    // Inyección de Dependencia: El Controller depende del Servicio
    private readonly IMotorService _motorservice;

    public MotorController(IMotorService motorService)
    {
        _motorservice = motorService;
    }

    // --- 1. GET (Read - Lista) ---
    // GET /api/v1/motores
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<Models.Motor>>> GetMotores()
    {
        var motores = await _motorservice.GetAllAsync();
        return Ok(motores); // 200 OK
    }

    // --- 2. GET (Read - Detalle) ---
    // GET /api/v1/motores/{id}
    [HttpGet("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Models.Motor>> GetMotor(int id)
    {
        var motor = await _motorservice.GetByIdAsync(id);

        if (motor == null)
        {
            return NotFound(); // 404 Not Found
        }

        return Ok(motor); // 200 OK
    }

    // --- 3. POST (Create) ---
    // POST /api/v1/motores
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Models.Motor>> PostMotor([FromBody] MotorCreateDTO dto)
    {
        // El framework ASP.NET Core verifica las validaciones del DTO automáticamente.
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState); // 400 Bad Request si falla el DTO (ej: Potencia < 10)
        }

        var nuevoMotor = await _motorservice.CreateAsync(dto);

        // 201 Created: Devuelve el objeto creado y la URL de acceso al recurso
        return CreatedAtAction(nameof(GetMotor), new { id = nuevoMotor.IdMotor }, nuevoMotor);
    }

    // --- 4. PUT (Update - Completo) ---
    // PUT /api/v1/motores/{id}
    [HttpPut("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Models.Motor>> PutMotor(int id, [FromBody] MotorCreateDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var motorActualizado = await _motorservice.UpdateAsync(id, dto);

        if (motorActualizado == null)
        {
            return NotFound(); // 404 Not Found si el ID no existe
        }

        return Ok(motorActualizado); // 200 OK
    }

    // --- 5. DELETE ---
    // DELETE /api/v1/motores/{id}
    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteMotor(int id)
    {
        var result = await _motorservice.DeleteAsync(id);

        if (!result)
        {
            return NotFound(); // 404 Not Found si el ID no existe
        }

        return NoContent(); // 204 No Content (Eliminación exitosa sin cuerpo de respuesta)
    }
}