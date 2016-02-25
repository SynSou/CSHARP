using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace example_reflection
{
    class Class2
    {
        public static void Cry()
        {
            Console.WriteLine("dog");
        }

        private void Cry2()
        {
            Console.WriteLine("123456");
        }

        public string Cry3(string animal,List<string> sound)
        {
            return string.Concat(animal, string.Join(" ", sound.ToArray()));
           
        }
    }
}
