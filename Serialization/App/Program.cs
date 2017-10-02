using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using TypesLib;

namespace App
{
    class Program
    {
        public Address address;
        public Car car;
        public Truck truck;


        static void Main(string[] args)
        {
            Stream stream = Serialize();

            Console.WriteLine(new StreamReader(stream).ReadToEnd());
            Console.WriteLine(Object.ReferenceEquals(car._address, truck._address));

            stream.Position = 0;

            Deserialize(stream);

            Console.ReadLine();
        }

        private static Stream Serialize()
        {
            Address address = new Address() { POBox = "11", PostalCode = "22"};

            Car car = new Car { Type = "chev", Model = 2015, IsHatchBack = false, _Wheel = new Wheel() { Diameter = 40 } , Price = 2000, _address = address };
            Truck truck = new Truck { Type = "chev", Model = 2015, IsSemi = false, _Wheel = new Wheel() { Diameter = 80 } , _address = address };

            MemoryStream stream = new MemoryStream();

            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream,car);
            formatter.Serialize(stream,truck);

            stream.Position = 0;

            return stream;
        }

        private static void Deserialize(Stream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            Car car = (Car)formatter.Deserialize(stream);
            Truck truck = (Truck)formatter.Deserialize(stream);
        }
    }
}
