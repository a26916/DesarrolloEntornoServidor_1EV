using Models;  

namespace Models;

public class Acabado
{
    public string Nombre { get; set; }
    
    // CORRECCIÓN: Referenciar directamente el tipo Motor (ya que ambas están en Models)
    public Motor MotorAsociado { get; set; } 
    public Rueda RuedaAsociada { get; set; }
    public double MultiplicadorPrecio { get; set; }

    // El constructor también usa el tipo directo
    public Acabado(string nombre, Motor motor, Rueda rueda, double multiplicadorPrecio)
    {
        Nombre = nombre;
        MotorAsociado = motor;
        RuedaAsociada = rueda;
        MultiplicadorPrecio = multiplicadorPrecio;
    }

    public override string ToString()
    {
        return $"Acabado: {Nombre} | Motor: {MotorAsociado.PotenciaCV} CV | Ruedas: {RuedaAsociada.ToString()}";
    }
}