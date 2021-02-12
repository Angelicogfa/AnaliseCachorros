using System;
using DogGenerator.Domain;

namespace DogGenerator.Domain
{
    public class PastorAlemao : Dog
    {
        public PastorAlemao(int age, double weight, double height, string color, string personality, string origin, int sex)
        : base(age, weight, height, color, personality, origin, sex, nameof(PastorAlemao))
        {

        }
    }

    public class PastorAlemaoFactory : DogFactoryType<PastorAlemao>
    {
        public double  FMinWeight{ get; private set; }
        public double FMaxWeight { get; private set; }
        public double FMinHeigth { get; private set; }
        public double FMaxHeigth { get; private set; }

        public PastorAlemaoFactory()
        {
            MinAge = 9;
            MaxAge = 13;
            MinWeight = 30;
            MaxWeight = 40;
            MinHeigth = 60;
            MaxHeigth = 65;

            FMinWeight = 22;
            FMaxWeight = 32;
            FMinHeigth = 55;
            FMaxHeigth = 60;

            Colors = new string[] { "Preto", "Preto e canela", "Sable", "Cinzento", "Vermelho e preto", "Preto e prata" };
            Personality = new string[] { "Obediente", "Inteligente", "Curioso", "Alerta", "Leal", "Confiante", "Corajoso", "Vigilante" };
        }

        public override PastorAlemao Generate()
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

            return new PastorAlemao(
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