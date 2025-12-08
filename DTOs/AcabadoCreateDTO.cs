using System.ComponentModel.DataAnnotations;

namespace DTO;

public class AcabadoCreateDTO
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string NombreAcabado { get; set; } = "";

    [Required]
    [Range(1.0, double.MaxValue, ErrorMessage = "El multiplicador debe ser positivo.")]
    public double MultiplicadorPrecio { get; set; }
    
    [Required]
    public int MotorIdAsociado { get; set; }

    [Required]
    public int RuedaIdAsociada { get; set; }
}