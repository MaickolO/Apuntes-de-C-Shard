using System;
class Program
{
    static void Main(String[] args)
    {
        int pisos = 0;
        int[] arreglo = new int[1];
        //Pedimos un dato a la consola
        Console.WriteLine("Ingrese el números de pisos");
        //El dato ingresado en la consola por defecto es de tipo string
        //Por eso se convierte a int (Int16 porque es un numero pequeño)
        pisos = Convert.ToInt16(Console.ReadLine());
        //Ciclo for que recorre dependiendo del numero de pisos ingresado
        //En la variable pisos.
        for (int i = 1; i <= pisos; i++)
        {
            //Arreglo que tendrá el tamaño del valor de la variable i
            int[] pascal = new int[i];

            //Ciclo que se decrementa para dar la forma de triángulo
            for (int j = pisos; j > i; j--)
            {
                Console.Write(" ");
            }

            //Ciclo que genera la suma de las cifras
            for (int k = 0; k < i; k++)
            {
                //Condicion que evalua la variable del ciclo for
                if (k == 0 || k == (i - 1))
                {
                    //Agregar 1 al inicio o al final
                    pascal[k] = 1;
                } else
                {
                    //Agregar la parte del medio
                    pascal[k] = arreglo[k] + arreglo[k - 1];
                }
                //Escribir los números
                Console.Write("[" + pascal[k] + "]");
            }
            //Guardar la información del bucle anterior
            arreglo = pascal;
            //Ejecutar el salto de línea
            Console.WriteLine("");
        }
        Console.ReadLine();
    }
}