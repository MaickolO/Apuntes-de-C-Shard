using System;
using System.Text.RegularExpressions;

namespace C21_Expresiones_regulares
/* Secuencias de caracteres que funcionan como un patrón de búsqueda.
 * Buscan cadenas de caracteres: letras, números, otros símbolos,...
 * Se usa en validación de formularios, búsqueda de ficheros externos,
 *   búsquedas en BBDD, etc.
 * Clases Útiles: Regex, Match, MatchCollection, GroupCollection.
 * Metodos Útiles: Matches.
 * Propiedades Útiles: Groups.
 * 
 * 
 * Se pueden establecer grupos con pareéntesis -> "()?"
 * Si no se establecen grupos tomára el caracter anterior a la expresion regular -> abc = ab(c)?
 * 
 * 
 * Se pueden usar expresiones regulares en la búsqueda rápida (Ctrl + F) de Visual Studio
 * Activando la opcion de usar expresiones regulares (ALT + E)
 * 
 * 
 * Puedes buscar por la web generadores de expresiones regulares virtuales:
 * ejemplo -> https://regex-generator.olafneumann.org/
 * pero ten cuidado que pueden tener errores
*/
{
    class Program
    {
        static void Main()
        {
            /* ALGUNAS EXPRESIONES REGULARES */
            //"\d{3}" -> busca si hay bloques de 3 valores numéricos

            String frase = "Mi nombre es Michael y mi n° de tfno es (+35)998-110-921 y mi codigo postal es 23423";

            /* BUSCAR CARACTER EN LA FRASE */

            //Expresion Regular que sirve para buscar la M mayúscula
            String patron = "[M]";

            //Se usa la clase Regex
            Regex regex = new Regex(patron);

            //Se usa el méodo Matches de la clase Regex para saber
            //si existe coincidencias entre el patron y la frase
            MatchCollection matchCollection = regex.Matches(frase);

            //Si hay almenos una coincide se imprime "Se ha encontrado M"
            if (matchCollection.Count > 0) Console.WriteLine("Se ha encontrado M");
            else Console.WriteLine("No se ha encontrado M");
            Console.WriteLine("");


            /* BUSCAR NUMERO EN LA FRASE */

            //Para usar caracteres de escape (\) dentro de un string necesitas @
            //Esta expresion regular sirve para buscar números
            String patron2 = @"\d";
            Regex regex2 = new Regex(patron2);
            MatchCollection matchCollection2 = regex2.Matches(frase);
            if(matchCollection.Count > 0) Console.WriteLine("Se ha encontrado un número");
            else Console.WriteLine("No se ha encontrado un número");



            /* BUSCAR CADENAS DE NUMEROS EN LA FRASE */
            // "{3}" nos dice el número de caracteres que tendrá la cadena, tambien
            // se puede usar \d\d\d para el mismo propósito.
            String patron3 = @"\d{3}";


            /* OBTENER TODO EL NÚMERO TELEFÓNICO DE LA CADENA */
            //Con este patron puedes obtener 998-110-921
            String patron4 = @"\d{3}-\d{3}-\d{3}";

            /* OBTENER EL PREFIJO DEL NÚMERO DE TELÉFONO */
            //Con este patron puedes obtener +35
            String patron5 = @"\+35";

            /* SIMBOLOS UTILES EN EXPRESIONES REGULARES
             * | -> sirve como "o"  
             * @"\+35|\+32" -> SI se quiere incluir ambos numeros en la bsuqueda
             * 
             * Cuantificadores -> *, +, ?, {N}, 
             * ? -> Coincide con el elemento anterior cero o una vez
             * https://(www.)?michael.com.pe -> Solo verifica si se encuentra www. cero o una vez.
             * 
            */

        }
    }
}
