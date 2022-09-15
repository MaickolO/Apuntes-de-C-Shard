using System;

namespace C5_While
{
    class Program
    {
        static void Main(string[] args)
        {
            /* WHILE */

            var valor = true;
            var count = 1;
            //Se ejecutará el codigo dentro de while si su condición es verdadera.
            //Si su condición es falsa no se ejecutará.
            //Si no se cambia el valor de la condición, while se ejecutará infinitamente.

            //En cada bucle primero se evalua su condición y si es verdadera se sigue ejecutando
            while (valor)
            {
                //Código a ejecutar si valor es true
                if (count == 6)
                {
                    valor = false;
                }
                Console.WriteLine("Ejecución de while {0}", count);
                count++;
            }
            Console.ReadLine();


            /* DO-WHILE */

            //En do-while se ejecuta primero lo que esta dentro de do y luego se evalua
            //lo que está almacenado dentro de la condición de while para evaluar si se
            //va a volver a ejecutar.

            valor = true;
            count = 1;
            do
            {
                //Código a ejecutar si while es true
                if (count == 6)
                {
                    valor = false;
                    //break;
                }
                Console.WriteLine("Ejecución de do-while: {0}", count);
                count++;
            } while (valor);
            //Si se ejecuta el break; directamente se ejecuta el while o el do.while
            //En pocas palabras while primero observa su condición y si se cumple se ejecuta, haciendolo en cada bucle.
            //En cambio do-while primero se ejecuta y luego se fija si se cumple su condición para volver a ejecutarse.

        }
    }
}
