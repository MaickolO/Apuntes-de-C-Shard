using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C12_Propiedades
{
    public class School
    {
        //Sirve para crear una colección de objetos de la clase estudiante (edad, nombre, calificacion)
        private List<Estudiante> estudiante;

        //Metodo constructor de la clas
        public School()
        {
            //Inicializamos la propiedad list
            estudiante = new List<Estudiante>();
        }
        
        public void addEstudiante(Estudiante nuevo_estudiante)
        { //Agregamos un objeto de la clase estudiante a la lista
            estudiante.Add(nuevo_estudiante);
        }
        public bool buscarPorNombre(String name)
        {
            bool encontrado = false;
            int i = 0;
            //Count sirve para contar cuantos elementos tiene el objeto
            //Se va a ejectutar mientras encontrado sea falso y el numero de i sea
            //menor a la cantidad de objetos en la lista estudiante
            while (encontrado == false && i < estudiante.Count)
            { //Comparamos si el nombre es el mismo que el ingresado como parametro
                if (estudiante[i].Nombre.Equals(name))
                { //Si lo encontramos cambiamos el valor de encontrado
                    encontrado = true;
                } else
                { //Incrementamos el valor de i para que siga corriendo el while
                    i++;
                }
            }
            if (encontrado == true)
            { //Imprimimos los datos del estudiante encontrado
                Console.WriteLine("Name: " + estudiante[i].Nombre + "\n"
                    + "Edad: " + estudiante[i].Edad + "\n"
                    + "Calificacion: " + estudiante[i].Calificacion);
                return false;
            } else
            {
                Console.WriteLine("No existe el estudiante, intente nuevamente");
                return true;
            }
        }

    }
}
