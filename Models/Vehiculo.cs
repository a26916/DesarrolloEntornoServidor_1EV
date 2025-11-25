namespace Models;

public abstract class Vehiculo
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public int Año { get; set; }
    public double Precio { get; set; }
    public bool EsImportado { get; set; } = false;

    public Vehiculo(string marca, string modelo, int año, double precio, bool esImportado = false)
    {
        Marca = marca;
        Modelo = modelo;
        Año = año;
        Precio = precio;
        EsImportado = esImportado;
    }

}