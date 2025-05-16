namespace proba2
{
    internal class Program
    {
        public static List<Auto> autok = new List<Auto>();

        public static void Beolvasas()
        {
            string filenev = "autok.csv";

            string[] sorok = File.ReadAllLines(filenev);

            foreach (var sor in sorok.Skip(1))
            {
                var tagok = sor.Split(',');

                if (tagok.Length == 4)
                {
                    autok.Add(new Auto(
                        int.Parse(tagok[0]),
                        tagok[1],
                        int.Parse(tagok[2]),
                        int.Parse(tagok[3])
                    ));
                }
            }
        }




        static void Main(string[] args)
        {
            Beolvasas();
            foreach (var auto in autok)
            {
                Console.WriteLine($"{auto.Id} {auto.Évjárat} {auto.Ár} {auto.Márka}");


            }

            var evjaratAtlagAr = autok
                .Where(a => a.Évjárat == 2015)
                .GroupBy(a => a.Évjárat)
                .Select(g => new
                {
                    Évjárat = g.Key,
                    ÁtlagÁr = g.Average(a => a.Ár)
                })
                .OrderBy(g => g.Évjárat);


            Console.WriteLine("\nÁtlag ár évjáratonként:");
            foreach (var item in evjaratAtlagAr)
            {
                Console.WriteLine($"Évjárat: {item.Évjárat}, Átlag ár: {item.ÁtlagÁr:N0} Ft");
            }








            Auto legfiatalabb = autok.OrderBy(a => a.Évjárat).Last();
            Auto legidősebb = autok.OrderBy(a => a.Évjárat).First();
            Console.WriteLine($"Legidősebb:{legidősebb.Évjárat} {legidősebb.Márka}  ");
            Console.WriteLine($"Legfiatalabb:{legfiatalabb.Évjárat}");
            int km = 100;
            int üzár = 560;
            int fogy = 6;
            int kolt = költés(km, üzár, fogy);

            Console.WriteLine("A költség: " + kolt + " Ft");
        }



        public static int költés(int km, int üzár, int fogy)
        {
            double összliter = (double)(km * fogy) / 100;
            double költség = összliter * üzár;

            return (int)költség;

        }
    }

}
