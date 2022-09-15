using System;
namespace C11_Argumentos_ConNombres_Opcionales
{
    class Program
    {
        static void Main()
        {
            Program programa = new Program();
            programa.param_opcional("C#", "Michael", 52); //Cantidad tomara el valor de 52
            programa.param_opcional("C#", "Michael"); //Cantidad va a tomar el valor de 10

            /* PARAMETROS OPCIONALES NOMBREADOS */
            programa.param_nombrados("c#", cantidad: 12);
            programa.param_nombrados(cantidad: 12, curso: "C#", nombre: "Maickol");
            /* PARAMETROS OPCIONALES NOMBRADOS */
            programa.metodo_nulo(null, null);
            Console.ReadLine();
        }
        //Para crear parametros opcionales solo basta en inicializarlo como parametro.
        //Los parametros opcionales deben aparecer despues de todos los aprametros necesarios.
        //Puede haber mas de un parametro opcional pero estos deben ir al final
        /* No es necesario dar el valor del parametro opcional al usarlo ya que va a tomar el
         * valor por defecto */
        //Se usa cuando no decidimos que dato vamos a pasar al utilizar ese parametro
        /* Si volvemos a nombre un parametro opcional, no podremos dar un nuevo valor a cantidad a
         * menos de que demos un valor tambien a nombre, eso es por el orden (se puede realizar con
         * parametros opcionales nombrados). */
        private void param_opcional(String curso, String nombre, int cantidad = 10)
        {

        }

        /* PARAMETROS OPCIONALES NOMBRADOS */
        /* Se usa para dar valor a un parametro opcional pasando sobre otro parametro opcionales
         * al que no se le da un valor. */
        //Al tener todos los parametros nombrados no es necesario colocarlos en orden al usarlos.
        private void param_nombrados(String curso, String nombre = "Michael", int cantidad = 10)
        {

        }

        /* PASAR VALOR NULO A PARAMETROS (?) */
        //El signo '?' me permite pasarle un valor null aunque no lo admita el tipo de dato
        //Sirve cuando no queremos darle un valor al parametro.
        private void metodo_nulo(String? curso, int? cantidad, String nombre = "Joel")
        {
            Console.WriteLine(curso+ " "+cantidad+ " "+ nombre);
        }

        /* READONLY */
        //Las variables con readonly solo se pueden inicializar en un metodo constructor
        /* Se usa cuando ya no se le va a cambiar el valor en la varaible, pero por si algun caso
         * se necesita cambiar se lo cambia en el metodo constructor. */
        readonly int valor = 20;

        public Program()
        {
            int new_valor = valor;
            valor = 10; //Se coloca cuando ya no se va a 
            Console.WriteLine(valor);
            Console.WriteLine(NUM_CONST);
        }

        /* CONST */
        //La variable si o si debe estar inicializada, en readonly no es necesario inicializar
        //Es de buena practica darle un identificador totalmente en mayusculas
        //No se tiene acceso a la variable por medoi del constructor o el nombre de la variable.
        //Tampoco se tiene acceso en el metodo constructor, no se puede inicializar en ninguna parte del codigo.
        //EN NINGUNA OCASION SE LE PUEDE INICIALIZAR a Const, en cambio a ReadOnly se le puede incializar en el constructor
        const int NUM_CONST = 20;
    }
}