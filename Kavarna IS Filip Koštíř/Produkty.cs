using System;

public class Produkty
{
    // bezparametrický konstruktor
    public Produkty() { }

    // veřejné vlastnosti vhodné pro XmlSerializer
    public string Nazev { get; set; }
    public float Cena { get; set; }
}
