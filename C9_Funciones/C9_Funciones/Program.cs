using System;
namespace C9_Funciones
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().metodo();
        }

        private void metodo()
        {
            funcion();
            int valor = funcion_retorno();
            int num;
            funcion_estatica();
            /*Los metodos locales se crean como un metodo normal pero sin identificador
             * (private, public, etc) */
            /*aunque esta dentro un metodo, la funcion no puede usar sus variables amenos
             * que se les pasen como parametros */
            //Se usa cunado necesitamos hacer una operación dentro de un método
            /*Si la función es grande es mejor crear un método aparte, pero si el procedimiento es
             * prqueño es mejor crear un metodo local. */
            void funcion()
            {
                num = 2;
                Console.WriteLine("soy una funcion local");
            }
            int funcion_retorno ()
            {
                valor = 1;
                return 20 + 20;
            }
            /* Funcion Estatica */
            static void funcion_estatica()
            {

            }

            /*Expresión lambda en funciones */
            //Se usa cuando la funcion solo tiene una linea de codigo dentro
            static int funcion_lambda(int a, int b) => a + b;
            void mensaje() => Console.WriteLine(funcion_lambda(2,3));
            string nombre;//Los metodos locales pueden inicializar datos como metodos tradicionales
            void funcion_name() => nombre = "Michael"; 



        }
    }
}
