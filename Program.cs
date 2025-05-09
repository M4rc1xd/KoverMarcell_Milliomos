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
            string fajlnev = "kerdesek.txt";
            Beolvasas(fajlnev, kerdesek);
            for (int i = 0; i < kerdesek.Count; i++)
            {
                Console.WriteLine($"{kerdesek[i]}");
            }
        }

        static void Beolvasas(string fajlnev, List<Kerdes> kerdesek)
        {
            StreamReader sr = new(fajlnev);
            while(!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(';');
                kerdesek.Add(new Kerdes(int.Parse(sor[0]), sor[1], sor[2], sor[3], sor[4], sor[5], sor[6], sor[7]));
            }
        }
    }
}