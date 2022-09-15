using System;
namespace C8_1_Metodos_Constructores
{
    class Program
    {
        //Metodo Constrcutor
        public Program() {

        }

        //Metodo Constructor Sobrecargado:
        //La sobrecarga de metodos constructores deben hacer funciones distintas
        //En la sobrecarga necesita obtener parámetros
        //Puede haber muchos métodos constructores pero deben tener distintos parámetros
        //Si se cambia el orden de los parámetros se puede tener varios
        //métodos constructores con los mismos parámetros
        public Program(String name)
        {

        }

        public Program(String name1, int num1)
        {

        }

        public Program(int num1, String name1)
        {

        }

        static void Main()
        {
            //Se usa el método constructor anteriormente inicializado
            //El metodo constructor tiene el mismo nombre que la clase principal
            Program data = new Program();
            new Program("Michael", 1);
            new Program(1, "Michael");
            Console.ReadLine();


            /* ---Parametros---- */
            //Metodo con muchos parametros
            new Program().metodo_muchos_param("Michael", 25, true);
            //Metodo con pocos parametros
            //Podemos crear un array de tipo Object para almacenar cualquier tipo de dato
            //Si solo necesitamos un tipo de dato podemos crear el array con ese tipo de dato

            Object[] parametros = {"Michael", 25, true};
            new Program().metodo_pocos_param(parametros);

            /* PALABRAS CLAVES EN PARAMETROS */
            //Params
            new Program().metodo_params("Michael", 25, true);
           
            //in
            int edad = 30;
            new Program().metodo_in(edad);

            //ref
            new Program().metodo_ref(ref edad);
            Console.WriteLine(edad); //70
            Console.ReadLine();

            //out
            int num4;
            new Program().metodo_out(out num4);
            Console.WriteLine(edad); //70
            Console.ReadLine();
        }

        /* PARAMETROS */
        //Metodo si no usamos array para los parametros
        private void metodo_muchos_param(String nombre, int edad, bool estado) {}
        //Metodo si usamos array para los parametros
        private void metodo_pocos_param(object[] parametros)
        {
            //Al obtener los datos se tiene que convertir a su tipo de dato
            string nombre = parametros[0].ToString(); //Obtenemos el dato "Michael"
            int edad = Convert.ToInt16(parametros[1]); //Obtenemos 25
            bool estado = Convert.ToBoolean(parametros[2]); //Obtenemos true
            //Otra forma de convertir
            string nombre2 = (string)parametros[0];
            int edad2 = (int)parametros[1];
            bool estado2 = (bool)parametros[2];
        }

        /* PALABRAS CLAVES EN PARAMETROS */

        /* Palabra clave Params */
        private void metodo_params(params Object[] parametros)
        {
            //Params sirve para almacenar los datos enviados en una
            //colección en el mismo método
            //Podemos pasar una colección de parámetros y podemos obtener esa 
            //información usando un arreglo gracias a la palabra reservada "params"
        }

        /* Palabra clave In */
        private void metodo_in(in int valor)
        {
            //Cuando se usa palabra reservada in no se puede modificar el dato
            //que está almacenado en la variable. por ejemplo si intento
            //valor = 50; me saldría error
            Console.WriteLine(valor.ToString());
        }

        /* Palabra clave Ref */
        private void metodo_ref(ref int valor)
        {
            //Cuando usamos ref hacemos una referencia, paracticamente hacemos una
            //referencia al mismo objeto con nombres diferentes.
            //Todo lo que le asignemos a la variable valor dentro del método es como
            //Si se lo estuvieamos asignando a la variable data.
            //Sin embargo si la variable no está inicializada nos saldrá un error.
            valor = 50 + 20;
        }

        /* Palabra clave out */
        private void metodo_out(out int valor)
        {
            //Es como una combinación de la palabra in y la palabra ref.
            //Es igual a la palabra in porque hace un alias utilizando la palabra valor
            //y la diferencia es que in no permite que le asignemos datos, solo permite 
            //obtener el dato. Lo que si permite out.
            //es similiar a la palabra ref, la diferencia es que la palabra ref no permite
            //hacer referencia cuando no está inicializada, algo que permite la palabra out
            
            //Si no necesitamos inicializar la palabra data conviene usar out.
            
            valor = 50 + 20;
        }


    }
}
