using System;
using DogGenerator.Domain;

namespace DogGenerator.Domain
{
    public class Dachshund : Dog
    {
        public Dachshund(int age, double weight, double height, string color, string personality, string origin, int sex) 
        : base(age, weight, height, color, personality, origin, sex, nameof(Dachshund))
        {

        }
    }

    public class DachshundFactory : DogFactoryType<Dachshund>
    {
        public DachshundFactory()
        {
            MinAge = 12;
            MaxAge = 16;
            MinWeight = 7.5;
            MaxWeight = 14;
            MinHeigth = 37;
            MaxHeigth = 47;

            Colors = new string[] { "Preto", "Preto e canela", "Chocolate e castanho", "Marrom e bege", "Creme", "Tan", "Azul e Bronze", "Vermelho" };
            Personality = new string [] { "Astuto", "Teimoso", "Dedicado", "Vivaz", "Brincalhão", "Corajoso"};
        }

        public override Dachshund Generate()
        {
            var random = new System.Random();
            int colors = Colors.Length;
            int personlity = Personality.Length;

            return new Dachshund(
                random.Next(0, MaxAge),
                random.NextDouble(MinWeight, MaxWeight),
                random.NextDouble(MinHeigth, MaxHeigth),
                Colors[random.Next(0, colors)],
                Personality[random.Next(0, personlity)],
                "Alemanha",
                random.Next(0, 2));
        }
    }
}