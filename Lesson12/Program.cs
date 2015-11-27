using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lesson12
{
    class Program
    {
        static void Main(string[] args)
        {
            Fridge Zanussi = new Fridge(false, FridgeModes.normal);

            string path = @"D:\!_C#\!_Projects\Lesson12\Lesson12\bin\Debug\fridges.dat";
            FileInfo fileInfo = new FileInfo(path);

            if (fileInfo.Exists)
            {
                // Создаем объект BinaryFormatter
                BinaryFormatter formatter = new BinaryFormatter();

                using (FileStream fs = new FileStream("fridges.dat", FileMode.Open))
                {
                    Fridge z = (Fridge)formatter.Deserialize(fs);
                    Console.WriteLine("Объект десериализован");     // не выведется - при запуске чистим консоль
                    Zanussi = z;
                    Console.WriteLine(Zanussi.Info());              // не выведется - при запуске чистим консоль
                }
            }

            while (true)
            {
                Console.Clear();
                Console.WriteLine(Zanussi.Info() + "\n");
                Console.WriteLine("Доступные действия: ");
                Console.WriteLine("1 - включить холодильник");
                Console.WriteLine("2 - выключить холодильник");
                Console.WriteLine("3 - нормальный режим");
                Console.WriteLine("4 - северный режим");
                Console.WriteLine("5 - южный режим");
                Console.WriteLine("e - завершить программу, записать текущее состояние в файл");

                char key = Console.ReadKey().KeyChar;

                switch (key)
                {
                    case '1':
                        Zanussi.On();
                        break;
                    case '2':
                        Zanussi.Off();
                        break;
                    case '3':
                        Zanussi.Normal();
                        break;
                    case '4':
                        Zanussi.North();
                        break;
                    case '5':
                        Zanussi.South();
                        break;

                    case 'e':
                    case 'у':

            //            //xml
            //            //XmlSerializer formatter = new XmlSerializer(typeof(Fridge));
            //            //// Получаем поток, куда будем записывать сериализованный объект
            //            //using (FileStream fs = new FileStream("fridges.xml", FileMode.OpenOrCreate))
            //            //{
            //            //    formatter.Serialize(fs, Zanussi);
            //            //    Console.WriteLine("Объект сериализован");
            //            //}

                        //binary
                        // Создаем объект BinaryFormatter
                        BinaryFormatter formatter = new BinaryFormatter();
                        // Получаем поток, куда будем записывать сериализованный объект
                        using (FileStream fs = new FileStream("fridges.dat", FileMode.OpenOrCreate))
                        {
                            formatter.Serialize(fs, Zanussi);
                            Console.WriteLine("Объект сериализован");
                        }
                        return;

                }
            }

        }
    }
}
