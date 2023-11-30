using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_ReflectionDay19
{
    public class Source
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class Destination
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }


    public class Program
    {
        static void MapProperties(Source source, Destination destination)
        {
            var sourceProperties = source.GetType().GetProperties();
            var destinationProperties = destination.GetType().GetProperties();
            foreach (var sourceprop in sourceProperties)
            {
                foreach (var destprop in destinationProperties)
                {
                    if (sourceprop.Name == destprop.Name && sourceprop.PropertyType == destprop.PropertyType) 
                    {
                        destprop.SetValue(destination, sourceprop.GetValue(source));
                        break;

                    }
                }

            }
        }
        static void Main(string[] args)
        {
            Source source = new Source()
            {
                Id = 101,
                Name = "John",
                Address = "ABC Main Street"
            };
            Destination destination = new Destination { Id = 0, Name = "Sam", City = "Sangli", Country = "India" };
        

            MapProperties(source, destination);

            Console.WriteLine("Mapped Properties in Destination");
            Console.WriteLine($"\nId: {destination.Id}");
            Console.WriteLine($"Name: {destination.Name}");
            Console.WriteLine($"City: {destination.City}");
            Console.WriteLine($"Country: {destination.Country}");
            Console.ReadKey();
        }
    }
}
