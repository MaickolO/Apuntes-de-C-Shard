using System;

namespace C20_Expresiones_Lambda
    /* Son funciones anónimas.
     * Sirven para ejecutar funciones que no necesitan ser nombradas.
     * Simplifican el código.
     * Se usan para crear delegados sencillos.
     * Se usan en expresiones LINQ query
     * Se usan tambien en muchos otros casos.
     * Sintáxis -> Parámetros => expresión / bloque de sentencia
    */
{
    class Program
    {
        static void Main()
        {

            //EJERCICIO1

            //Uso del delegado
            OpMatematicas operacion2 = new OpMatematicas((num1, num2) => num1 * num2);
            //Misma función pero simplificada
            Func<int, int, int> operacion = (num1, num2) => num1 * num2;

            //En vez de usar el metodo Multiplicacion usa una funcion lambda para simplificar.
            Console.WriteLine("La multiplicacion es: ");
            Console.WriteLine(operacion(4, 5));
            Console.WriteLine("");

            //EJERCICIO2

            //Regresar numeros pares con lambda
            List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> numeros_pares = numeros.FindAll(i => i%2 == 0);
            Console.WriteLine("Los números pares son: ");
            //Imprimir foreach con lambda (Cuando se tiene más de una línea de codigo a
            //la derecha se debe usar entre llaves)
            numeros_pares.ForEach(item => {
                Console.WriteLine("El numero par es: ");
                Console.WriteLine(item);
            });
            Console.WriteLine("");

            //EJERCICIO 3

            Personas P1 = new Personas();
            P1.Name = "Juan";
            P1.Edad = 18;

            Personas P2 = new Personas();
            P2.Name = "Michael";
            P2.Edad = 22;
            
            //Comparar las edades de las personas
            ComparaPersonas comparaEdad2 = (e1, e2) => e1 == e2;
            //Delegado simplificado:
            Func<int,int,bool> comparaEdad = (e1, e2) => e1 == e2;
            Console.WriteLine(comparaEdad(P1.Edad, P2.Edad));
        }

        //Creacion del delegado (ejercicio1)
        public delegate int OpMatematicas(int numero1, int numero2);

        //Creacion del delegado (ejercicio3)
        public delegate bool ComparaPersonas(int edad1, int edad2);


        //Funcion Multiplicacion sustituida en el ejercicio1
        /*
        public static int Multiplicacion(int num1, int num2)
        {
            return num1 * num2;
        }
        */

    }

    class Personas
    {
        private string name;
        private int edad;

        public string Name { get => name; set => name = value; }
        public int Edad { get => edad; set => edad = value; }
    }
}
