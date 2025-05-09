namespace Milliomos
{
    public class Kerdes
    {
        public int nehezseg;
        public string kerdes;
        public string valasz1;
        public string valasz2;
        public string valasz3;
        public string valasz4;
        public string helyesValasz;
        public string kategoria;
        public Kerdes(int nehezseg, string kerdes, string valasz1, string valasz2, string valasz3, string valasz4, string helyesValasz, string kategoria)
        {
            this.nehezseg = nehezseg;
            this.kerdes = kerdes;
            this.valasz1 = valasz1;
            this.valasz2 = valasz2;
            this.valasz3 = valasz3;
            this.valasz4 = valasz4;
            this.helyesValasz = helyesValasz;
            this.kategoria = kategoria;
        }
        public override string ToString()
        {
            return $"{kerdes}: A:{valasz1} B:{valasz2} C:{valasz3} D:{valasz4}";
        }
    }
}