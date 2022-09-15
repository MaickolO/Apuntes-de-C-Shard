using System;

namespace C18_Delegados
/*Delegados
 * Funciones que delegan tareas a otras funciones.
 * Similares a apuntadores de C++.
 * Un delegado es una referencia a un método.
 * Sirve para llamar a eventos. (OnClick, OnTouch, etc).
 * Se reduce el codigo al manejar escenarios.
 * Un delegado solo llame a metodos con la misma estructura.
 * (debe tener el mismo  y tipoargumentos que el metodo al que apunta)
 * Sintaxis -> delegate tipo nombreDelegado (argumentos);
 * Se puede hacer referencia aunque las clases esten en ficheros diferentes.
*/

{
    class Program
    {

        //Definicion del objeto delegado
        delegate void ObjetoDelegado();

        delegate void ObjDelegate(String msj);

        static void Main()
        {
            //Creacion del objeto delegado, como argumento se da la clase y metodo al que se apunta
            ObjetoDelegado delegado = new ObjetoDelegado(MensajeBienvenida.SaludoBienvenida);
            
            //Utilizacion del delegado para llamar al metodo al que se apunta.
            delegado();


            //Creacion del segundo objeto para usar el metodo despedida que tiene un param
            ObjDelegate delegado2 = new ObjDelegate(MensajeDespedida.SaludoDespedida);


            //Utilizacion del segundo objeto
            delegado2("Saludo escrito");
            //Usamos otrto metodo para el delegado
            delegado2 = new ObjDelegate(NuevoMensaje.NewMsj);
            delegado2("nuevo_mensaje");

            /* No se puede usar delegado2 con MensajeBienvenida porque no tienen el mismo 
             * número de parámetros, en cambio si se puede usar con la clase NuevoMensaje
             * porque su método NewMsj si tiene el mismo número y tipo de parámetros.
            */
        }
    }

    class MensajeBienvenida
    {
        public static void SaludoBienvenida()
        {
            Console.WriteLine("Hola Mundo");
        }
    }

    class MensajeDespedida
    {
        public static void SaludoDespedida(string msj)
        {
            Console.WriteLine("Mensaje: {0}", msj);
        }
    }

    class NuevoMensaje
    {
        public static void NewMsj(String mens)
        {
            Console.WriteLine(mens);
        }
    }

}