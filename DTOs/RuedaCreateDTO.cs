using System.ComponentModel.DataAnnotations;

namespace DTO;

public class RuedaCreateDTO
{
    [Required(ErrorMessage = "El diámetro es obligatorio.")]
    [Range(10, 30, ErrorMessage = "El diámetro debe estar entre 10 y 30 pulgadas.")]
    public int DiametroPulgadas { get; set; }

    [Required]
    [Range(100, 400, ErrorMessage = "El ancho debe estar entre 100 y 400 mm.")]
    public int AnchoMM { get; set; }

    [Required]
    [Range(20, 50, ErrorMessage = "La presión recomendada debe ser realista.")]
    public decimal PresionRecomendadaPSI { get; set; }

    [Required]
    public string Fabricante { get; set; } = "";

    public bool EsParaInvierno { get; set; }
}