using System;
using DogGenerator.Domain;

namespace DogGenerator.Domain
{
    public class Labrador : Dog
    {
        public Labrador(int age, double weight, double height, string color, string personality, string origin, int sex)
        : base(age, weight, height, color, personality, origin, sex, nameof(Labrador))
        {

        }
    }

    public class LabradorFactory : DogFactoryType<Labrador>
    {
        public double  FMinWeight{ get; private set; }
        public double FMaxWeight { get; private set; }
        public double FMinHeigth { get; private set; }
        public double FMaxHeigth { get; private set; }

        public LabradorFactory()
        {
            MinAge = 10;
            MaxAge = 12;
            MinWeight = 29;
            MaxWeight = 36;
            MinHeigth = 57;
            MaxHeigth = 62;

            FMinWeight = 25;
            FMaxWeight = 32;
            FMinHeigth = 55;
            FMaxHeigth = 60;

            Colors = new string[] { "Preto", "Chocolate", "Amarelo" };
            Personality = new string[] { "Temperamento balanceado", "Inteligente", "Afável", "Ágil", "Extrovertido", "Confiante", "Gentil" };
        }

        public override Labrador Generate()
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

            return new Labrador(
                random.Next(0, MaxAge),
                random.NextDouble(minW, maxW),
                random.NextDouble(minH, maxH),
                Colors[random.Next(0, colors)],
                Personality[random.Next(0, personlity)],
                "Terra Nova",
                sex);
        }
    }
}