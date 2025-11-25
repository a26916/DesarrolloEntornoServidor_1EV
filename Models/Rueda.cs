namespace Models;

public class Rueda{
    public int DiametroPulgadas { get; set; }
    public int AnchoMm { get; set; }

    public Rueda(int diametroPulgadas, int anchoMm)
    {
        DiametroPulgadas = diametroPulgadas;
        AnchoMm = anchoMm;
    }

    public override string ToString()
    {
        return $"{AnchoMm} / R{DiametroPulgadas}";
    }
}