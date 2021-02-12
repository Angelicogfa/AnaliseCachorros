using System;
using DogGenerator.Domain;

namespace DogGenerator.Domain
{
    public class Boxer : Dog
    {
        public Boxer(int age, double weight, double height, string color, string personality, string origin, int sex)
        : base(age, weight, height, color, personality, origin, sex, nameof(Boxer))
        {

        }
    }

    public class BoxerFactory : DogFactoryType<Boxer>
    {
        public double  FMinWeight{ get; private set; }
        public double FMaxWeight { get; private set; }
        public double FMinHeigth { get; private set; }
        public double FMaxHeigth { get; private set; }

        public BoxerFactory()
        {
            MinAge = 10;
            MaxAge = 12;
            MinWeight = 27;
            MaxWeight = 32;
            MinHeigth = 57;
            MaxHeigth = 63;

            FMinWeight = 25;
            FMaxWeight = 29;
            FMinHeigth = 53;
            FMaxHeigth = 60;

            Colors = new string[] { "Branco", "Tigrado", "Fulvo" };
            Personality = new string[] { "Dedicado", "Amigável", "Energético", "Alegre" };
        }

        public override Boxer Generate()
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

            return new Boxer(
                random.Next(0, MaxAge),
                random.NextDouble(minW, maxW),
                random.NextDouble(minH, maxH),
                Colors[random.Next(0, colors)],
                Personality[random.Next(0, personlity)],
                "Alemanha",
                sex);
        }
    }
}