using System;
using System.IO;
using System.Xml;



public class Program
{

    // HLAVNÍ ROZCESTNÍK

    public static void Main(string[] args)
    {
        Zamestnanec[] poleZamestnancu = new Zamestnanec[100];
        int pocetZamestnancu = 0;

        Produkty[] poleProduktu = new Produkty[100];
        int pocetProduktu = 0;

        char odpovedHlavni = ' ';

        do
        {
            Console.Clear();
            Console.WriteLine("=======================================");
            Console.WriteLine("       HLAVNÍ ROZCESTNÍK KAVÁRNY");
            Console.WriteLine("=======================================");
            Console.WriteLine("Správa zaměstnanců    [1]");
            Console.WriteLine("Správa produktů       [2]");
            Console.WriteLine("Ukončit systém        [k]");
            Console.Write("Vyberte sekci: ");

            odpovedHlavni = Console.ReadKey().KeyChar;

            switch (odpovedHlavni)
            {
                case '1':
                    // Voláme pod-menu pro zaměstnance (předáváme pomocí ref)
                    MenuZamestnanci(poleZamestnancu, ref pocetZamestnancu);
                    break;
                case '2':
                    // Voláme pod-menu pro produkty
                    MenuProdukty(poleProduktu, ref pocetProduktu);
                    break;
            }

        } while (odpovedHlavni != 'k');
    }
   







    public static void MenuZamestnanci(Zamestnanec[] pole, ref int pocet)
    {
        char odpoved = ' ';
        do
        {
            Console.Clear();
            Console.WriteLine("SEKCE: ZAMĚSTNANCI");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Přidat zaměstnance    [p]");
            Console.WriteLine("Vypsat zaměstnance    [v]");
            Console.WriteLine("Uložit do XML         [u]");
            Console.WriteLine("Návrat do menu        [k]");
            Console.Write("Zadejte akci: ");

            odpoved = Console.ReadKey().KeyChar;

            switch (odpoved)
            {
                case 'p':
                    Console.Clear();
                    Console.WriteLine("--- Pridani zamestnance ---");
                    pole[pocet] = new Zamestnanec();

                    Console.Write("Zadejte Jmeno: ");
                    pole[pocet].Jmeno = Console.ReadLine();

                    Console.Write("Zadejte Pozici (napr. Barista): ");
                    pole[pocet].Pozice = Console.ReadLine();

                    NactiUvazek(out pole[pocet].Uvazek);

                    pocet = pocet + 1;
                    Console.WriteLine("Zamestnanec pridan. Stisknete klavesu...");
                    Console.ReadKey();
                    break;

                case 'v':
                    Console.Clear();
                    Console.WriteLine("--- Vypis zamestnancu ---");

                    int i = 0;
                    while (i < pocet)
                    {
                        Console.WriteLine(pole[i].Jmeno + " | " + pole[i].Pozice + " | " + pole[i].Uvazek);
                        i = i + 1;
                    }

                    Console.WriteLine("\nStisknete klavesu pro navrat...");
                    Console.ReadKey();
                    break;

                case 'u':
                    Console.Clear();
                    Console.WriteLine("--- Ukladani zamestnancu ---");
                    Console.ReadKey();
                    break;
            }

        } while (odpoved != 'k');
    }

    // Ošetření vstupů


    public static void NactiUvazek(out String vysledek)
    {
        vysledek = "";
        int platnyVstup = 0;
        String vstup = "";

        while (platnyVstup == 0)
        {
            Console.Write("Zadejte uvazek (pouze DPP, DPČ, fulltime): ");
            vstup = Console.ReadLine();

            if (vstup == "DPP") { platnyVstup = 1; }
            if (vstup == "DPČ") { platnyVstup = 1; }
            if (vstup == "fulltime") { platnyVstup = 1; }

            if (platnyVstup == 0)
            {
                Console.WriteLine("Chyba: Zadejte presne 'DPP', 'DPČ' nebo 'fulltime'!\n");
            }
        }
        vysledek = vstup;
    }

    // MENU PRODUKTY (ref)

    public static void MenuProdukty(Produkty[] pole, ref int pocet)
    {
        char odpoved = ' ';
        do
        {
            Console.Clear();
            Console.WriteLine("SEKCE: PRODUKTY");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Přidat produkt        [p]");
            Console.WriteLine("Vypsat produkty       [v]");
            Console.WriteLine("Uložit do XML         [u]");
            Console.WriteLine("Návrat do menu        [k]");
            Console.Write("Zadejte akci: ");

            odpoved = Console.ReadKey().KeyChar;

            switch (odpoved)
            {
                case 'p':
                    Console.Clear();
                    Console.WriteLine("--- Pridani produktu ---");
                    pole[pocet] = new Produkty();

                    Console.Write("Zadejte nazev produktu: ");
                    pole[pocet].Nazev = Console.ReadLine();

                    BezpecneNactiCenu(out pole[pocet].Cena);

                    pocet = pocet + 1;
                    Console.WriteLine("Produkt pridan. Stisknete klavesu...");
                    Console.ReadKey();
                    break;

                case 'v':
                    Console.Clear();
                    Console.WriteLine("--- Vypis produktu ---");

                    int i = 0;
                    while (i < pocet)
                    {
                        Console.WriteLine(pole[i].Nazev + " | " + pole[i].Cena + " CZK");
                        i = i + 1;
                    }

                    Console.WriteLine("\nStisknete klavesu pro navrat...");
                    Console.ReadKey();
                    break;

                case 'u':
                    Console.Clear();
                    Console.WriteLine("--- Ukladani produktu ---");
                    Console.ReadKey();
                    break;
            }

        } while (odpoved != 'k');
    }
    public static void BezpecneNactiCenu(out float vysledek)
    {
        vysledek = 0.0f;
        int spravne = 0;
        String vstup = "";

        while (spravne == 0)
        {
            Console.Write("Zadejte cenu produktu (v CZK): ");
            vstup = Console.ReadLine();

            if (float.TryParse(vstup, out vysledek) == true)
            {
                spravne = 1;
            }

            if (spravne == 0)
            {
                Console.WriteLine("Chyba: Zadejte platne cislo pro cenu!\n");
            }
        }
    }
}