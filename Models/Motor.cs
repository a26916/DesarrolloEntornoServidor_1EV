using Models;

namespace Motor;
public class Motor
{
    public string Combustible { get; set; } = "";
    public double Cilindrada { get; set; }
    public int IdMotor { get; set; }
    public int PotenciaCV { get; set; }

    public Motor() { }

    public Motor(string combustible, double cilindrada, int potenciaCV, int idMotor = 0)
    {
        Combustible = combustible;
        Cilindrada = cilindrada;
        IdMotor = idMotor;
        PotenciaCV = potenciaCV;
    }
}