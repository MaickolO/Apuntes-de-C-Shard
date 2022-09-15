namespace C38_Tasks_Parallel
{
    internal class Program
    {

        private static int acomulador = 0;
        static void Main(string[] args)
        {
            /* Clase Parallel
             * 
             * Brinda apoyo para bucles paralelos y regiones.
             * 
             * Sus métodos principales son .for() y .forEach(), los cuales están
             * fuertemente sobrecargados
             * 
             * Sus métodos .for() y .forEach() sirven para reemplazar a los bucles
             * for y forEach tradicionales cuando se ven involucrados en tareas 
             * concurrentes (Por ejemplo cuando existan varias tareas (Tasks) que tengan
             * que ejecutar paralelamente un método).
             * 
             * A diferencia de crear varios Tasks, la clase Parallel sirve para programas
             * más complejos y para ahorrar líneas de código.
             * 
             * La clase Parallel no se usa cuando una tarea depende de otra, solo es necesaria
             * cuando se usan las tareas de forma paralela.
             * 
             * Se puede reemplazar el método con una expresión lambda pasando el parámetro entero
             * necesario como un parámetro de inicio (antes de '=>').
             * 
             */



            int N = 100;


            //Método ejecutado por un solo hilo (no concurrente)
            //for (int i = 0; i < N; i++) Method2(i);


            //Si quisieramos hacerlo de forma concurrente sin usar Parallel, deberiamos crear
            // muchos Task lo que implica generar demasiado código, pero la clase Parallel simplifica el trabajo

            //(inicio_bucle, final_bucle, método a ejecutar)
            //De forma concurrente la variable acomulador al final de la ejecución no valdrá -100
            //porque hay varios hilos que ejecutan el método y van almacenando información dentro
            //de la variable.
            Parallel.For(0, N, Method2);


        }



        //Para que el método sea usado por la clase Parallel necesita contener un
        // parámetro de tipo entero.
        static void Method2(int i)
        {

            if (acomulador % 2 == 0)
            {
                acomulador += i;
                Thread.Sleep(100);

            } else
            {
                acomulador -= i;
                Thread.Sleep(100);
            }

            Console.WriteLine("Acomulador: {0} - Hilo: {1} ",
                    acomulador, Thread.CurrentThread.ManagedThreadId);
        }

    }
}