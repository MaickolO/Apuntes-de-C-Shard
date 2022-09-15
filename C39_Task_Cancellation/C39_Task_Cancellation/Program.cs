namespace C39_Task_Cancellation
{
    internal class Program
    {
        /* CANCELACIÓN  DE LOS TASK */
        /* 
         * Se usarán dos clases para la cancelación: CancellationTokenSource y CancellationToken
         * 
         * CancellationToken        : Propaga la notificación de que las operaciones deben de cancelarse.
         * CancellationTokenSource  : Señala a un objeto de CancellationToken que tiene que cancelarse.
         * 
         * El CancellationTokenSource solo señala cual tarea debe tenerse, mientras que el CancellationToken es el
         * que cancela.
         * 
         */

        private static int acomulador = 0;

        static void Main(string[] args)
        {
            //Instancia un objeto de tipo CanellationTokenSource
            CancellationTokenSource token_source = new CancellationTokenSource(); //token que va a señalar cual se va a cancelar.

            //Instancia un objeto de tipo CancellationTOken que recibe
            //CancellationToken asociado con el objeto source
            //token.Token sirve para señalar cual es el thread que se va a cancelar
            CancellationToken token_cancel = token_source.Token; //Este es el token que va a cancelar

            //Le decimos a la tarea que debe cancelarse, pasandole el token de cancelación
            //como parámetro
            Task.Run(() => Ejemplo_CancellationToken(token_cancel)); //Incrementamos el acomulador en 1 a 1

            /* Hilo Princiap */
            for (int i = 0; i < 100; i++) //Incrementamos el acomulador en 30 a 30 con otro hilo
            { 
                acomulador += 30;

                Thread.Sleep(800);

                if(acomulador >100)
                {
                    //Mediante el TokenCancellationSource le decimos que cancele la ejecución del tasks
                    token_source.Cancel();
                    //Salir del bucle for mediante break
                    break;
                }
            }

            Thread.Sleep(1000);
            Console.WriteLine("Tarea cancelada por que el ac tiene el valor de " + acomulador);

            Console.ReadLine();
        }


        //Recibe un token de cancelación como parámetro
        static void Ejemplo_CancellationToken(CancellationToken token)
        {
            for (int i = 0; i < 100; i++)
            {
                acomulador++;

                int hilo = Thread.CurrentThread.ManagedThreadId;

                Thread.Sleep(1000);

                Console.WriteLine("acomulador: {0} - hilo {1}", acomulador, hilo);

                Console.WriteLine(acomulador);

                //Si se recibe un pedido de cancelación entonces...
                if(token.IsCancellationRequested)
                {
                    //volvemos a 0 el acomulador
                    acomulador = 0;
                    //Detén el método y vuelve al método Main
                    return;
                }

            }
           
        }
    }
}