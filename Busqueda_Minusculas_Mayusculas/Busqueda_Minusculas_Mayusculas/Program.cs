using System;
namespace Busqueda_Minusculas_Mayusculas
{
    class Program
    {
        private String cadena;
        private String verMayusculas = "";
        private String verMinusculas = "";
        private int n;
        private string[] Mayusculas;
        private string[] Minusculas;
        private string[] tempMy;
        private string[] tempMn;
        
        //Metodo Constructor
        //Sirve para inicializar objetos o pasar información
        //Se ejecuta automáticamente cada vez que invocamos la instancia de la clase.
        //El metodo constructor siempre tiene que tener el modificador publico
        public Program (String cadena)
        {
            this.cadena = cadena; //Cuando usamos this nos referimos a la case actual (Program)
            n = cadena.Length; //n toma el valor del número de caracteres de cadena
            Mayusculas = new string[n]; 
            Minusculas = new string[n];
            tempMy = new string[n];
            tempMn = new string[n];
        }

        //Retorna un dato de tipo String, busca los caracteres en mayúscula de
        //la cadena de texto proporcionada.
        private String mayusculas()
        {
            for(int i=0; i<n; i++)
            {
                //Si encuentra una mayuscula dentro de "cadena" se cumple la condicion
                if (char.IsUpper(cadena[i]))
                { //Almacenamos el caracter encontrado de cadena y lo almacenamos en tempMy
                    tempMy[i] = Convert.ToString(cadena[i]);
                }
            }//Recorremos todos los datos del array tempMy
            for(int i=0; i<tempMy.Length; i++)
            {//Si el dato que esta en tempMy no es nulo entonces..
                if (tempMy[i] != null)
                {//Almacenamos el dato de tempMy en Mayusculas y lo concadenamos con
                 //la varaible verMayusculas 
                    Mayusculas[i] = tempMy[i];
                    verMayusculas = $"{verMayusculas},{Mayusculas[i]}";
                }
            }
            return verMayusculas;
        }
        //Retorna un dato de tipo String, busca los caracteres en minúscula de
        //la cadena de texto proporcionada.
        public String minusculas()
        {
            for (int i = 0; i < n; i++)
            {
                //Si encuentra un caracter minuscula dentro de "cadena" se cumple la condicion
                if (char.IsLower(cadena[i])) 
                { //Almacenamos el caracter encontrado de cadena y lo almacenamos en tempMn
                    tempMn[i] = Convert.ToString(cadena[i]);
                }
            }//Recorremos todos los datos del array tempMn
            for (int i = 0; i < tempMn.Length; i++)
            {//Si el dato que esta en tempMn no es nulo entonces..
                if (tempMn[i] != null)
                {//Almacenamos el dato de tempMy en Minusculas y lo concadenamos con
                 //la varaible verMinusculas
                    Minusculas[i] = tempMn[i];
                    verMinusculas = $"{verMinusculas},{Minusculas[i]}";
                }
            }
            return verMinusculas;
        }

        //Metodo Principal
        static void Main()
        {
            var cadena = Console.ReadLine();
            var data = new Program(cadena);
            Console.WriteLine("Las letras mayúsculas son: " + data.mayusculas()
                + "\n\n" + "Las letras minusculas son: " + data.minusculas());
            Console.ReadLine();
        }
    }
}