using System;
using System.Text;
namespace C8_Metodos
{
    class Program
    {
        private String variable_global;
        private static int variable_global_static;
        //Metodo Main (static)
        //Recibe un parámetros (Array), lo que se hace con ese arreglo es capturar todos la
        //informacion que enviamos a ese metodo cuando ejecutamos la aplicacion de consola
        //desde la consola del Sistema Operativo (Powershell) start C8_Metodos.exe par1 par2
        //Abrir Powershell desde la ubicacion bin\Debug\net6.0 de la carpeta de tu repositorio
        static void Main(string[] args)
        {
            //Console.WriteLine(args[0]);
            //Como Main es un método estático todos los métodos invocados dentro de él
            //deben ser estáticos
            Metodo_Estatico();
            variable_global_static = 0;
            //Para no necesitar volver estático al método podemos invocarlos con una variable
            //que sea una instancia de la clase principal, y así volverlo un objeto de la clase
            var data = new Program(); //Se instancia la clase
            var name = data.MetodoString();
            var met_con_param = data.metodo_con_parametros("Edad", 21);
            Console.WriteLine(name);
            Console.WriteLine(met_con_param);
            Console.ReadLine();
            String variable_local;
        }

        private void MetodoPrivado()
        { 
            Console.WriteLine("Hola");
        }

        public void MetodoPublico()
        {
            Console.WriteLine("Michael");
        }

        private static void Metodo_Estatico()
        {
            Console.WriteLine("Soy metodo estático");
        }

        private string MetodoString()
        {
            variable_global = ""; //Uso de la variable global
            string valor = "retorno";
            return 52.ToString();
            //return Convert.ToInt16("52");
        }

        private void metodo_sin_parametros()
        {
            //codigo
        }

        private string metodo_con_parametros(string param1, int param2)
        {
            return param1 + " " + param2;
        }



        /* MODIFICADORES DE UN MÉTODO
         * PRIVATE: Solo la clase program tendrá acceso a ese metodo
         * Se usa cuando el metodo no va a ser accedida desde otra clase
         * PUBLIC: Todas las clases tienen acceso a ese metodo
         * 
        */

        /* RETORNO DE DATO
         *Void: No retorna ningún tipo de dato.
         *Para que el metodo retorne un dato se debe sustituir VOID por el tipo de dato
         *y al final del metodo se debe agregar la palabra reservada RETURN donde se debe
         *colocar el valor que se retornará (El tipo de dato debe ser el mismo que se 
         *uso al declarar el método, aunque tambien se puede formatear el dato).
        */

        /* VARIABLES GLOBALES
          * Variable Local: Es una variable que se define dentro de un método y solo se puede usar
          * dentro de ese método.
          * Variable Global: Variable que se declara fuera de los métodos y se puede usar por
          * cualquier método. Es de buena práctica colocar el modificador private a 
          * las variables globales para que no se puedan usar en otras clases.
        */
        //Si creamos un metodo privado solo en esa clase tiene acceso, si creamos public
        //cualquier clase tiene acceso a ese metodo. Si queremos usar una variable global

        /* VARIABLES GLOBALES Y VARIABLES LOCALES */
        //dentro de un método "static", la varaible también debe ser static, sin embargo si se
        //puede usar una variable "static" en un método que no es "static"

    }
}