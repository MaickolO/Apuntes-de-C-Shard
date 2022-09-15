namespace C35_Thread_TaskCompletionSource
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Instanciamos un objeto de TaskCompletionSource
            TaskCompletionSource<bool> tcs1 = new TaskCompletionSource<bool>();

            var hilo1 = new Thread(() => 
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Un hilo1");
                    Thread.Sleep(1000);
                }

                //TrySetResult: Da por terminado la tarea de ese hilo
                tcs1.TrySetResult(true);

            });
            
            var hilo2 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Un hilo2");
                    Thread.Sleep(1000);
                    tcs1.TrySetResult(true);
                }
            });

            var hilo3 = new Thread(() =>
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("Un hilo3");
                    Thread.Sleep(1000);
                }
            });


            hilo1.Start();
            //Luego de correr el hilo1 debemos preguntar si se ha terminado de ejecutar el thread
            //En caso de que se haya completado la tarea nos devolvera true, si no se ha completado
            //devolvera false.
            //Dependiendo del lugar donde se encuentre la variable resultado se va a ordenar
            //las tareas.
            bool resultado = tcs1.Task.Result;

            //Si se ha completado el hilo1 entonces comenzaremos a ejecutar el hilo2
            hilo2.Start();

            
            hilo3.Start();
        }
    }
}
