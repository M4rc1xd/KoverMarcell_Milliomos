using System;
using System.Collections.Generic;
using System.IO;

namespace Milliomos
{
    internal class Program
    {
        static Random r = new Random();
        static List<Kerdes> kerdesek = new List<Kerdes>();
        static List<Sorkerdes> sorkerdesek = new List<Sorkerdes>();
        static List<int> nyeremenyek = new List<int> { 10000, 20000, 50000, 100000, 250000, 500000, 750000, 1000000, 1500000, 2000000, 5000000, 10000000, 15000000, 25000000, 50000000 };
        static void Main(string[] args)
        {
            fajlBeolvasasok();
            bevezetes();
        }
        static void bevezetes()
        {
            elsoSor();
            Console.WriteLine("Meg szeretnéd csinálni a tutorialt? (I/N)");
            bool validInput = false;
            string valasz = "";
            while (!validInput)
            {
                valasz = Console.ReadLine().ToLower().Trim();
                if (valasz == "i")
                {
                    validInput = true;
                    tutorialKerdes();
                }
                else if (valasz == "n")
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Kérlek válassz egy érvényes lehetőséget (I/N)");
                }
            }
            jatekBevezetes();
        }
        static void jatekBevezetes()
        {
            elsoSor();
            System.Console.WriteLine("A játék egy sorkérdéssel indul, ha nem sikerül sajnos nem vehetsz részt a játékban");
            System.Console.WriteLine("A kérdésed és a hozzá tartozó válaszok:");
            Sorkerdes kerdes = randomSorkerdes();
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine(kerdes);
            Console.ResetColor();
            
            string valasz = "";
            while (true)
            {
                Console.Write("Válaszod: ");
                valasz = Console.ReadLine().ToLower().Trim();

                if (valasz == "hint")
                {
                    Console.WriteLine(kerdes.helyesValasz);
                }
                else if (valasz == kerdes.helyesValasz.ToLower())
                {
                    break;
                }
                else
                {
                    break;
                }
            }

            if (valasz == kerdes.helyesValasz.ToLower())
            {
                for (int i = 0; i < 5; i++)
                {
                    elsoSor();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Helyes válasz!");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"A játék {5 - i} másodperc múlva kezdődik");
                    Thread.Sleep(1000);
                }
                jatek();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Helytelen válasz! A játék véget ért.");
                Console.ResetColor();
            }

        }
        static void jatek()
        {
            int kerdesSzam = 1;
            elsoSor();
            System.Console.WriteLine($"Elérkeztünk a(z) {kerdesSzam}. kérdéshez. A tét: {nyeremenyek[kerdesSzam - 1].ToString("N0")} Ft");
            Kerdes elsoKerdes = randomKerdes(kerdesSzam);
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine(elsoKerdes);
            Console.ResetColor();
            System.Console.Write("Válaszod: ");

        }
        static int kerdesMukodes(Kerdes kerdes, int kerdesSzam)
        {

            kerdesSzam++;
            return kerdesSzam;
        }
        static void tutorialKerdes()
        {
            elsoSor();
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("Tutorial elindítva");
            Console.ResetColor();
            for (int i = 0; i < 10; i++)
            {
                elsoSor();
                System.Console.WriteLine("A játék egyszerű: 2 fajta kérdés van: sima kérdés és sorkérdés");
                System.Console.WriteLine("A sima kérdésnél 4 válasz közül kell választani, a sorkérdésnél pedig 4 válasz közül kell kiválasztani a helyes sorrendet");
                System.Console.WriteLine("Most egy gyakorló kérdést fogsz kapni, amire válaszolnod kell. Addig nem mehetsz tovább, ameddig a helyes választ meg nem adod.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine($"A tutoriál {10 - i} másodperc múlva kezdődik...");
                Thread.Sleep(1000);
            }
            elsoSor();
            System.Console.WriteLine("A kérdésed és a hozzá tartozó válaszok:");
            Kerdes elsoKerdes = randomKerdes(15);
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine(elsoKerdes);
            Console.ResetColor();
            System.Console.WriteLine("Kérlek add meg a válaszod (A/B/C/D (a válaszod lehet kicsbetus vagy nagy is)):");
            string valasz = "";
            bool validInput = false;
            while (!validInput)
            {
                valasz = Console.ReadLine().ToLower().Trim();
                if (valasz == "a" || valasz == "b" || valasz == "c" || valasz == "d")
                {
                    if (valasz != elsoKerdes.helyesValasz.ToLower())
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine("Helytelen válasz! Kérlek adj meg egy másikat a tutoriál befejezése kedvéért.");
                        Console.ResetColor();
                    }
                    else
                    {
                        validInput = true;
                    }
                }
                else
                {
                    Console.WriteLine("Kérlek válassz egy érvényes lehetőséget (A/B/C/D)");
                }
            }
            for (int i = 0; i < 5; i++)
            {
                elsoSor();
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("Helyes válasz!");
                Console.ResetColor();
                System.Console.WriteLine("Most egy gyakorló sorkérdést fogsz kapni, amire válaszolnod kell. Addig nem mehetsz tovább, ameddig a helyes választ meg nem adod.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine($"A tutoriál {5 - i} másodperc múlva folytatódik");
                Thread.Sleep(1000);
            }
            tutorialSorkerdes();

        }
        static void tutorialSorkerdes()
        {
            elsoSor();
            System.Console.WriteLine("A kérdésed és a hozzá tartozó válaszok:");
            Sorkerdes elsoSorkerdes = randomSorkerdes();
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine(elsoSorkerdes);
            Console.ResetColor();
            System.Console.WriteLine("A válaszodat ilyen formában kell megadnod (kis/nagy betü nem számít): ABCD");
            string valasz = "";
            bool validInput = false;
            while (!validInput)
            {
                valasz = Console.ReadLine().ToLower().Trim();
                if (valasz == "hint")
                {
                    System.Console.WriteLine(elsoSorkerdes.helyesValasz);
                }
                if (valasz.Length == 4 && valasz.Distinct().Count() == 4 && valasz.All(c => "abcd".Contains(c)))
                {
                    if (valasz != elsoSorkerdes.helyesValasz.ToLower())
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Console.WriteLine($"Helytelen válasz! Kérlek adj meg egy másikat a tutoriál befejezése kedvéért");
                        Console.ResetColor();
                    }

                    else
                    {
                        validInput = true;
                    }
                }
                else
                {
                    Console.WriteLine("Kérlek válassz egy érvényes lehetőséget ");
                }
            }
            for (int i = 0; i < 5; i++)
            {
                elsoSor();
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("Helyes válasz!");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine($"A tutoriál {5 - i} másodperc múlva folytatódik");
                Thread.Sleep(1000);
            }
            tutorialInformacio();
        }
        static void tutorialInformacio()
        {
            elsoSor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("A játék menete:");
            Console.ResetColor();
            System.Console.WriteLine("A játék során 15 mindig nehezedõ kérdésekre kell válaszolnod, mindig növekvõ Pénz nyereményekért.");
            System.Console.WriteLine("A nyeremények a következõk:");
            for (int i = 0; i < nyeremenyek.Count / 5; i++)
            {
                Console.Write($"{i * 5 + 1}. kérdés: {nyeremenyek[i * 5].ToString("N0")} Ft".PadRight(30));
                Console.Write($"{i * 5 + 2}. kérdés: {nyeremenyek[i * 5 + 1].ToString("N0")} Ft".PadRight(30));
                Console.Write($"{i * 5 + 3}. kérdés: {nyeremenyek[i * 5 + 2].ToString("N0")} Ft".PadRight(30));
                Console.Write($"{i * 5 + 4}. kérdés: {nyeremenyek[i * 5 + 3].ToString("N0")} Ft".PadRight(30));
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{i * 5 + 5}. kérdés: {nyeremenyek[i * 5 + 4].ToString("N0")} Ft".PadRight(30));
                Console.ResetColor();
            }
            System.Console.WriteLine("A sárgával jelölt kérdések garantált nyereményhatárokat jeleznek amiket már nem lehet elveszíteni.");
            System.Console.WriteLine("Tehát a ha a játékos túlmegy az 5. kérdésen, már nem távozhat üres kézzel.");
            System.Console.WriteLine("A játék során megállásra is lesz lehetõség, ez biztosítja az eddig megszerzett pénzt, de a játék számodra véget fog térni");
            Thread.Sleep(10000);
            elsoSor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("A játék során 4 segédeszköz áll rendelkezésedre, de ebbõl csak hármat használhatsz:");
            Console.ResetColor();
            System.Console.WriteLine("1. 50:50 - Két válasz lehetõséget eltüntet a helyes válaszon kívül");
            System.Console.WriteLine("2. Közönség segítsége - A közönség 4 válaszlehetõségbõl választ, hogy szerintük melyik a helyes válasz. Ezzel a válaszok százalékait fogod látni");
            System.Console.WriteLine("3. Telefonos segítség - Két válasz lehetõséget eltüntet a helyes válaszon kívül");
            System.Console.WriteLine("4. müsorvezetõ - Két válasz lehetõséget eltüntet a helyes válaszon kívül");
            Thread.Sleep(10000);
            for (int i = 0; i < 5; i++)
            {
                elsoSor();
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine($"A tutoriál {5 - i} másodperc múlva befejezõdik");
                Thread.Sleep(1000);
            }
        }
        static Kerdes randomKerdes(int nehezseg)
        {
            if (nehezseg < 1 || nehezseg > 15)
            {
                throw new ArgumentOutOfRangeException("A nehézségnek 1 és 15 között kell lennie.");
            }
            List<Kerdes> szurtKerdesek = kerdesek.FindAll(k => k.nehezseg == nehezseg);
            return szurtKerdesek[r.Next(0, szurtKerdesek.Count)];
        }
        static Sorkerdes randomSorkerdes()
        {
            int index = r.Next(0, sorkerdesek.Count);
            return sorkerdesek[index];
        }
        static void fajlBeolvasasok()
        {
            string fajlnev = "kerdesek.txt";
            KerdesBeolvasas(fajlnev, kerdesek);
            string fajlnev2 = "sorkerdesek.txt";
            SorkerdesBeolvasas(fajlnev2, sorkerdesek);
        }
        static void KerdesBeolvasas(string fajlnev, List<Kerdes> kerdesek)
        {
            StreamReader sr = new(fajlnev);
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(';');
                kerdesek.Add(new Kerdes(int.Parse(sor[0]), sor[1], sor[2], sor[3], sor[4], sor[5], sor[6], sor[7]));
            }
        }
        static void SorkerdesBeolvasas(string fajlnev, List<Sorkerdes> sorkerdesek)
        {
            StreamReader sr = new(fajlnev);
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(';');
                sorkerdesek.Add(new Sorkerdes(sor[0], sor[1], sor[2], sor[3], sor[4], sor[5], sor[6]));
            }
        }
        static void elsoSor()
        {
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine("#################################");
            Console.WriteLine("#  EZ A LEGYEN ÖN IS MILLIOMOS! #");
            Console.WriteLine("#################################");
        }
    }
}