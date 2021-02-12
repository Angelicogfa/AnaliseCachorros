using System;
using DogGenerator.Domain;

namespace DogGenerator.Domain
{
    public class Beagle : Dog
    {
        public Beagle(int age, double weight, double height, string color, string personality, string origin, int sex)
        : base(age, weight, height, color, personality, origin, sex, nameof(Beagle))
        {

        }
    }

    public class BeagleFactory : DogFactoryType<Beagle>
    {
        public double  FMinWeight{ get; private set; }
        public double FMaxWeight { get; private set; }
        public double FMinHeigth { get; private set; }
        public double FMaxHeigth { get; private set; }

        public BeagleFactory()
        {
            MinAge = 12;
            MaxAge = 15;
            MinWeight = 10;
            MaxWeight = 11;
            MinHeigth = 36;
            MaxHeigth = 41;

            FMinWeight = 9;
            FMaxWeight = 10;
            FMinHeigth = 33;
            FMaxHeigth = 38;

            Colors = new string[] { "Limão e branco", "Tricolor", "Bronzeado e branco", "Chocolate Tri", "Laranja e branco", "Vermelho e Branco", "Castanho e Branco" };
            Personality = new string[] { "Temperamento balanceado", "Amável", "Determinado", "Inteligente", "Excitado", "Gentil" };
        }

        public override Beagle Generate()
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

            return new Beagle(
                random.Next(0, MaxAge),
                random.NextDouble(minW, maxW),
                random.NextDouble(minH, maxH),
                Colors[random.Next(0, colors)],
                Personality[random.Next(0, personlity)],
                "Reino Unido, Inglaterra, Grã-Betanha",
                sex);
        }
    }
}