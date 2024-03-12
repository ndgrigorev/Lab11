using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Lab10_Library;
using System.Security.Cryptography;

namespace Lab11
{
    internal class TestCollections
    {
        public Dictionary <Animals, Mammals> collection1 = new Dictionary<Animals, Mammals> ();
        public Dictionary<string, Mammals> collection2 = new Dictionary<string, Mammals>();
        public SortedSet<Mammals> collection3 = new SortedSet <Mammals> ();
        public SortedSet<string> collection4 = new SortedSet <string> ();

        Mammals? first, middle, last, noexist;

        Stopwatch sw = Stopwatch.StartNew();

        bool mainCheck = true;

        public TestCollections(int length)
        {
            for (int i = 0; i < length; i++)
            {
                Mammals animal = new Mammals();
                animal.RandomInit();
                animal.Name = i.ToString() + animal.Name;
                collection1.Add(animal.GetBase(), animal);
                collection2.Add(animal.GetBase().ToString(), animal);
                collection3.Add(animal);
                collection4.Add(animal.ToString());
                if (i == 0)
                {
                    first = (Mammals)animal.Clone();
                }
                if (i == length / 2)
                {
                    middle = (Mammals)animal.Clone();
                }
                if (i == length - 1)
                {
                    last = (Mammals)animal.Clone();
                }
            }
            Mammals animal2 = new Mammals();
            animal2.RandomInit();
            animal2.Id.Number = 0;
            noexist = (Mammals)animal2.Clone();
        }
        public void Testing()
        {
            //первая коллекция
            double time = TestCollection1(first);
            if (mainCheck)
            {
                Console.WriteLine($"Первый элемент в collection1 найден за {time}");
            }
            else
            {
                Console.WriteLine($"Первый элемент в collection1 не найден за {time}");
            }
            time = TestCollection1(middle);
            if (mainCheck)
            {
                Console.WriteLine($"Центральный элемент в collection1 найден за {time}");
            }
            else
            {
                Console.WriteLine($"Центральный элемент в collection1 не найден за {time}");
            }
            time = TestCollection1(last);
            if (mainCheck)
            {
                Console.WriteLine($"Последний элемент в collection1 найден за {time}");
            }
            else
            {
                Console.WriteLine($"Последний элемент в collection1 не найден за {time}");
            }
            time = TestCollection1(noexist);
            if (mainCheck)
            {
                Console.WriteLine($"Несуществующий элемент в collection1 найден за {time}");
            }
            else
            {
                Console.WriteLine($"Несуществующий элемент в collection1 не найден за  {time}");
            }
            //вторая коллекция
            Console.WriteLine();
            time = TestCollection2(first);
            if (mainCheck)
            {
                Console.WriteLine($"Первый элемент в collection2 найден за {time}");
            }
            else
            {
                Console.WriteLine($"Первый элемент в collection2 не найден за {time}");
            }
            time = TestCollection2(middle);
            if (mainCheck)
            {
                Console.WriteLine($"Центральный элемент в collection2 найден за {time}");
            }
            else
            {
                Console.WriteLine($"Центральный элемент в collection2 не найден за {time}");
            }
            time = TestCollection2(last);
            if (mainCheck)
            {
                Console.WriteLine($"Последний элемент в collection2 найден за {time}");
            }
            else
            {
                Console.WriteLine($"Последний элемент в collection2 не найден за {time}");
            }
            time = TestCollection2(noexist);
            if (mainCheck)
            {
                Console.WriteLine($"Несуществующий элемент в collection2 найден за {time}");
            }
            else
            {
                Console.WriteLine($"Несуществующий элемент в collection2 не найден за  {time}");
            }
            //третья коллекция
            Console.WriteLine();
            time = TestCollection3(first);
            if (mainCheck)
            {
                Console.WriteLine($"Первый элемент в collection3 найден за {time}");
            }
            else
            {
                Console.WriteLine($"Первый элемент в collection3 не найден за {time}");
            }
            time = TestCollection3(middle);
            if (mainCheck)
            {
                Console.WriteLine($"Центральный элемент в collection3 найден за {time}");
            }
            else
            {
                Console.WriteLine($"Центральный элемент в collection3 не найден за {time}");
            }
            time = TestCollection3(last);
            if (mainCheck)
            {
                Console.WriteLine($"Последний элемент в collection3 найден за {time}");
            }
            else
            {
                Console.WriteLine($"Последний элемент в collection3 не найден за {time}");
            }
            time = TestCollection3(noexist);
            if (mainCheck)
            {
                Console.WriteLine($"Несуществующий элемент в collection3 найден за {time}");
            }
            else
            {
                Console.WriteLine($"Несуществующий элемент в collection3 не найден за  {time}");
            }
            //третья коллекция
            Console.WriteLine();
            time = TestCollection4(first);
            if (mainCheck)
            {
                Console.WriteLine($"Первый элемент в collection4 найден за {time}");
            }
            else
            {
                Console.WriteLine($"Первый элемент в collection4 не найден за {time}");
            }
            time = TestCollection4(middle);
            if (mainCheck)
            {
                Console.WriteLine($"Центральный элемент в collection4 найден за {time}");
            }
            else
            {
                Console.WriteLine($"Центральный элемент в collection4 не найден за {time}");
            }
            time = TestCollection4(last);
            if (mainCheck)
            {
                Console.WriteLine($"Последний элемент в collection4 найден за {time}");
            }
            else
            {
                Console.WriteLine($"Последний элемент в collection4 не найден за {time}");
            }
            time = TestCollection4(noexist);
            if (mainCheck)
            {
                Console.WriteLine($"Несуществующий элемент в collection4 найден за {time}");
            }
            else
            {
                Console.WriteLine($"Несуществующий элемент в collection4 не найден за {time}");
            }
        }
        private double TestCollection1(Mammals? animal)
        {
            double time = 0;
            mainCheck = true;
            bool check = true;
            bool check2 = true;
            for (int i = 0; i < 50; i++)
            {
                sw.Restart();
                check = collection1.ContainsKey(animal.GetBase());
                check2 = collection1.ContainsValue(animal);
                sw.Stop();
                time += sw.ElapsedTicks;
                if (!(check && check2))
                {
                    mainCheck = false;
                }
            }
            return time / 50.0;
        }
        private double TestCollection2(Mammals? animal)
        {
            double time = 0;
            mainCheck = true;
            bool check = true;
            bool check2 = true;
            for (int i = 0; i < 50; i++)
            {
                sw.Restart();
                check = collection2.ContainsKey(animal.GetBase().ToString());
                check2 = collection2.ContainsValue(animal);
                sw.Stop();
                time += sw.ElapsedTicks;
                if (!(check && check2))
                {
                    mainCheck = false;
                }
            }
            return time / 50.0;
        }
        private double TestCollection3(Mammals? animal)
        {
            double time = 0;
            mainCheck = true;
            bool check = true;
            for (int i = 0; i < 50; i++)
            {
                sw.Restart();
                check = collection3.Contains(animal);
                sw.Stop();
                time += sw.ElapsedTicks;
                if (!check)
                {
                    mainCheck = false;
                }
            }
            return time / 50.0;
        }
        private double TestCollection4(Mammals? animal)
        {
            double time = 0;
            mainCheck = true;
            bool check = true;
            for (int i = 0; i < 50; i++)
            {
                sw.Restart();
                check = collection4.Contains(animal.ToString());
                sw.Stop();
                time += sw.ElapsedTicks;
                if (!check)
                {
                    mainCheck = false;
                }
            }
            return time / 50.0;
        }
    }
}
