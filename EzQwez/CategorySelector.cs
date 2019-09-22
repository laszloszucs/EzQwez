using System;
using System.Collections.Generic;
using System.Linq;

namespace EzQwez
{
    internal class CategorySelector
    {
        internal static Category Ask()
        {
            var exit = false;
            Category selectedCategory = null;

            while (!exit)
            {
                Console.WriteLine("Válassz az alábbi kategóriák közül");

                var categories = new List<Category>() { new Tenses() };

                foreach (var category in categories)
                {
                    Console.WriteLine($"Igeidők: (I)\n");
                }

                Console.Write("Key: ");

                selectedCategory = categories.FirstOrDefault(x => x.Key.ToLower() == Console.ReadLine().ToLower());
                Console.WriteLine();

                if (selectedCategory == null)
                {
                    Console.WriteLine("Nincs Ilyen kategória!\n");
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("Kérdések:");
            return selectedCategory;
        }
    }
}