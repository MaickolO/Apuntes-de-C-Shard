using System;
using System.Collections.Generic;

namespace C19_Delegados_Predicados
/* Delegados Predicados
* Son funciones que solo devuelven true o false (bool).
* Sirven para filtrar elementos.
* Sintáxis -> Predicate<T> NombrePredicado = new Predicate<T> (funcionDelegado);
*/
{
    class Program
    {
        static void Main()
        {
            List<int> lista = new List<int>();
            //Metemos dentro de la lista un array con valores
            lista.AddRange(new int[] {1,2,3,4,5,6,7,8,9,10});

            //Declaramos delegado predicado que apunta al método DamePares
            Predicate<int> predicate = new Predicate<int>(DamePares);

            //Usamos el predicado en el método FindAll de la lista num_pares.
            List<int> num_pares = lista.FindAll(predicate);

            //Imprimimos la nueva lista
            foreach (var item in num_pares)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");



            //SEGUNDO EJEMPLO (Delegado Predicado con Objetos)
            List<Personas> gente = new List<Personas>();

            Personas P1 = new Personas();
            P1.Name = "Juan";
            P1.Edad = 18;

            Personas P2 = new Personas();
            P2.Name = "Michael";
            P2.Edad = 22;

            Personas P3 = new Personas();
            P3.Name = "Lorena";
            P3.Edad = 24;

            gente.AddRange(new Personas[] { P1, P2, P3 });
            Predicate<Personas> predicate2 = new Predicate<Personas>(FiltrarJuan);
            //Determinar si existe una persona con name "Juan"
            var existe = gente.Exists(predicate2);
            if (existe)  Console.WriteLine("Existe alguien llamado Juan");
            else Console.WriteLine("No existe alguien llamado Juan");
        }

        static bool DamePares(int num)
        {
            if (num % 2 == 0) return true;
            else return false;
        }


        static bool FiltrarJuan(Personas persona) {
            if (persona.Name == "Juan") return true;
            else return false;
        }
    }

    class Personas
    {
        private string name;
        private int edad;

        public string Name { get => name; set => name = value; }
        public int Edad { get => edad; set => edad = value; }
    }

    //Ejercicio hacer un delegado predicado con un método que te devuelvan los primos.
}