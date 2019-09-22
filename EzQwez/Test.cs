using System;
using System.Collections.Generic;
using System.Linq;

namespace EzQwez
{
    internal class Test
    {
        private readonly IEnumerable<Qwez> _pool;

        public Test(IEnumerable<Qwez> pool)
        {
            Random random = new Random();
            _pool = pool.OrderBy(a => random.Next());
            Display();
        }

        private void Display()
        {
            foreach (var qwez in _pool)
            {
                Console.WriteLine(qwez.Hungarian);
                Console.ReadLine();
                Console.WriteLine(qwez.English);
                Console.WriteLine();
            }
        }
    }
}