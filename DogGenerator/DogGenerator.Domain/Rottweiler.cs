using System;
using DogGenerator.Domain;

namespace DogGenerator.Domain
{
    public class Rottweiler : Dog
    {
        public Rottweiler(int age, double weight, double height, string color, string personality, string origin, int sex)
        : base(age, weight, height, color, personality, origin, sex, nameof(Rottweiler))
        {

        }
    }

    public class RottweilerFactory : DogFactoryType<Rottweiler>
    {
        public double  FMinWeight{ get; private set; }
        public double FMaxWeight { get; private set; }
        public double FMinHeigth { get; private set; }
        public double FMaxHeigth { get; private set; }

        public RottweilerFactory()
        {
            MinAge = 8;
            MaxAge = 10;
            MinWeight = 50;
            MaxWeight = 60;
            MinHeigth = 61;
            MaxHeigth = 69;

            FMinWeight = 35;
            FMaxWeight = 48;
            FMinHeigth = 56;
            FMaxHeigth = 63;

            Colors = new string[] { "Preto", "Bronzeado", "Mahogany" };
            Personality = new string[] { "Boa natureza", "Dedicado", "Obediente", "Destemido", "Firme", "Alerta", "Seguro de si mesmo", "Confiante", "Corajoso", "Calmo" };
        }

        public override Rottweiler Generate()
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

            return new Rottweiler(
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