namespace C36_Tnread_ThreadPool
{
    /* Pool de Threads */
    /* Se usa cuando se necesitan muchos hilos y se usan de manera concurrente.
     * Si hay más tareas que threads dentro de un pool, entonces cuando un thread termina de realizar
     * su tarea, se reutiliza para comenzar a realizar la tarea siguiente.
     * 
     * Su principal función es la reutilización de threads y la optimización de recursos.
     * 
     * 
     */

    internal class Program
    {
        static void Main(string[] args)
        {

            /* EJECUTAR SIN THREADPOOL */
            /*
            for (int i = 0; i < 20; i++)
            {
                Thread t = new Thread(EjecutarTarea);
                t.Start();
            }
            */

            //Establece el máximo número de Threads que se pueden ejecutar
            // (int workerThreads, int completionPortThreads)
            // (Subprocesos de Trabajo, Subprocesos de E/S asincrónicos)
            ThreadPool.SetMaxThreads(5,5);

            //Definir un ThreadPool
            //QueueUserWorkItem necesita un parámetro de tipo Object
            for (int i = 0; i < 20; i++)
            {
                //Un parámetro es el método y el otro es un int

                ThreadPool.QueueUserWorkItem(EjecutarTarea, i);
            }
            

            Console.ReadLine();
        }

        /* Al ejecutar la aplicacion sin un ThreadPool se crean y ejecutan muchos hilos
         * mientras que al ejecutar el ThreadPool se crean pocos hilos que se repiten una vez
         * se termina de ejecutar el anterior.
         * La ejecución con ThreadPool es más lento que sin ThreadPool.*/

        //El parámetro object casteado a entero nos brinda el número de parámetro creado
        //pero para eso se debe agregar un parámetro de tipo int al definir el ThreadPool.
        static void EjecutarTarea(Object StateInfo)
        {

            int nTarea = (int)StateInfo;


            Console.WriteLine("El hilo {0} ha comenzado la tarea n° {1}", 
                Thread.CurrentThread.ManagedThreadId, nTarea);

            Thread.Sleep(1000);

            Console.WriteLine("EL hilo {0} ha terminado la tarea n° {1}",
                Thread.CurrentThread.ManagedThreadId, nTarea);
        }
    }
}