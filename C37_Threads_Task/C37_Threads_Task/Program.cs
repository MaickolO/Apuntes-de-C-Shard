namespace C37_Threads_Task
{
    class Program
    {
        /* Al ejecutar los Threads hay que tener en cuenta los núcleos del procesador
         * ya que si hay más threads que núcleos, los threads restantes se mantendrán a la espera
         */

        /* TASK: Se colocan un nivel por encima de los threads y se encargan de gestionar y
         * optimizar el uso del procesador de tal forma que la task considera el número de threads
         * a usar deacuerdo a la capacidad del procesador.
         */

        /* Tasks se colocan en un nivel de abstracción superior a los threads.
         * Task es algo futuro o una promesa. Un Thread es la herramienta para realizar esa promesa.
         */

        /* Casi siempre que se necesite usar la programación asíncrona es mucho mejor usar un Task que
         * utilizar simplemente un Thread.
         */

        /* Internamente las tasks utilizan un pull de threads, a las cuales
         * gestiona el tamaño de acuerdo a la capacidad del procesador.
         */

        /* Al ejectuar la tarea imprimiendo una cadena simple podemos ver que en vez de crear
         * muchos hilos, solo reutiliza uno para optimizar la memoria.
         * Si creamos otra tarea que ejecuta el mismo método crea otro thread, aveces alterando los threads
         * y otras veces repitiendolas.
         * 
         * 
         */

        static void Main(string[] args)
        {

            //Instancia_y_Ejecucion();


            //ContinueWith();


            Wait();


            Console.ReadLine();
        }

        static void Instancia_y_Ejecucion()
        {
            Task tarea = new Task(Instancia_y_Ejecucion_Metodo1);   //Instanciar un objeto de Task pasando como parámetro el método
            tarea.Start();                          ////Ejecutar la Task

            //Las 2 líneas anteriores  (La instancia y start), usando el método Run, se pueden resumir en:
            Task.Run(() => Instancia_y_Ejecucion_Metodo1());

            // Se pueden entrelazar las tareas utilizando varios métodos Run

        }

        static void ContinueWith()
        {
            Task tarea1 = Task.Run(() => ContinueWith_Metodo1());

            Task tarea2 = tarea1.ContinueWith(ContinueWith_Metodo2);

            /* El método ContinueWith hace que se ejecute tarea2 una vez que se ha terminado
             * de ejecutar tarea1, para lograr esto es necesario que el método que va a contener
             * como parámetro ContinueWith tenga un parámetro de tipo Task.
             */

        }

        static void Wait()
        {
            /* Método WaitAll(), WaitAny() y Wait()
             * Se utilizan cuando se quiere dar prioridad a una tarea con respecto a otra.
             * 
             * 
             */

            /* Hacer que una tarea en concreto se ejecute cuando las otras ya han terminado */

            Task tarea1 = Task.Run(() => Instancia_y_Ejecucion_Metodo1());

            //Obligamos que esta tarea1 este terminada para que comienzen las tareas siguiente.
            Wait();

            Task tarea2 = Task.Run(() => ContinueWith_Metodo1());


            //Con la línea anterior le decimos que tarea3 no comienze a ejecutar hasta que tarea1
            //y tarea2 no hayan terminado. 
            Task.WaitAll(tarea1, tarea2);
            Task tarea3 = Task.Run(() => Instancia_y_Ejecucion_Metodo1());


            /* Continuar con la tarea una vez que ha terminado alguna de las tareas que se pasa
             * como parámetro */
            Task.WaitAny(tarea1, tarea2);
            Task tarea4 = Task.Run(() => Instancia_y_Ejecucion_Metodo1());

            /* SI SE EJECUTAN LOS MÉTODOS Wait, WaitAll y WaiAny a la vez obtendremos un error de ejecución
             * ya que le estamos diciendo al programa que ejecute tarea2 y tarea3 luego de que acabe tarea1;
             * pero luego le decimos a tarea3 que espera a que se terminen de ejecutar tarea1 y tarea2; 
             * y por último mediante WaitAny le decimos que tarea4 espera a que termina tarea1 y tarea2
             */

        }



        /* MÉTODOS USADOS*/

        static void Instancia_y_Ejecucion_Metodo1()
        {
            for (int i = 0; i < 5; i++)
            {
                //Obtenemos el ID del thread
                var thread = Thread.CurrentThread.ManagedThreadId;
                //El método Sleep hace que la tarea no se ejecute durante el tiempo asignado en ms.
                Thread.Sleep(500);

                Console.WriteLine("tarea 1: Esta vuelta del bucle corresponde al Thread {0}", thread);
            }

        }

        static void ContinueWith_Metodo1()
        {
            for (int i = 0; i < 5; i++)
            {
                var thread = Thread.CurrentThread.ManagedThreadId;
                Thread.Sleep(200);
                Console.WriteLine("Otra tarea 2 - bucle del Thread {0}", thread);
            }
        }

        //Recibe un objeto de tipo task para que pueda informar a tarea2 que ya se 
        //ha terminado de ejecutar tarea1. (Task_Consecutivos)
        static void ContinueWith_Metodo2(Task tarea)
        {
            for (int i = 0; i < 5; i++)
            {
                var thread = Thread.CurrentThread.ManagedThreadId;
                Thread.Sleep(200);
                Console.WriteLine("tarea 3 - Thread {0}", thread);
            }
        }

    }
}