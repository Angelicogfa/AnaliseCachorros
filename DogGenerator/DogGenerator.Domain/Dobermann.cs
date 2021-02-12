using System;
using DogGenerator.Domain;

namespace DogGenerator.Domain
{
    public class Dobermann : Dog
    {
        public Dobermann(int age, double weight, double height, string color, string personality, string origin, int sex)
        : base(age, weight, height, color, personality, origin, sex, nameof(Dobermann))
        {

        }
    }

    public class DobermannFactory : DogFactoryType<Dobermann>
    {
        public double  FMinWeight{ get; private set; }
        public double FMaxWeight { get; private set; }
        public double FMinHeigth { get; private set; }
        public double FMaxHeigth { get; private set; }

        public DobermannFactory()
        {
            MinAge = 10;
            MaxAge = 13;
            MinWeight = 40;
            MaxWeight = 45;
            MinHeigth = 66;
            MaxHeigth = 72;

            FMinWeight = 32;
            FMaxWeight = 35;
            FMinHeigth = 61;
            FMaxHeigth = 68;

            Colors = new string[] { "Branco", "Preto", "Fulvo", "Preto e Ferrugem", "Red & Rust", "Azul", "Fawn & Rust", "Blue & Rust", "Vermelho" };
            Personality = new string[] { "Energético", "Obediente", "Inteligente", "Destemido", "Alerta", "Leal", "Confiante" };
        }

        public override Dobermann Generate()
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

            return new Dobermann(
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