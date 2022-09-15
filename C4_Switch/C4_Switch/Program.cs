using System;
namespace C4_Switch
{
    class Program
    {
        static void Main(string[] args)
        {
            var dato = 4;
            switch (dato)
            {
                case 4:
                case 5:
                    Console.WriteLine("EL numero ingresado es {0}", dato);
                    break;
                default:
                    Console.WriteLine("El numero ingresado no es el ingresado.");
                    break;
            }

            /* Switch de Expresión */
            //Disponible desde la versión de C# 8
            //Se usa cuando se necesita que el switch devuelva un valor o una variable.
            var data = 10;
            var result = data switch
            {
                1 => "Alex",
                2 => "Joel",
                3 => "PDHN",
                _ => "hola"
            };
            Console.WriteLine(result);
            Console.ReadLine();

            //Otro ejemplo de switchs de expresión
            var (a, b, opcion) = (2, 6, "*");
            var rpta = opcion switch
            {
                "+" => a + b,
                "-" => a - b,
                "*" => a * b,
            };
            Console.WriteLine(rpta);
            Console.ReadLine();

        }
    }
}
