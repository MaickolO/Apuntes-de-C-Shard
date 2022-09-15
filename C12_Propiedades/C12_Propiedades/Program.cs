using System;
namespace C12_Propiedades
{
    class Program
    {
        static void Main()
        {
            var data = new Estudiante(); //Instanciamos la clase Estudiante en el objeto data
            var nombre = data.Nombre; //Obtenemos la informacion guardada en nombre

            /*ONLY SET */
            //var only_set = data.only_set; //No se puede porque no tiene get

            var s1 = new Estudiante()
            { //Inicializamos las propiedades de la clase estudiante
                Nombre = "Michael",
                Edad = 21,
                Calificacion = 15.5
            };
            var s2 = new Estudiante()
            { //Inicializamos las propiedades de la clase estudiante
                Nombre = "Alex",
                Edad = 33,
                Calificacion = 12.2
            };
            var s3 = new Estudiante()
            { //Inicializamos las propiedades de la clase estudiante
                Nombre = "Joel",
                Edad = 16,
                Calificacion = 7
            };
            /* La informacion creada se la proporcionamos a los métodos de la clase school */
            var school = new School();
            //Agregamos los objetos a la lista en la clase school
            school.addEstudiante(s1);
            school.addEstudiante(s2);
            school.addEstudiante(s3);

            bool valor = false;

            do
            { 
                Console.WriteLine("Ingrese el nombre: ");
                String name = Console.ReadLine();
                valor = school.buscarPorNombre(name); //El dato retornado por el metodo se almacena en valor
                //Si no se encuentra el estudiante te retorna el valor de falso y si lo encuentra te retorna true
                //Si es true se vuelve a ejecutar el do-while
            } while (valor);

            Console.ReadLine();
        }
    }
}
