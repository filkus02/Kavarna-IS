using System;

public class Zamestnanec
{
    // bezparametrický konstruktor
    public Zamestnanec() { }

    // veřejné vlastnosti vhodné pro XmlSerializer
    public string Jmeno { get; set; }
    public string Pozice { get; set; }
    public string Uvazek { get; set; }
}
