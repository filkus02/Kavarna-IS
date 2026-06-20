using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

//Za pomoci AI GitHub Copilotem: Teď chci spojit class Produkty a class Zaměstnanec aby se ukládali do tohoto xml souboru  -GPT-5 mini.

// XmlSerializer převádí objekty do XML a zpět. Abychom mohli ukládat jak produkty, tak zaměstnance do jednoho XML souboru, můžeme vytvořit třídu KavarnaData, která bude obsahovat seznamy obou typů. Tato třída již byla vytvořena výše.
// XmlArray a XmlArrayItem atributy zajistí, že seznamy budou správně serializovány do XML. Metody Save a Load v třídě XmlStorage umožňují ukládat a načítat data z XML souboru. Tímto způsobem můžeme efektivně ukládat jak produkty, tak zaměstnance do jednoho XML souboru.
[XmlRoot("KavarnaData")]
public class KavarnaData
{
    public KavarnaData()
    {
        Produkty = new List<Produkty>();
        Zamestnanci = new List<Zamestnanec>();
    }

    [XmlArray("Produkty")]
    [XmlArrayItem("Produkt")]
    public List<Produkty> Produkty { get; set; }

    [XmlArray("Zamestnanci")]
    [XmlArrayItem("Zamestnanec")]
    public List<Zamestnanec> Zamestnanci { get; set; }
}

public static class XmlStorage
{
    public static void Save(string path, KavarnaData data)
    {
        var serializer = new XmlSerializer(typeof(KavarnaData));
        // atomické uložení: zapis do temp a přejmenuj
        var temp = path + ".tmp";
        using (var fs = File.Create(temp))
        {
            serializer.Serialize(fs, data);
        }
        File.Copy(temp, path, true);
        File.Delete(temp);
    }

    public static KavarnaData Load(string path)
    {
        if (!File.Exists(path)) return new KavarnaData();
        var serializer = new XmlSerializer(typeof(KavarnaData));
        using (var fs = File.OpenRead(path))
        {
            return (KavarnaData)serializer.Deserialize(fs);
        }
    }
}
