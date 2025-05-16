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
        static void Main(string[] args)
        {
            fajlBeolvasasok();
            Jatek();
        }

        static void Jatek(){
            Bevezetes();
        }
        static void Bevezetes()
        {
            elsoSor();
            Console.WriteLine("Meg szeretnéd csinálni a tutorialt? (I/N)");
            bool validInput = false;
            string valasz = "";
            while(!validInput){
                valasz = Console.ReadLine().ToLower().Trim();
                if(valasz == "i"){
                    validInput = true;
                    tutorialKerdes();
                }
                else if(valasz == "n"){
                    validInput = true;
                }
                else{
                    Console.WriteLine("Kérlek válassz egy érvényes lehetőséget (I/N)");
                }
            }
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
            for (int i = 0; i < 10; i++)
            {
                elsoSor();
                Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine("Helyes válasz!");
                Console.ResetColor();
                System.Console.WriteLine("Most egy gyakorló sorkérdést fogsz kapni, amire válaszolnod kell. Addig nem mehetsz tovább, ameddig a helyes választ meg nem adod.");
                Console.ForegroundColor = ConsoleColor.Yellow;
                System.Console.WriteLine($"A tutoriál {10 - i} másodperc múlva kezdődik...");
                Thread.Sleep(1000);
            }
            tutorialSorkerdes();
                        
        }
        static void tutorialSorkerdes()
        {
            elsoSor();
            System.Console.WriteLine("A kérdésed és a hozzá tartozó válaszok:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Sorkerdes elsoSorkerdes = randomSorkerdes();
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
        static Sorkerdes randomSorkerdes(){
            int index = r.Next(0, sorkerdesek.Count);
            return sorkerdesek[index];
        }
        static void fajlBeolvasasok(){
            string fajlnev = "kerdesek.txt";
            KerdesBeolvasas(fajlnev, kerdesek);
            string fajlnev2 = "sorkerdesek.txt";
            SorkerdesBeolvasas(fajlnev2, sorkerdesek);
        }
        static void KerdesBeolvasas(string fajlnev, List<Kerdes> kerdesek)
        {
            StreamReader sr = new(fajlnev);
            while(!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(';');
                kerdesek.Add(new Kerdes(int.Parse(sor[0]), sor[1], sor[2], sor[3], sor[4], sor[5], sor[6], sor[7]));
            }
        }
        static void SorkerdesBeolvasas(string fajlnev, List<Sorkerdes> sorkerdesek)
        {
            StreamReader sr = new(fajlnev);
            while(!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(';');
                sorkerdesek.Add(new Sorkerdes(sor[0], sor[1], sor[2], sor[3], sor[4], sor[5], sor[6]));
            }
        }
        static void elsoSor(){
            Console.Clear();
            Console.ResetColor();
            Console.WriteLine("#################################");
            Console.WriteLine("#  EZ A LEGYEN ÖN IS MILLIOMOS! #");
            Console.WriteLine("#################################");
        }
    }
}