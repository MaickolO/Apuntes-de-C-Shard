using System;

class Program
{
    static void Main(string[] args)
    {
        /* BUCLE FOR */
        for(int i = 0; i< 10; i++)
        {
            Console.WriteLine("La posicion actual es: "+i);
        }
        string[] nombres = { "Michel", "Orlando", "Orizano", "Zevallos" };

        for(int i = 0; i< nombres.Length; i++)
        {
            Console.WriteLine("El nombre en la posicion {0} es {1}", i, nombres[i]);
        }

        foreach(var item in nombres) //El foreach va a recorrer segun el número de elementos en el array
        {
            Console.WriteLine(item);
        }
        Console.ReadLine();
        //Si se quieren usar las posiciones podemos usar el for pero si se quieren y obtener los valores
        //Se puede usar el foreach

    }

}