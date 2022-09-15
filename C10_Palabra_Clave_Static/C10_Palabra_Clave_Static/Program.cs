using System;

namespace C10_Palabra_Clave_Static
{
    class Program
    {
        static void Main()
        {
            var data = new Conversor();
            data.velocidad = 3.0; //inicializamos la varaible velocidad 
            var data1 = new Conversor();
            /* Al instancia nuevamente la funcion, la variable velocidad se define de nuevo 
             * con valor null, sin destruir la variable anterior */

            /* La unica forma de invocar una variable estática es con la clase, 
             * al ser una varaible estática ahora si instanciamos nuevamente la funcion 
             * ya no se cambia la informacion de la variable. Ademas las variables estaticas solo 
             * utiliza un espacio en memoria al contrario de si no fuera estatica*/
            //Sin embargo static nos quita el poder desarrollar en POO.
            Conversor.vel = 3.0;

            /* METODO ESTATICO */
            //Dentro de un metodo estatico no se puede invocar a un atributo que no sea estatico
            //Pero se pueden crear variables locales no estaticas dentro del metodo estatico.
            //Se pueden usar variables globales estaticas dentro de metodos no estaticos.
            Conversor.Conversor1();
            Conversor.Conversor2();

            /* CLASE ESTATICA */
            clase_estatica.metodo();
        }

        class Conversor
        {
            public double velocidad; //Definimos la variable velocidad
            public static double vel; //Definimos una variable estitca

            /* METODO ESTATICO */
            public static void Conversor1()
            {
                vel += 20;
            }

            public static void Conversor2()
            {
                vel += 40;
            }
        }
    }

    /* CLASE ESTATICA */
    static class clase_estatica
    { //Las clases estaticas solo pueden almacenar o contener elementos estaticos
      //No se puede instanciar la clase estatica, por lo que a la clase estatica no se le 
      //puede crear un metodo constructor amenos que el metodo constructor tambien sea estatico.
      //No puede tener modificadores de visibilidad el metodo constructor
        static clase_estatica()
        {//Metodo COnstructor estatico
        }

        static int num2 = 0; //Variable estatica
        public static void metodo() //Metodo estatico
        {
            Console.WriteLine("clase estatica");
        }
    }
}
