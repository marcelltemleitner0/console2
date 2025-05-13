namespace proba2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filenev = "C:\\Users\\heten\\Desktop\\proba2\\proba2\\autok.csv";
            var autok = new List<Auto>();
            string[] sorok = File.ReadAllLines(filenev);
            foreach (var sor in sorok.Skip(1))
            {
                var tagok = sor.Split(',');
                if (tagok.Length == 4 )
                {
                    autok.Add(new Auto(int.Parse(tagok[0]), tagok[1], int.Parse(tagok[2]), int.Parse(tagok[3]) ));
                }
            }
            foreach (var auto in autok)
            {
                Console.WriteLine($"{auto.Id} {auto.Évjárat} {auto.Ár} {auto.Márka}");
                
                
            }
            
            Auto legfiatalabb = autok.OrderBy(a => a.Évjárat).Last();
            Auto legidősebb = autok.OrderBy(a => a.Évjárat).First();
            Console.WriteLine($"Legidősebb:{legidősebb.Évjárat}");
            Console.WriteLine($"Legfiatalabb:{legfiatalabb.Évjárat}");
            int km = 100;
            int üzár = 560;
            int fogy = 6;
            költés(km,üzár, fogy);
        }



        public static void költés(int km, int üzár, int fogy)
        {
            int összliter = (km * fogy) / 100;
            int költség = összliter * üzár;

            Console.WriteLine($"Várható üzemanyag költség: {költség}");

        }
    }

}
