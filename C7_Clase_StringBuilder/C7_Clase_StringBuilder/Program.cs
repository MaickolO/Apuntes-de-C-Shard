using System;
using System.Text;

namespace C7_Clase_StringBuilder
{
    class Program
    {
        static void Main (string[] args)
        {
            //Al ser mutable no se crea un nuevo espacio en la memoria sino que se modifica el valor original.
            //Las cadenas de texto creadas con StringBuilder no son Inmutables
            //Cuando tengamos una aplicacion donde se usen muchas cadenas de texto es más preferible usar StringBuilder
            StringBuilder name = new StringBuilder("Michael");
            Console.WriteLine(name.ToString()); //Michael


            /*Modificar un caracter */
            //Modificar el primer caracter de la variable (al modificar solo 1 caracter acepta solo
            //tipo de dato char)
            name[0] = 'K'; 
            Console.WriteLine(name.ToString()); //Kichael


            /* Agregar mas datos (lo anterior no se elimina) */
            name.Append(" Orlando");
            Console.WriteLine(name.ToString()); //Kichael Orlando
            //Para hacer salto de linea se necesita el método AppendLine();
            name.AppendLine();
            name.Append("Orizano").Append(" ").Append("Zevallos");
            Console.WriteLine(name.ToString());
            /*Kichael Orlando
             * Orizano Zevallos */


            /*AppendFormat */
            //Sirve para formatear el dato y convertirlo a otro tipo de dato
            name.AppendLine();
            name.AppendFormat("Age {0}",50);
            Console.WriteLine(name.ToString());
            /*Kichael Orlando
            * Orizano Zevallos
            * Age 50*/

            /*Gestionar la capacidad de la cadena */
            name.Capacity = 150;
            //La cadena solo soporta 150 caracteres, si el numero de caracteres es superior
            //nos muestra un error.

            Console.ReadLine();
        }
    }
}