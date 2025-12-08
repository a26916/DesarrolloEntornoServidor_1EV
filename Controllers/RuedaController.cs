using DTO;
using Microsoft.AspNetCore.Mvc;
using Services;
using Models;

namespace Controllers;

[ApiController]
[Route("api/v1/ruedas")]
public class RuedasController : ControllerBase
{
    private readonly IRuedaService _ruedaService;

    public RuedasController(IRuedaService ruedaService)
    {
        _ruedaService = ruedaService;
    }

    // GET /api/v1/ruedas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Rueda>>> GetRuedas()
    {
        return Ok(await _ruedaService.GetAllAsync()); // 200 OK
    }

    // POST /api/v1/ruedas
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Rueda>> PostRueda([FromBody] RuedaCreateDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var nuevaRueda = await _ruedaService.CreateAsync(dto);
        
        // Asumiendo que el ID de Rueda se llama 'Id' o 'IdRueda'
        return CreatedAtAction(nameof(GetRuedas), new { id = nuevaRueda.Id }, nuevaRueda);
    }
    
    // ... (Faltarían los métodos GET por ID, PUT y DELETE, que siguen la misma plantilla que el MotorController)
}