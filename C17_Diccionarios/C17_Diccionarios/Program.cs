using System;
using System.Collections.Generic;

namespace C17_Diccionarios
{
    /* TKey = Obtiene la clave del par clave-valor
     * TValue = Obtiene el valor del par clave-valor
     * Al recorrer un diccionario con un foreach nos devuelve un elemento con clave-valor
    */

    class Program
    {
        static void Main()
        {
            //Instanciando la clase Dictionary
            Dictionary<string, int> diccionario = new Dictionary<string, int>();


            //Agregando valores al diccionario
            diccionario.Add("michael", 22);
            diccionario.Add("Lorena", 24);
            diccionario.Add("Bilha", 32);
            diccionario["Kerly"] = 14;
            diccionario["Ricardo"] = 12;


            //Recorrer el diccionario con un bucle foreach
            foreach (KeyValuePair<String, int> persona in diccionario)
            {
                Console.WriteLine("Nombre: "+persona.Key + ", " + "Edad: " + persona.Value);
            }

        }
    }
}
