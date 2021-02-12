using System;

namespace DogGenerator.Domain
{
    public abstract class Dog
    {
        protected Dog(int age, double weight, double height, string color, string personality, string origin, int sex, string breed)
        {
            Age = age;
            Weight = weight;
            Height = height;
            Color = color;
            Personality = personality;
            Origin = origin;
            Sex = sex;
            Breed = breed;
        }

        public int Age { get; private set; }
        public double Weight { get; private set; }
        public double Height { get; set; }
        public string Color { get; private set; }
        public string Personality { get; private set; }
        public string Origin { get; private set; }
        public int Sex { get; private set; }
        public string Breed { get; private set; }
    }
}