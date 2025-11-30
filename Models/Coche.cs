using Models;

namespace Models;

public class Coche : Vehiculo
{
    public string TipoCarroceria { get; set; }
    public Acabado ConfigAcabado { get; set; }

    public Coche(string marca, string modelo, int año, double precio, string tipoCarroceria, Acabado acabado, bool esImportado = false)
        : base(marca, modelo, año, precio, esImportado)
    {
        TipoCarroceria = tipoCarroceria;
        ConfigAcabado = acabado;
        this.Precio *= ConfigAcabado.MultiplicadorPrecio;
    }

    public Motor Motor => ConfigAcabado.MotorAsociado;
    public Rueda Ruedas => ConfigAcabado.RuedaAsociada;
}
