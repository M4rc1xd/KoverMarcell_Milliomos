using System;
using System.Collections.Generic;
using System.IO;

namespace Milliomos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Kerdes> kerdesek = new List<Kerdes>();
            List<Sorkerdes> sorkerdesek = new List<Sorkerdes>();
            string fajlnev = "kerdesek.txt";
            KerdesBeolvasas(fajlnev, kerdesek);
            string fajlnev2 = "sorkerdesek.txt";
            SorkerdesBeolvasas(fajlnev2, sorkerdesek);
            for (int i = 0; i < sorkerdesek.Count; i++)
            {
                Console.WriteLine($"{sorkerdesek[i]}");
            }
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
    }
}