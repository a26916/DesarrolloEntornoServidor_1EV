using System.ComponentModel.DataAnnotations;

namespace DTO;

public class MotorCreateDTO
{
    // Validaciones de entrada
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Combustible { get; set; } = ""; // String

    [Required]
    [Range(0.5, 8.0, ErrorMessage = "La cilindrada debe estar entre 0.5 y 8.0.")]
    public double Cilindrada { get; set; } // double

    [Required]
    [Range(10, 1500, ErrorMessage = "La potencia debe ser superior a 10 CV.")]
    public int PotenciaCV { get; set; } // int
    
    // IdMotor NO se pide aquí, se genera en el servidor/base de datos.
}