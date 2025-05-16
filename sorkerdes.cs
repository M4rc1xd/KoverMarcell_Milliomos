namespace Milliomos
{
    public class Sorkerdes
    {
        public string kerdes;
        public List<string> valaszok;
        public string helyesValasz;
        public string kategoria;
        public Sorkerdes(string kerdes, string valasz1, string valasz2, string valasz3, string valasz4, string helyesValasz, string kategoria)
        {
            this.kerdes = kerdes;
            this.valaszok = new List<string> { valasz1, valasz2, valasz3, valasz4 };
            this.helyesValasz = helyesValasz;
        }
        public override string ToString()
        {
            return $"{kerdes}: A:{valaszok[0]} B:{valaszok[1]} C:{valaszok[2]} D:{valaszok[3]}";
        }
    }
}