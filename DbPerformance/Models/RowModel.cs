namespace DbPerformance.Models;

public class RowModel
{
    public string KodPocztowy { get; set; }

    public string Adres { get; set; }

    public string Miejscowosc { get; set; }

    public string Wojewodztwo { get; set; }

    public string Powiat { get; set; }

    public RowModel(string kodPocztowy, string adres, string miejscowosc, string wojewodztwo, string powiat)
    {
        KodPocztowy = kodPocztowy;
        Adres = adres;
        Miejscowosc = miejscowosc;
        Wojewodztwo = wojewodztwo;
        Powiat = powiat;
    }
}