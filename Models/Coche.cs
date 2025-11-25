namespace Models;

public class Coche : Vehiculo
{
    public string TipoCarroceria { get; set; }
    
    // **CAMBIO:** Ahora el Coche contiene un objeto Acabado
    public Acabado ConfigAcabado { get; set; } 

    // **CAMBIO:** El constructor ahora recibe un objeto Acabado
    public Coche(string marca, string modelo, int año, double precio, string tipoCarroceria, Acabado acabado, bool esImportado = false)
        : base(marca, modelo, año, precio, esImportado)
    {
        TipoCarroceria = tipoCarroceria;
        
        // Asignamos el objeto Acabado, que contiene el Motor y las Ruedas
        ConfigAcabado = acabado;
        
        // Opcional: Podrías ajustar el precio base según el acabado aquí
        this.Precio *= ConfigAcabado.MultiplicadorPrecio;
    }
    
    // Podemos crear propiedades de solo lectura (read-only) que acceden a los componentes
    public Motor.Motor Motor => ConfigAcabado.MotorAsociado;
    public Rueda Ruedas => ConfigAcabado.RuedaAsociada;
}