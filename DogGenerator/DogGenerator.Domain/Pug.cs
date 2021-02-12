using System;
using DogGenerator.Domain;

namespace DogGenerator.Domain
{
    public class Pug : Dog
    {
        public Pug(int age, double weight, double height, string color, string personality, string origin, int sex)
        : base(age, weight, height, color, personality, origin, sex, nameof(Pug))
        {

        }
    }

    public class PugFactory : DogFactoryType<Pug>
    {
        public double  FMinWeight{ get; private set; }
        public double FMaxWeight { get; private set; }
        public double FMinHeigth { get; private set; }
        public double FMaxHeigth { get; private set; }

        public PugFactory()
        {
            MinAge = 12;
            MaxAge = 15;
            MinWeight = 6;
            MaxWeight = 8;
            MinHeigth = 30;
            MaxHeigth = 36;

            FMinWeight = 6;
            FMaxWeight = 8;
            FMinHeigth = 25;
            FMaxHeigth = 30;

            Colors = new string[] { "Preto", "Fulvo", "Abricot", "Fulvo prateado" };
            Personality = new string[] { "Arteiro", "Dócil", "Astuto", "Teimoso", "Encantador", "Afetuoso", "Sociável", "Brincalhão", "Amoroso", "Tranquilo", "Atento", "Calmo" };
        }

        public override Pug Generate()
        {
            var random = new System.Random();
            int colors = Colors.Length;
            int personlity = Personality.Length;

            int sex = random.Next(0, 2);

            double minH, maxH, minW, maxW = 0;

            if (sex == 0)
            {
                minH = FMinHeigth;
                maxH = FMaxHeigth;
                minW = FMinWeight;
                maxW = FMaxWeight;
            } 
            else 
            {
                minH = MinHeigth;
                maxH = MaxHeigth;
                minW = MinWeight;
                maxW = MaxWeight;
            }

            return new Pug(
                random.Next(0, MaxAge),
                random.NextDouble(minW, maxW),
                random.NextDouble(minH, maxH),
                Colors[random.Next(0, colors)],
                Personality[random.Next(0, personlity)],
                "República Popular da China",
                sex);
        }
    }
}