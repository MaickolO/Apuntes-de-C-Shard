using System;
using System.Collections.Generic;
using System.Linq;

namespace C30_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] valores_numericos = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            /* OBTENER LOS NUMEROS PARES SIN UTILIZAR LINQ */
            Console.WriteLine("números pares");

            List<int> numeros_pares = new List<int>();

            foreach (var item in valores_numericos)
            {
                if(item % 2 == 0)
                {
                    numeros_pares.Add(item);
                }
            }
            foreach (var item in numeros_pares)
            {
                Console.WriteLine(item);
            }


            /* OBTENER LOS NUMEROS PARES UTILIZANDO LINQ */

            //"numero" es el nombre de una variable, puede ser cualquier nombre
            //"valores_numericos" es el array donde se encuentran los numeros
            IEnumerable<int> numPares = from numero in valores_numericos 
                                        where numero%2==0 select numero;

            foreach (var item in numPares)
            {
                Console.WriteLine(item);
            }

        } 
    }
}