using System;
namespace C6_Manipulacion_String
{
    class Program
    {
        static void Main(string[] args)
        {
            /* INMUTABILIDAD DE CADENAS*/
            //Se dice que las cadenas son inmutables porque aunque tu le cambias el valor a un cadena
            //la anterior no se elimina en la memoria, por ejemplo si tu creas la varaible nombre 1 con 
            //el valor de Alex y luego redefines la misma variable con el nombre de Kael, en la memoria
            //no se elimina el espacio de Alex, se crea otro espacio con el nombre de Kael a la cual ese
            //name1 ahora hace referencia. Esto te ayuda a ahorrar un montón de espacio en la memoria ya que
            //Si creo otra variable (por ejemplo name4) con el mismo valor (por ejemplo Kael), no se crea
            //Otro espacio de memoria para "Kael", si no que se reutiliza el anteriormente creado.
            string name1 = "Alex";
            string name2 = "Joel";
            //Se guarda el valor de "name1" en "name3"
            name1 = "Kael";
            //Se formatea la información para colocar el nuevo valor 
            name1 += name2;
            Console.WriteLine("Name: {0}", name1);



            Console.WriteLine("");
            /* INTERPOLACIÓN DE CADENAS DE TIPO STRING */

            var nombre = (nombre1: "Kevin", age1:23, nombre2: "Richard");
            Console.WriteLine(nombre); //(Kevin, 23, Richard)
            //El caracter '$' sirve para llamar a elementos de la lista
            //Sirve para indicar que vamos a formatear los datos dentro de la llave
            Console.WriteLine($"{nombre.nombre1} age {nombre.age1} {nombre.nombre2}"); //Kevin age 23 Richard
            //Los elementos estan separados por un espacio

            //Formato Compuesto
            Console.WriteLine("Nombres {0} age {1}", nombre.nombre2, nombre.age1); //Nombres Richard age 23

            //No es necesario colocar el formato compuesto en orden, se puede colocar en desorden siempre y cuando
            //se respete el número de variables a colocar, recordar que empieza desde 0.



            Console.WriteLine("");
            /* SUBCADENAS */

            var curso = "Curso de C# desde cero";
            //La cadena se obtiene desde la posición que se indica como parámetro,
            //se cuenta también los espacios.
            //El primer número como parámeotro es de donde empieza y el segundo donde termina
            //Para contibilizar el segundo se empieza a contar desde el primer número.
            Console.WriteLine("cadena {0}", curso.Substring(9,11)); //cadena C# desde ce
          
            //El primer parámetro es lo que se va a reemplazar y lo segundo es por lo que se va a reemplazar
            //Sirve para reemplazar una parte del valor de la variable
            //Si es texto a reemplazar no se encuentra, no se reemplaza nada.
            var reemplar = curso.Replace("desde cero", ".net core");
            Console.WriteLine("cadena {0}", reemplar); //cadena Curso de C# .net core

            //Se eliminan los caracteres en las posiciones (6-11)
            var delete1 = curso.Remove(5);
            var delete2 = curso.Remove(5,11);
            Console.WriteLine("delete1 {0}", delete1); //delete1 Curso
            Console.WriteLine("delete2 {0}", delete2); //delete2 Cursoe cero



            Console.WriteLine("");
            /* ITERACIÓN DE CADENAS */

            //Sirve para saber en que posición se encuentra un carácter en la cadena del texto
            //El método IndexOf solo recibe un parámetro con tipo de dato char ('') o string ("").
            var clase = "Curso de C# desde cero";
            var caracter = clase.IndexOf('#');
            var texto = clase.IndexOf("desde");
            Console.WriteLine("posición {0}", caracter); //posición 10
            Console.WriteLine("posición {0}", texto); //posición 12

            //Convierte una cadena de texto en un array de tipo char donde cada caracter es una posicion
            var datos = clase.ToCharArray();
            Console.WriteLine("Tamaño de la cadena {0}", datos.Length); //Tamaño de la cadena 22



            Console.WriteLine("");
            /* OTROS MÉTODOS */

            var mayuscula = clase.ToUpper(); //Convierte todos los carácters a mayúscula
            var minuscula = clase.ToLower();//Convierte todos los carácters a minúsula.
            //Devuelve un dato de tipo bool según el resultado de la comparación, en este caso devuelve false
            //porque las cadenas son distintas ya que distingue entre mayúsculas y minúsculas
            var comparacion = clase.Equals(clase.ToLower());

            //Se pueden recorrer todos los caracteres de la cadena con un foreach
            foreach (var c in clase)
            {
                Console.WriteLine(c);
            }

            //En todos los métodos no se modifica la variable original.
            Console.ReadLine();
        }
    }
}