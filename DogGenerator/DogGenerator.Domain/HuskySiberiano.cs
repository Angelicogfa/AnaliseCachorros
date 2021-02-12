using System;
using DogGenerator.Domain;

namespace DogGenerator.Domain
{
    public class HuskySiberiano : Dog
    {
        public HuskySiberiano(int age, double weight, double height, string color, string personality, string origin, int sex)
        : base(age, weight, height, color, personality, origin, sex, nameof(HuskySiberiano))
        {

        }
    }

    public class HuskySiberianoFactory : DogFactoryType<HuskySiberiano>
    {
        public double  FMinWeight{ get; private set; }
        public double FMaxWeight { get; private set; }
        public double FMinHeigth { get; private set; }
        public double FMaxHeigth { get; private set; }

        public HuskySiberianoFactory()
        {
            MinAge = 12;
            MaxAge = 15;
            MinWeight = 20;
            MaxWeight = 27;
            MinHeigth = 54;
            MaxHeigth = 60;

            FMinWeight = 16;
            FMaxWeight = 23;
            FMinHeigth = 50;
            FMaxHeigth = 56;

            Colors = new string[] { "Branco", "Preto", "Preto e canela", "Preto e branco", "Sable e branco", "Cinzento", "Gray & White", "Cinza - prata", "Vermelho e Branco" };
            Personality = new string[] { "Amigável", "Inteligente", "Extrovertido", "Alerta", "Gentil" };
        }

        public override HuskySiberiano Generate()
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

            return new HuskySiberiano(
                random.Next(0, MaxAge),
                random.NextDouble(minW, maxW),
                random.NextDouble(minH, maxH),
                Colors[random.Next(0, colors)],
                Personality[random.Next(0, personlity)],
                "Sibéria",
                sex);
        }
    }
}