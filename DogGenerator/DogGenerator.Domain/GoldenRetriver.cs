using System;
using DogGenerator.Domain;

namespace DogGenerator.Domain
{
    public class GoldenRetriver : Dog
    {
        public GoldenRetriver(int age, double weight, double height, string color, string personality, string origin, int sex)
        : base(age, weight, height, color, personality, origin, sex, nameof(GoldenRetriver))
        {

        }
    }

    public class GoldenRetriverFactory : DogFactoryType<GoldenRetriver>
    {
        public double  FMinWeight{ get; private set; }
        public double FMaxWeight { get; private set; }
        public double FMinHeigth { get; private set; }
        public double FMaxHeigth { get; private set; }

        public GoldenRetriverFactory()
        {
            MinAge = 10;
            MaxAge = 12;
            MinWeight = 30;
            MaxWeight = 34;
            MinHeigth = 56;
            MaxHeigth = 61;

            FMinWeight = 25;
            FMaxWeight = 32;
            FMinHeigth = 51;
            FMaxHeigth = 56;

            Colors = new string[] { "Dourado Claro", "Dourado Escuro", "Creme", "Dourado" };
            Personality = new string[] { "Amigável", "Inteligente", "Confiável", "Afável", "Fiel", "Confiante" };
        }

        public override GoldenRetriver Generate()
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

            return new GoldenRetriver(
                random.Next(0, MaxAge),
                random.NextDouble(minW, maxW),
                random.NextDouble(minH, maxH),
                Colors[random.Next(0, colors)],
                Personality[random.Next(0, personlity)],
                "Reino Unido, Escócia, Inglaterra",
                sex);
        }
    }
}