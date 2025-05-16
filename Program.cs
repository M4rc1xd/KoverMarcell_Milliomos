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
                    tutorial();
                }
                else if(valasz == "n"){
                    validInput = true;
                }
                else{
                    Console.WriteLine("Kérlek válassz egy érvényes lehetőséget (I/N)");
                }
            }
        }

        static void tutorial(){
            elsoSor();
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("Tutorial elindítva");
            Console.ResetColor();
            System.Console.WriteLine("A játék egyszerű: 2 fajta kérdés van: sima kérdés és sorkérdés");
            System.Console.WriteLine("A sima kérdésnél 4 válasz közül kell választani, a sorkérdésnél pedig 4 válasz közül kell kiválasztani a helyes sorrendet");
            System.Console.WriteLine("Most egy gyakorló kérdést fogsz kapni, amire válaszolnod kell. Addig nem mehetsz tovább, ameddig a helyes választ meg nem adod.");
            System.Console.WriteLine(randomKerdes(15));
        }
        static Kerdes randomKerdes(int nehezseg){
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
            Console.WriteLine("#################################");
            Console.WriteLine("#  EZ A LEGYEN ÖN IS MILLIOMOS! #");
            Console.WriteLine("#################################");
        }
    }
}