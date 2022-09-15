using System;

class Program
{
    static void Main(string[] args)
    {
        /* CONDICIONALES */
        int valor1 = 9;
        int valor2 = 9;
        double valor3 = 10.1;
        double valor4 = 10.2;
        var data = valor1 == valor2;

        if(valor1 > valor2)
        {
            Console.WriteLine("{0} es mayor que {1}", valor1, valor2);
        } else if (valor3>valor4)
        {
            Console.WriteLine("{0} es mayor que {1}", valor3, valor4);
        } else
        {
            Console.WriteLine("No se cumplen las condiciones anteriores");
        }
        Console.ReadLine();

        //Simplificando un IF / Else:

        var condicion = valor1 > valor2;

        String nombre = condicion ? "Alex" : "Joan";
        Console.WriteLine("El nombre es {0}", nombre);
        Console.ReadLine();
        

        /* ARREGLOS */
        String[] cadena = new string[5];
        cadena[0] = "Michael";
        cadena[1] = "Orlando";
        cadena[2] = "Ernesto";
        cadena[3] = "Joan";
        cadena[4] = "Max";

        decimal tamano_array = cadena.Length;
        string primer_nombre = cadena[0];

        //Sirve cuado no se deben asignar datos adicionales al array ya que
        //luego de declarlos no se pueden aumentar su tamaño.
        String[] apellidos = {"Orizano", "Zevallos", "Principe", "Hassinger", "Casas"};
        
        //Los arrays se pueden crear en cualquier tipo de dato.
        int[] numeros = {1,2,3,4,5};
        bool[] estado = {false, true, false};
        numeros[0] = 100;

        Console.WriteLine("El array tiene {0} elementos que son: {1}, {2}, {3}, " +
            "{4}, {5}",tamano_array, primer_nombre, numeros[0], cadena[2],
            cadena[3], cadena[4]);


        Console.ReadLine();

        /* ARREGLOS MULTIDIMENSIONALES */
        //Arrelo Bidimensional
        double[,] bidimensional = new double[2,3] { {6,3.0,8}, {6.3,5.6,1} };
        string num1 = bidimensional[0, 0] + "hola";

        Console.WriteLine("El segundo numero de la primera fila es {0}", num1);
        Console.ReadLine();
        //Arreglo Tridimensional
        int[,,] tridimensional = new int[3, 2, 3]
        {   { {1,2,3},{4,5,6} },  { {7,8,9 },{10,11,12} },{ {13,14,15},{16,17,18} } } ;

        int tamaño_tercera_pos = tridimensional.GetLength(2);
        int num_dimensiones = tridimensional.Rank;

        Console.WriteLine("El número de dimensiones es {0} y la  posicion a tiene " +
            "un tamaño de {1}", num_dimensiones, tamaño_tercera_pos);
        Console.ReadLine();

    }
}