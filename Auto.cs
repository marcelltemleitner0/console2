public class Auto
{
    public int Id { get; set; }
    public string Márka { get; set; }
    public int Évjárat { get; set; }
    public int Ár
    {
        get; set;
    }

    public Auto(int id, string márka, int évjárat, int ár)
    {
        Id = id;
        Márka = márka;
        Évjárat = évjárat;
        Ár = ár;
    }
}
