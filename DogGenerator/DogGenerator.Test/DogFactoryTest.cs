using DogGenerator.Domain;
using System.IO;
using System.Linq;
using Xunit;

namespace DogGenerator.Test
{
    public class DogFactoryTest
    {
        [Fact]
        public void GerarExemplo()
        {
            IDogFactory factory = new DogFactory();
            Dog dog = factory.Generate<Beagle>();
            Assert.Equal(nameof(Beagle), dog.Breed);
        }

        [Fact]
        public void GerarExemplos()
        {
            IDogFactory factory = new DogFactory();
            Dog dog = factory.GenerateRandom(1).ToList()[0];
            Assert.NotNull(dog);
        }

        [Fact]
        public void GerarVariosExemplos()
        {
            IDogFactory factory = new DogFactory();
            var samples = factory.GenerateRandom(1000);
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(samples);
            Assert.NotEmpty(json);

            File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "cachorros.json"), json);
        }
    }
}
