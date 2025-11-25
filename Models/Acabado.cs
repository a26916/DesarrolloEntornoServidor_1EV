using Motor; // Asumiendo que el namespace del Motor está aquí

namespace Models;

public class Acabado
{
    public string Nombre { get; set; }
    public Motor.Motor MotorAsociado { get; set; }
    public Rueda RuedaAsociada { get; set; }
    public double MultiplicadorPrecio { get; set; }

    public Acabado(string nombre, Motor.Motor motor, Rueda rueda, double multiplicadorPrecio)
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