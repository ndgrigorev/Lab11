using Lab10_Library;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
namespace Lab11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Часть1
            Stack animals = new Stack();
            for (int i = 0; i < 2; i++)
            {
                Animals animal = new Animals();
                animal.RandomInit();
                animals.Push(animal);
            }
            for (int i = 0; i < 2; i++)
            {
                Mammals animal = new Mammals();
                animal.RandomInit();
                animals.Push(animal);
            }
            for (int i = 0; i < 2; i++)
            {
                Cats animal = new Cats();
                animal.RandomInit();
                animals.Push(animal);
            }
            for (int i = 0; i < 2; i++)
            {
                Fishes animal = new Fishes();
                animal.RandomInit();
                animals.Push(animal);
            }
            foreach (object obj in animals)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
            //запросы
            double sum = 0;
            int count = 0;
            foreach (Animals animal in animals)
            {
                if (animal is Mammals mammal)
                {
                    sum += mammal.Weight;
                    count++;
                }
            }
            Console.WriteLine($"Средний вес млекопитающих = {Math.Round(sum / count, 2)}");
            string[] names = new string[animals.Count];
            int j = 0;
            foreach (Animals animal in animals)
            {
                Cats cat = animal as Cats;
                if (cat != null)
                {
                    if (cat.Color != "рыжий")
                    {
                        names[j++] = cat.Name;
                    }
                }
            }
            for (int i = 0; i < j; i++)
            {
                Console.WriteLine(names[i]);
            }
            int maxAge = -1;
            string name = null;
            foreach (Animals animal in animals)
            {
                if (typeof(Fishes) == animal.GetType())
                {
                    Fishes fish = (Fishes)animal;
                    if (fish.Age > maxAge)
                    {
                        maxAge = fish.Age;
                        name = fish.Name;
                    }
                }
            }
            Console.WriteLine($"Самая старшая рыба - {name}");
            Console.WriteLine();
            Stack animalsClone = (Stack)animals.Clone();
            Animals example = new Animals(100, "Образец", "мужской", 12);
            animals.Push(example);
            //сортировка и поиск
            object[] animalsArr = new object[animals.Count];
            animalsArr = animals.ToArray();
            int k = 0;
            foreach (Animals animal in animals)
            {
                animalsArr[k++] = animal;
            }
            Array.Sort(animalsArr);
            animals.Clear();
            for (int i = animalsArr.Length - 1;i >= 0; i--)
            {
                animals.Push(animalsArr[i]);
            }
            foreach (object obj in animals)
            {
                Console.WriteLine(obj);
            }
            if (animals.Contains(example))
            {
                int p = 0;
                foreach(Animals animal in animals)
                {
                    if(animal == example)
                    {
                        Console.WriteLine($"Искомый элемент найден на позиции {p + 1}");
                        break;
                    }
                    p++;
                }
            }
            Console.WriteLine();
            //удаление
            Console.WriteLine("Удаление");
            Stack temp = new Stack();
            foreach (Animals animal in animals)
            {
                if (!(animal.Equals(example)))
                {
                    temp.Push(animal);
                }
            }
            animals.Clear();
            foreach(Animals animal in temp)
            {
                animals.Push(animal);
            }
            foreach (Animals animal in animals)
            {
                Console.WriteLine(animal);
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------");
            //Часть2
            List<Animals> animalsList = new List<Animals>();
            for (int i = 0; i < 2; i++)
            {
                Animals animal = new Animals();
                animal.RandomInit();
                animalsList.Add(animal);
            }
            for (int i = 0; i < 2; i++)
            {
                Mammals animal = new Mammals();
                animal.RandomInit();
                animalsList.Add(animal);
            }
            for (int i = 0; i < 2; i++)
            {
                Cats animal = new Cats();
                animal.RandomInit();
                animalsList.Add(animal);
            }
            for (int i = 0; i < 2; i++)
            {
                Fishes animal = new Fishes();
                animal.RandomInit();
                animalsList.Add(animal);
            }
            foreach (Animals obj in animalsList)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
            //запросы
            sum = 0;
            count = 0;
            foreach (Animals animal in animalsList)
            {
                if (animal is Mammals mammal)
                {
                    sum += mammal.Weight;
                    count++;
                }
            }
            Console.WriteLine($"Средний вес млекопитающих  = {Math.Round(sum / count, 2)}");
            string[] names2 = new string[animalsList.Count];
            j = 0;
            foreach (Animals animal in animalsList)
            {
                Cats cat = animal as Cats;
                if (cat != null)
                {
                    if (!(cat.Color == "рыжий"))
                    {
                        names2[j++] = cat.Name;
                    }
                }
            }
            for (int i = 0; i < j; i++)
            {
                Console.WriteLine(names2[i]);
            }
            maxAge = -1;
            name = null;
            foreach (Animals animal in animalsList)
            {
                if (typeof(Fishes) == animal.GetType())
                {
                    Fishes fish = (Fishes)animal;
                    if (fish.Age > maxAge)
                    {
                        maxAge = fish.Age;
                        name = fish.Name;
                    }
                }
            }
            Console.WriteLine($"Самая старшая морская рыба - {name}");
            Console.WriteLine();
            //сортировка и поиск
            Animals example2 = new Animals(100, "Рекс", "мужской", 12);
            animalsList[0] = example2;
            animalsList.Sort();
            foreach (Animals obj in animalsList)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine($"Элемент находится на позиции {animalsList.BinarySearch(example2) + 1}");
            animalsList.Remove(example2);
            Console.WriteLine();
            foreach (Animals obj in animalsList)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine("-------------------------------------------------------------------------------------");
            //часть3
            TestCollections time = new TestCollections(1000);
            time.Testing();
        }
    }
}
