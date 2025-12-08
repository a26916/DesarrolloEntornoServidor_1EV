using DTO;
using Microsoft.AspNetCore.Mvc;
using Services;
using Models;

namespace Controllers;

[ApiController]
[Route("api/v1/acabados")]
public class AcabadoController : ControllerBase
{
    private readonly IAcabadoService _acabadoService;

    public AcabadoController(IAcabadoService acabadoService)
    {
        _acabadoService = acabadoService;
    }

    // GET /api/v1/acabados
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Acabado>>> GetAcabado()
    {
        return Ok(await _acabadoService.GetAllAsync());
    }

    // POST /api/v1/acabados
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Acabado>> PostAcabado([FromBody] AcabadoCreateDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try 
        {
            // El servicio debe asegurar que el Motor y la Rueda con esos IDs existan.
            var nuevoAcabado = await _acabadoService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetAcabado), new { id = nuevoAcabado.Id }, nuevoAcabado);
        }
        catch (Exception ex)
        {
             // Capturar errores del Service, ej: "MotorId no existe"
            return BadRequest(new { message = ex.Message }); 
        }
    }
    
    // ... (Faltarían los métodos GET por ID, PUT y DELETE)
}