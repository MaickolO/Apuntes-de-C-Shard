using System;
using System.Collections.Generic;

namespace C15_Queue_Colas
{
    /* Queue se usa cuando se necesita una aplicación que tenga que realizar procesos
     * de forma secuencial. 
     * El primero en entrar es el primero en salir (FIFO).
    */
    class Example
    {
        public static void Main()
        {
            //Instanciar la clase
            Queue<string> queue = new Queue<string>();


            //Agregar elementos (Enqueue)
            queue.Enqueue("uno");
            queue.Enqueue("dos");
            queue.Enqueue("tres");

            //Agregar elementos de un Array
            foreach (var item in new String[2] {"cuatro", "cinco"})
            {
                queue.Enqueue(item);
            }
            //Mostrar todos los elementos (foreach)
            Console.WriteLine("Recorriendo el Queue:");
            foreach (string elementos in queue)
            {
                Console.WriteLine(elementos);
            }


            //Obtener el primer elemento sin eliminarlo
            var elem = queue.Peek();
            Console.WriteLine("");
            Console.WriteLine("Primer Elemento: ");
            Console.WriteLine(elem);


            //Obtener el número de elementos
            var num_elem = queue.Count;
            Console.WriteLine("");
            Console.WriteLine("Número de elementos: ");
            Console.WriteLine(num_elem);


            //Saber si contienen un elemento
            var encontrar = "seis";
            var valor = queue.Contains(encontrar);
            Console.WriteLine("");
            Console.WriteLine("¿La lista contienen {0}?: {1}", encontrar, valor);


            //Devuelve un valor (bool) que indica si hay un elemento al inicio del queue
            var val = "uno";
            var res = queue.TryPeek(out val);
            Console.WriteLine("");
            Console.WriteLine("¿La lista contienen {0}?: {1}", val, res);


            //Guarda el primer elemento en una variable y lo elimina del queue.
            queue.TryDequeue(out var elem_guardado);
            Console.WriteLine("");
            Console.WriteLine("Primer elemento guardado y eliminado: ");
            Console.WriteLine(elem_guardado);


            //Eliminando elementos del Queue
            /* Al eliminar un elemento se elimina en el orden en el que se ingresaron.
             * Dequeue no admite argumentos.
            */
            queue.Dequeue();
            Console.WriteLine("");
            Console.WriteLine("Eliminando Elemento:");
            foreach (string elementos in queue)
            {
                Console.WriteLine(elementos);
            }


            //Eliminar todos los elementos del Queue
            queue.Clear();


            Console.ReadLine();
        }
    }
}
