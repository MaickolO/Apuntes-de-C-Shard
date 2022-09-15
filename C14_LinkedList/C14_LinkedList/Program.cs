using System;
using System.Collections.Generic;

namespace C14_LinkedList
{
    class Program
    {
        static void Main()
        {
            /* INSTANCIAR UNA LISTA ENLAZADA */
            LinkedList<String> lista_enlazada = new LinkedList<string>();

            /* AGREGAR UN NODO AL INICIO O AL FINAL DE LA LISTA */
            lista_enlazada.AddFirst("b"); // (b)
            lista_enlazada.AddFirst("a"); // (a,b)
            lista_enlazada.AddLast("c");  // (a,b,c)

            /* AGREGAR UN NODO AL MEDIO DE UNA LISTA */
            //Para agregar un nuevo nodo, debes hacer referencia a un nodo que va a estar 
            //enlazada con el nodo agregado
            //Primero se tiene que instanciar el nodo al que se va a hacer referencia
            LinkedListNode<String> nodo_instanciado = lista_enlazada.Find("c"); //Se instancia el nodo con el valor "c"
            lista_enlazada.AddAfter(nodo_instanciado, "d"); // (a,b,c,d)
            lista_enlazada.AddBefore(nodo_instanciado, "0"); // (a,b,0,c,d)

            /* AGREGAR EL VALOR DEL PRIMER NODO AL FINAL DE LA LISTA */
            /* No se puede mover el primer nodo defrente porque todavia existe,
             * primero se tendría que eliminar
             * Pero en esta ocasión solo necesitamos moverel valor del nodo y no el objeto */
            /* Si queremos agregar el valor del último nodo al inicio de la lista enlazada 
             * solo tenemos que cambiar el metodo .First por .Last y .AddLast() por .AddFirst() */
            nodo_instanciado = lista_enlazada.First; //Cambiamos el valor del nodo instanciado
            String valor = nodo_instanciado.Value; //Obtener el valor del nodo
            lista_enlazada.AddLast(valor); // (a,b,0,c,d,a)

            /* MOVER EL ÚLTIMO NODO AL PRIMER NODO */
            //Como los valores actuales son (a,b,0,c,d,a) agregamos un valor adicional al final para
            //diferenciar el valor inicial y el valor final
            //Cambiamos el valor del nodo instanciado por el último nodo
            nodo_instanciado = lista_enlazada.Last; //a
            lista_enlazada.RemoveLast(); //Eliminamos el ultimo nodo -> (a,b,0,c,d)
            lista_enlazada.AddFirst(nodo_instanciado); //(a,a,b,0,c,d)

            /* OBTENER EL ULTIMO NODO QUE CONTENGA LA ÚLTIMA OCURRENCIA DE UN VALOR */
            nodo_instanciado = lista_enlazada.FindLast("a"); //Al ser un nodo para obtener su valor se necesita el .Value

            /* INSTANCIAR EL NODO QUE SE ENCUENTRA ANTES A UN NODO REFERENCIADO */
            //Hace referencia al nodo anterior al instanciado (a,[a],b,0,c,d)
            LinkedListNode<String> nodo_instanciado2 = nodo_instanciado.Previous; //([a],a,b,0,c,d)

            /* REMUEVO UN NODO Y LO AGREGO REFERENCIADO OTRO POR NODO */
            //nodo_instanciado -> d y nodo_instanciado2 -> a
            nodo_instanciado = lista_enlazada.Find("d"); //(a,a,b,0,c,[d])
            lista_enlazada.Remove(nodo_instanciado); // (a,a,b,0,c,d)->(a,a,b,0,c)
            lista_enlazada.AddBefore(nodo_instanciado2, nodo_instanciado); // (a,a,b,0,c)->(d,a,a,b,0,c)
            //AddAfter -> Si en vez de agregar antes del nodo referido se quiere agregar despues.

            /* ELIMINAR UN NODO */
            lista_enlazada.Remove("a"); //Eliminar la primera aparación del valor: (d,a,a,b,0,c) -> (d,a,b,0,c)
            lista_enlazada.RemoveFirst(); //Eliminar El primer nodo: (d,a,b,0,c) -> (a,b,0,c)

            /* SABER SI SE ENCUENTRA UN ELEMENTO */
            bool encontrar = lista_enlazada.Contains("b"); //true

            /* CONTAR NUMERO DE ELEMENTOS */
            int num_elementos = lista_enlazada.Count; //4

            /* ELIMINAR TODOS LOS ELEMENTOS DE UNA LISTA */
            //lista_enlazada.Clear();

            /* CREAR UN ARRAY CON EL MISMO NUMERO DE ELEMENTOS QUE LA LISTA */
            string[] Array = new string[lista_enlazada.Count];
            lista_enlazada.CopyTo(Array, 0); //Nombre de la array, posicion desde la que comenzar
            for (int i = 0; i < Array.Length; i++)
            {
                Console.WriteLine("El elemento {0} esta en la posicion {1}", Array[i], i);
            }

            /* IMPRIMIR TODOS LOS ELEMENTOS */
            foreach (var item in lista_enlazada)
            {
                Console.WriteLine("Elemento de la lista: " + item);
            }
            /* Si intentas hacer ingresar un nodo en otra posicion cuando ya está en la coleccion
             * vas a obtener un error de ejecución */
            /* Si el LinkedList está vacío las propiedades First y Last contienen null */
        }
    }
}