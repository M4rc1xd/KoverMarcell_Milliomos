namespace Milliomos
{
    public class Kerdes
    {
        public int nehezseg;
        public string kerdes;
        public List<string> valaszok;
        public string helyesValasz;
        public string kategoria;
        public Kerdes(int nehezseg, string kerdes, string valasz1, string valasz2, string valasz3, string valasz4, string helyesValasz, string kategoria)
        {
            this.nehezseg = nehezseg;
            this.kerdes = kerdes;
            this.valaszok = new List<string> { valasz1, valasz2, valasz3, valasz4 };
            this.helyesValasz = helyesValasz;
            this.kategoria = kategoria;
        }
        public override string ToString()
        {
            return $"{kerdes}: A:{valaszok[0]} B:{valaszok[1]} C:{valaszok[2]} D:{valaszok[3]}";
        }
    }
}