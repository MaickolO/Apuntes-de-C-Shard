using System;
using System.Collections.Generic;

namespace C16_Stacks
    /* El ultimo elemento en entrar es el primero en salir (LIFO).
     * Para poner un ejemplo los coloca como una pila de platos, si intentas quitar
     * un plato debes empezar desde el que se encuentra arriba, osea el último agregado.
    */
{
    class Program
    {
        static private void Main()
        {

            //Instanciar la clase
            Stack<int> stack = new Stack<int>();

            //Introducir un elemento
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);


            //Introducir elementos de un Array
            foreach (var num in new int[2] {4,5})
            {
                stack.Push(num);
            }
            //Recorrer la colección
            Console.WriteLine("Recorriendo elementos del Stack:");
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }


            //Obtener el numero de elementos
            var num_elem = stack.Count;
            Console.WriteLine("");
            Console.WriteLine("El número de elementos es: {0}", num_elem);


            //Devolver el elemento superior sin eliminarlo
            var el = stack.Peek();
            Console.WriteLine("");
            Console.WriteLine("El elemento superio es {0}", el);


            //Eliminar el elemento de la parte superior (ultimo agregado)
            stack.Pop();
            Console.WriteLine("");
            Console.WriteLine("Eliminando elemento:");
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
