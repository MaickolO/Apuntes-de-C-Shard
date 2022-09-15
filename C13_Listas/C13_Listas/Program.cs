using System;
using System.Collections.Generic;

namespace C13_Listas
{
    class Program
    {


        static void Main()
        {
            //Otra forma de mostrar la lista
            List<String> lista_string = new List<string>()
            {
                "name1", "name2", "name3"
            };

            //Con la clase Object podemos agregar cualquier tipo de dato
            //Como un array las listas se ordenan comenzando desde la posicion 0
            List<Object> lista = new List<Object>();
            
            lista.Add(32); //Posicion 0
            lista.Add("hola mundo"); //Posicion 1
            lista.Add(true); //Agregar un elemento. Pos 2
            lista.Add("hola mundo"); //Posicion 1 Pos 3


            /* ELIMINAR UN ELEMENTO EN LA LISTA */
            /* Al eliminar los elementos, los elementos restantes corren a la posicion anterior
             * por ejemplo si elimino el elemento en la posicion 0, el elemento en la posicion 1
             * se vuelve ahora el elemento en la posicion 0, el elemento en la posicion 2 se mueve
             * a la posicion 1 y asi sucesivamente. */
            //lista.Remove("hola mundo"); //Eliminar un elemente
            /* CONTAR NUMERO DE ELEMENTOS EN LA LISTA */
            int num_elementos = lista.Count; //Numero de elementos de la lista

            /* INSERTAR DATOS EN UNA POSICION ASIGNADA EN LA LISTA */
            //El elemento agregado debe estar ligado a los otros elementos de la lista
            //Osea que si tiene solo elementos hasta la posicion 2 no podemos agregar un elemento a la posicion 4
            //ya que no estaria ligado con los otros elementos
            lista.Insert(2,"posicion2");

            /* BUSCAR UN ELEMENTO Y RETORNA LA POSICION */
            lista.IndexOf("posicion2"); //regresa 2

            /* BUSCAR UN ELEMENTO Y RETORNA LA POSICION ESPECIFICANDO LA POSICION INICIAL*/
            //Si no encuentra el elemento que mandamos a buscar saldrá -1}
            //Aunque comienze a buscar desde la posicion en la que se encuentra puede hallarlo
            //Por ejemplo si le dices que busque el elemento en la pos 2 desde la pos 2 el resultado sera 2
            lista.IndexOf(true,0); //1

            /* BUSCAR UN ELEMENTO Y RETORNA LA POSICION ESPECIFICANDO LA POSICION INICIAL Y FINAL */
            //Si esta en la posicion 2 y le damos que busque hasta la posicicon 2 no
            //lo va a encontrar, para que lo encuentre tenemos que darle una posicion adicional
            var elemento = lista.IndexOf("hola mundo", 0, 3); //->2
            var elemento2 = lista.IndexOf("hola mundo", 2, 3);

            /* OBTENER LA POSICION DEL ULTIMO VALOR ESPECIFICADO EN LA COLECCION */
            //Obtiene la posicion del ultimo valor especificado en la coleccion
            //Sin importar cuantas veces se repita el dato, nos va a dar la posicion del ultimo.
            //Tambien se le puede especificar un rango como con IndexOf por si no se quiere obtener
            //El ultimo, si no hacer la busqueda hasta un elemento especificado
            lista.LastIndexOf("hola mfdundo");
            lista.LastIndexOf("hola mundo",3); //Busca hasta el elemento 3

            /* REVERTIR LA COLECCION DE DATOS */
            //Se revierte la posicion de los elements (El ultimo pasa a la primera y viceversa, asi para todos los elementos).
            lista.Reverse();

            /* BUSCAR ELEMENTO EN LA COLECCION */
            //Buscar si un elemento se encuentra en la lista segun un elemento
            //el metodo retorna un tipo de dato bool
            bool busqueda = lista.Contains("hola mundo");

            /* BUSCAR UNA COLECCION DE DATOS EN LA LISTA */
            //Buscar si un elemento se encuentra en la lista segun un predicado
            //el metodo retorna un tipo de dato bool
            bool buscar_coleccion = lista.Exists(e => e.Equals("hola mundo"));

            /* DIFERENCIA CONTAINS Y EXISTS */
            //A diferencia de constains, Exists permite obtener comparar una propiedad de una clase 
            //Sin tener que instanciar la clase por ejemplo:
            //Se busca comparar la primera propiedad de la clase estudiantes (tiene 2 propiedades),
            //la propiedad esta designada como "prop1" y la otra propiedad es de tipo de dato string
            //CONTAINS: lista.Contains(new Estudiantes(prop1 = 23, prop2 = ""));
            //EXISTS: lista.Exists(e => e.prop1 == 23);

            /* ELIMINAR TODOS LOS ELEMENTOS DE LA LISTA */
            //lista.Clear();

            /* MOSTRAR UN ELEMENTO DE LA LISTA */
            Console.WriteLine(lista[0]);
            Console.WriteLine(" ");

            /* RECORRER TODOS LOS ELEMENTOS DE LA LISTA */
            lista.ForEach(item =>
            {
                Console.WriteLine(item);
                Console.WriteLine(" ");
            });

            foreach (var item in lista) //Otra forma de Foreach mas adecuada para una coleccion de datos
            {
                Console.WriteLine(item);
                Console.WriteLine(" ");
            }

            /*Se usa cuando no necesitamos saber la posicion, para saber la posicion podemos
             * usar el ciclo for tradicional */
            for (int i = 0; i < lista.Count; i++)
            {
                Console.WriteLine("El elemento {0} se encuentra en la posicion {1}", lista[i], i);
                Console.WriteLine(" ");
            }

            /* Otra forma de recorrer mediante for*/
            int j = 0;
            for(; ; )
            {
                if (j < lista.Count)
                {
                    Console.WriteLine("El elemento {0} se encuentra en la posicion {1}", lista[j], j);
                    j++;
                    Console.WriteLine(" ");
                } else
                {
                    break;
                }
            }
            Console.ReadLine();
        }
    }
}