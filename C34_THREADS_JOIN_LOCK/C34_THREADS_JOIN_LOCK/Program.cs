namespace C34_THREADS_JOIN_LOCK
{
    class Program
    {
        static void Main(string[] args)
        {

            CuentaBancaria cuenta = new CuentaBancaria(2000);

            Thread[] hilos = new Thread[15];

            for (int i = 0; i < 15; i++)
            {
                //Pasamos el método para disminuir dinero de la cuenta en cada hilo
                Thread tr = new Thread(cuenta.CantidadRetirar);
                //Le damos un nombre al Thread para identificarlo
                tr.Name = i.ToString();
                //Agregamos los hilos al array
                hilos[i] = tr;
            }

            //Corremos los hilos para sacar dinero de la cuenta
            for (int i = 0; i < 15; i++)
            {
                hilos[i].Start();
                hilos[i].Join();
            }
            
            /* Si se ejecuta de esta forma tendremos errores debido a que todos los threads
             * al retirar dinero al mismo tiempo no se ejecuta la resta del dinero retirado
             * en la cuenta 
             */

            /* Posteriormente si se ejecuta lock() ya no se podrá sacar dinero aunque ya esté
             * en negativo porque se bloquea, sin embargo el orden de llegada de los hilos sigue
             * siendo aleatorio.
             */

            /* Para obtener el bloqueo de dinero cuando llegue a 0 y ordenar los hilos es necesario
             * hacer join() y lock() a los hilos.
             */

        }
    }



    class CuentaBancaria
    {
        private Object SaldoBloqueado = new object();

        double Saldo { set; get; }

        public CuentaBancaria(double Saldo)
        {
            this.Saldo = Saldo;
        }

        public double RetirarEfectivo(double cantidad)
        {
            if ((Saldo - cantidad) < 0)
            {
                Console.WriteLine($"Lo siento queda {Saldo} soles en la cuenta. " +
                    $"hilo: {Thread.CurrentThread.Name}");

                return Saldo;
            }

            //Bloquear el codigo cuando accede un thread
            lock(SaldoBloqueado)
            {
                if (Saldo > 0)
                {
                    Console.WriteLine("Retirado {0} y queda {1} en la cuenta: {2}",
                        cantidad, (Saldo-cantidad), Thread.CurrentThread.Name);
                    Saldo -= cantidad;
                }

                return Saldo;
            }
            
        }

        public void CantidadRetirar()
        {
            Console.WriteLine("Esta sacando dinero el hilo: " + Thread.CurrentThread.Name);
            RetirarEfectivo(500);
        }
    }
}