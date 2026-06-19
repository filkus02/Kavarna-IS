using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

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
//Za pomoci AI GitHub Copilotem: Teď chci spojit class Produkty a class Zaměstnanec aby se ukládali do tohoto xml souboru GPT-5 mini.