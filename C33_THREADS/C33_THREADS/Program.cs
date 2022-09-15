using System;
using System.Threading;


namespace C33_THREADS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* INSTANCIAR UN THREAD (UN MÉTODO COMO PARÁMETRO)*/
            //Creamos un nuevo hilo o thread
            Thread hilo2 = new Thread(MetodoSaludo);

            /* EJECUTAR UN THREAD */
            //Hacemos que el nuevo hilo comienze
            hilo2.Start();

            /* SINCRONIZAR UN THREAD */
            //Ordena que mientras se ejecute este thread no se ejecute el siguiente thread
            hilo2.Join();

            Thread hilo3 = new Thread(MetodoSaludo);
            hilo3.Start();
            


            Console.WriteLine("Hola Thread (Hilo) 1");
            //Metodo para "dormir" un hilo por un periodo de tiempo ingresada como parámetro (en ms).
            Thread.Sleep(500);
            Console.WriteLine("Hola Thread (Hilo) 1");
            Thread.Sleep(500);
            Console.WriteLine("Hola Thread (Hilo) 1");

            /* AL EJECUTAR SIN SINCRONIZAR los mensajes se mezclan sin orden en absoluto, en cambio
             * el hilo sincronizado no permite la ejecución de otro hilo hasta que complete sus 
             * instrucciones
             */
        }

        static void MetodoSaludo()
        {
            Console.WriteLine("Hola Thread (Hilo) 2");
            //Metodo para "dormir" un hilo por un periodo de tiempo ingresada como parámetro (en ms).
            Thread.Sleep(500);
            Console.WriteLine("Hola Thread (Hilo) 2");
            Thread.Sleep(500);
            Console.WriteLine("Hola Thread (Hilo) 2");
        }

    }
}