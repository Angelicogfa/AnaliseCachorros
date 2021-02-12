using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DogGenerator.Domain;

namespace DogGenerator.Domain
{
    public interface IDogFactory
    {
        Dog Generate<T>() where T : Dog;
        IEnumerable<Dog> GenerateRandom(int n);
    }

    public interface IDogFactoryType<T> where T : Dog
    {
        T Generate();
    }

    public abstract class DogFactoryType<T> : IDogFactoryType<T> where T : Dog
    {
        public int MinAge { get; protected set; }
        public int MaxAge { get; protected set; }
        public double MinWeight { get; protected set; }
        public double MaxWeight { get; protected set; }
        public double MinHeigth { get; protected set; }
        public double MaxHeigth { get; protected set; }
        public string[] Colors { get; protected set; }
        public string[] Personality { get; protected set; }
        public string Origin { get; protected set; }
        public abstract T Generate();
    }


    public class DogFactory : IDogFactory
    {
        private readonly System.Collections.Generic.Dictionary<string, object> dicts;

        public DogFactory()
        {
            dicts = new System.Collections.Generic.Dictionary<string, object>();
            dicts.Add(nameof(Beagle), new BeagleFactory());
            dicts.Add(nameof(Boxer), new BoxerFactory());
            dicts.Add(nameof(Dachshund), new DachshundFactory());
            dicts.Add(nameof(Dobermann), new DobermannFactory());
            dicts.Add(nameof(GoldenRetriver), new GoldenRetriverFactory());
            dicts.Add(nameof(HuskySiberiano), new HuskySiberianoFactory());
            dicts.Add(nameof(Labrador), new LabradorFactory());
            dicts.Add(nameof(PastorAlemao), new PastorAlemaoFactory());
            dicts.Add(nameof(Pug), new PugFactory());
            dicts.Add(nameof(Rottweiler), new RottweilerFactory());
        }


        public Dog Generate<A>() where A : Dog
        {
            var factory = dicts.Get<IDogFactoryType<A>>(typeof(A).Name);
            return factory.Generate();
        }

        public IEnumerable<Dog> GenerateRandom(int n)
        {
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                int position = random.Next(0, dicts.Count - 1);
                var (_, factory) = dicts.ElementAt(position);
                yield return (Dog) factory.GetType().GetMethod("Generate").Invoke(factory, null);
            }
        }
    }
}