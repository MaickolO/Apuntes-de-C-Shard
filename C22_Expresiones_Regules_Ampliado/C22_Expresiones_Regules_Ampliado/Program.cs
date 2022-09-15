using System.Collections;
using System.Text.RegularExpressions;

namespace C22_Expresiones_Regules_Ampliado
{
    /* Expresiones Regules */

    /* Las expresiones regulares proporcionan un método eficaz y flexible para procesar texto.
     * 
     * Las expresiones regulares permiten:
     *      Buscar patrones concretos de caracteres.
     *      Validar el texto para garantizar que coincida con un patrón definido (como un número telefónico).
     *      Extraer, editar, reemplazar o eliminar subcadenas de texto
     *      Agregar cadenas extraidas en una colección para generar un informe.
     *      
     *      using System.Text.RegularExpressións;
     *      
     *      
     * Las expresiones regulares se pueden representar por un automata finito.
     * 
     * AUTÓMATA FINITO
     * Es un modelo computacional que tiene una entrada de datos y una salida.
     * 
     * El automata finito tiene varios estados a los que cambia mediente transiciones.
     * 
     * Estado inicial: Entrada de datos. Para pasar a S2 debemos hacerlo mediente 
     * un alfabto (a,b,c). 
     * 
     * Se cambia de estado mediante el alfabeto que se entrega, en el estado 
     * final se forma un bucle.
     * 
     * TODA EXPRESIÓN REGULAR TIENE UN ESTADO DE UN AUTOMATA FINITO.
     * 
     * 
     * 
     */

    class Program
    {

        static void Main(string[] args)
        {
            //Representa una expresión regular inmutable;
            ClaseRegex();

            //Tipos de Expresiones Regulares
            //Delimitadores_o_Aserciones();

        }

        static void ClaseRegex()
        {
            Console.WriteLine("Clase Regex: ");
            Console.WriteLine("");
            /* La clase regex representa una expresión regular inmutable;
             * System.Text.RegularExpressions;
             * 
             * Se usa para analizar rápidamente grandes cantidades de texto, para encontrar
             * patrones de caracteres específicos, editar, reemplar o eliminar subcadenas de texto
             * y para agregar cadenas extraidas a una colección para generar un informe.
             * 
             */

            /* Métodos importantes de REGEX: */

            /* VALIDACIÓN DE UNA COINCIDENCIA */
            Console.WriteLine("***** Validación de una sola coincidencia *****");
            ClaseRegex_IsMatch();
            Console.WriteLine("");
            Console.WriteLine("");

            /* RECUPERACIÓN DE UNA SOLA COINCIDENCIA */
            Console.WriteLine("***** Recuperación de una sola coincidencia *****");
            ClaseRegex_Match();
            Console.WriteLine("");
            Console.WriteLine("");

            /* RECUPERACIÓN DE TODAS LAS COINCIDENCIAS */
            Console.WriteLine("***** Recuperación de todas las coincidencia *****");
            ClaseRegex_Matches();
            Console.WriteLine("");
            Console.WriteLine("");

            /* REEMPLAZAR COINCIDENCIAS */
            Console.WriteLine("***** Reemplazo del texto coincidente *****");
            ClaseRegex_Replace();
            Console.WriteLine("");
            Console.WriteLine("");

            /* CREACIÓN DE MATRIZ DE CADENAS FORMADA POR PARTES DE OTRA CADENA */
            Console.WriteLine("***** Creación de una matriz de cadenas con partes de otra cadena *****");
            ClaseRegex_Split();
            Console.WriteLine("");
            Console.WriteLine("");

        }

        static void ClaseRegex_IsMatch()
        {
            /* Devuelve TRUE si la expresión regular encuentra una coincidencia, caso contrario, false */

            //Expresion Regular
            String patron = @"^[A-Z0-9]\d{2}[A-Z0-9](-\d{3}){2}[A-Z0-9]$";
            /* PATRON       : EXPLICACION                                                       POSICION DE CARACTER
             * ^            : Comienzo de la cadena.                                            INICIO
             * [A-Z0-9]     : Caracter alfabético de A a Z o número de 0 a 9.                   (1° caracter)
             * \d{2}        : 2 caracteres numéricos.                                           (2° y 3° caracter)
             * [A-Z0-9]     : Caracter alfabético de A a Z o número de 0 a 9.                   (4° caracter)
             * (-\d{3}){2}  : Un guión seguido de 3 caracteres numéricos. Se repite 2 veces.    (del 5° al 12° caracter)
             * [A-Z0-9]     : Caracter alfabético de A a Z o número de 0 a 9.                   (13° caracter)
             * $            : Final de la cadena                                                FINAL
             */

            //Texto donde se encontrará la coincidencia
            string[] texto = {
                "1298-673-4192",        //Cumple.
                "A08Z-931-468a",        //Cumple.
                "_A90-123-129X",        //No cumple porque el primer caracter no es un número o caracter alfabetico.
                "12345-KKA-1230",       //No cumple porque el quinto caracter no es un guión
                "0919-2893-1256" };     //No cumple porque el noveno caracter no es un guión

           
            /* PRIMERA SOBRECARGA (4 parámetros)*/
            /* IsMatch(string input, string pattern, RegexOptions options, TimeSpan matchTimeout);    */
            /* Parámetros:
             * input            : Texto a comparar.
             * pattern          : Patrón de expresión regular.
             * options          : Proporciona opciones de coincidencias.
             * matchTimeout     : Intervalo de tiempo de espera para encontrar la coincidencia.
             */
            foreach (var item in texto)
            {

                try
                {
                    Console.WriteLine("{0} {1} una cadena válida", item, Regex.IsMatch(item, patron,
                    //IgnoreCase    :   Ignora mayúsuculas y minúsculas
                    //Usar IgnoreCase es equivalente a (a-z) en cada caracter alfabetico
                    RegexOptions.IgnoreCase,
                    /* Establecemos 0.5 segundos de espera para que encuentre la coincidencia */
                    TimeSpan.FromMilliseconds(500))
                    //Si encuentra una coincidencia dara un "es" y si no la encuentra dará "no es"
                    ? "es" : "no es");
                }
                catch (RegexMatchTimeoutException e)
                { //Si no encuentra coincidencia en el tiempo que dice el TimeSpan se va a ejecutar el catch.
                    Console.WriteLine("No se encontró la coincidencia en el tiempo establecido.");
                }
            }


            /* SEGUNDA SOBRECARGA (3 parámetros) */
            //IsMatch(String input, String pattern, RegexOptions options)
            /* Parámetros:
             * input            : Texto a comparar.
             * pattern          : Patrón de expresión regular.
             * options          : Proporciona opciones de coincidencias.
             */
            //Para ejemplo ver el de la sobrecarga sin TimeSpan.FromMilliseconds(500));
            
            /*Ejemplo
            foreach (var item in texto)
            {
                Console.WriteLine("{0} {1} un número válido", item, 
                    Regex.IsMatch(item, patron, RegexOptions.IgnoreCase) ? "es" : "no es");
            }
            */


            /* TERCERA SOBRECARGA (2 parámetros) */
            //IsMatch(String input, String pattern)
            /* Parámetros:
             * input            : Texto a comparar.
             * pattern          : Patrón de expresión regular.
             */
            //Para ejemplo ver el de la sobrecarga sin  RegexOptions.IgnoreCase y TimeSpan.FromMilliseconds(500));
            
            /*Ejemplo
            foreach (var item in texto)
            {
                Console.WriteLine("{0} {1} un número válido", item, Regex.IsMatch(item, patron) 
                    ? "es" : "no es");
            }
            */


            /* CUARTA SOBRECARGA (1 parámetro) */

            //IsMatch(String input)
            /* Parámetro:
             * input            : Texto a comparar.
             */
            /* En esta sobrecarga en lugar de usar la clase Regex, se usa una instancia de la clase para
             * realizar la validación, al instanciar la clase se da el patrón como parámetro.   */

            //Instancia de un objeto Regex con la expresión regular que representa como parámetro.
            Regex regex = new Regex(patron);

            /* EJEMPLO
            foreach (var item in texto)
            {
                Console.WriteLine("{0} {1} un número válido", item, regex.IsMatch(item) ? "es" : "no es");
            }
            */
        }

        static void ClaseRegex_Match()
        {
            /* Busca en una cadena una subcadena que coincida con un patrón de expresión
             * regular y devuelve la primera aparición como un único objeto Match.
             * 
             * Devuelve la primera subcadena (como un objeto Match) que coincide con 
             * un patrón de expresión regular en una cadena de entrada.
             * 
             */

            /* PRIMERA SOBRECARGA (4 parámetros) -> 
             *  Para ver el uso de los parámetros ver el método ClaseRegex_IsMatch() */
            /* Match(String input, String pattern, RegexOptions options, TimeSpan matchTimeout) */
            /* Parámetros:
             * input            : Texto a comparar.
             * pattern          : Patrón de expresión regular.
             * options          : Proporciona opciones de coincidencias.
             * matchTimeout     : Intervalo de tiempo de espera para encontrar la coincidencia.
             */


            /* SEGUNDA SOBRECARGA (1 parámetro) */
            /* Match(String input) */
            /* Parámetros:
             * input            : Texto a comparar.
             */

            /* Texto dnde se buscará coincidencias */
            string texto = "Un carro rojo carro verde carro"; //(1-3)4(5-7)8(9-11)12(13-15)16(17-20)21(22-24)
            
            /* Patrón de expresión regular */
            string patron = @"(\w+)\s+(carro)";
            /* PATRON       : EXPLICACION                                               Grupo de captura
             * (\w+)        : Busca coincidencia con uno o más caracteres alfabéticos   (1° grupo de captura)
             * \s+          : Coincide con uno o varios caracteres de espacio vacios    
             * (carro)        : Coincide con la cadena literal "carro".                     (2° grupo de captura)
             */
            
            //Se instancia un objeto de clase Regex (patron, option)
            Regex regex = new Regex(patron, RegexOptions.IgnoreCase);
            //Devuelve un objeto que contiene la información acerca del Match
            //Guarda la primera coincidencia que encuentra en la cadena
            //(para pasar a la sgte coincidencia se usa el método match.NextMatch();)
            Match match = regex.Match(texto);
            int matchCount = 0; //Contador de las coincidencias en la cadena (matchs)
            while (match.Success) //Mientras se encuentre una coincidencia (match.Success) realiza...
            {   //Imprime el número de coincidencia en la que se encuentra
                Console.WriteLine("Match " + (++matchCount));
                for (int i = 1; i <= 2; i++) //Bucle para recorrer los grupos de la coincidencia
                {   
                    //Group: Representa el resultado de un grupo de captura
                    //Los paréntesis en el patron te especifican los grupos de capturas
                    /* Grupos de la primera coincidencia: One car 
                     * grupo[0] = One car
                     * grupo[1] = One
                     * grupo[2] = car   */
                    Group grupo = match.Groups[i];
                    //Imprime el grupos de captura de la coincidencia y su posición
                    Console.WriteLine("Grupo " + i + " = '" + grupo + "'");
                    //Guarda el grupo de captura en una colecció de capturas
                    //(guarda todas las capturas de la coincidencia actual)
                    CaptureCollection captureC = grupo.Captures;
                    //Recorre la coleccion de capturas
                    for (int j = 0; j < captureC.Count; j++)
                    {
                        //Obtiene la captura y lo guarda en un objeto de la clase Capture
                        Capture capture = captureC[j];
                        // j = Imprime la posición de la captura en la colección de capturas
                        // (Siempre 0 porque se crea CaptureCollection dentro del bucle de grupos)
                        //capture.Index : Posición donde inicia en la cadena "texto"
                        Console.WriteLine("Captura " + j + " = '" + capture + "', Posicion = " + capture.Index);
                        }
                }
                Console.WriteLine("");
                match = match.NextMatch(); //Pasar a la siguiente coincidencia encontrada en la cadena texto
            }

            Console.WriteLine("");
            /* TERCERA SOBRECARGA (2 parámetros) */
            /* Match(String input, int startat) */
            /* Parámetros:
             * input            : Texto a comparar.
             * startat          : Posición del caracter en la que se va a inicar la búsqueda.
             */

            /*STARTAT
             * Si no se especifica una posición, la búsqueda comienza desde la posición predeterminada
             * (extremo izquierdo de input).
             * 
             * Apesar de empezar por startAt, el Index es relativo al inicio de la cadena.
             * 
             * Si un patrón comienza con el ^ delimitador pero startat es mayor que 0, nunca se 
             * encontrará ninguna coincidencia en una búsqueda de una sola línea, ya que están 
             * restringidas por ^ para comenzar en el índice 0.
             * 
             */
            string texto1 = "abc Zip code: 98052";
            string texto2 = "abcd Zip code: 98052";

            string patron2 = @"(Zip code:)\s\d{5}";
            /* PATRON           : EXPLICACION                                               Grupo de captura
             * (Zip code:)      : Busca una coincidencia exacta de los caracteres mostrados (1° al 9° caracter)
             * \s               : Busca un espacio vacío                                    (10° caracter)
             * \d{5}            : Busca un caracter numérico que se repita 5 veces.         (11°-15° caracter)
             */


            var regex2 = new Regex(patron2);

            //Le dices que empieze la búsqueda desde el caracter 5
            Match match1 = regex2.Match(texto1, 5); //No coincide porque Zip code: 98052 comienza en el 4° caracter
            Match match2 = regex2.Match(texto2,5); //Coincide porque Zip code: 98052 comienza en el 5° caracter
           
            if (match1.Success)
            {
                Console.WriteLine("El texto es {0} y la coincidencia es {1}", texto1, match1.Value);
            } else
            {
                Console.WriteLine("No hay match porque la coincidencia no comienza en la quinta línea\n" +
                    "en el texto: {0}", texto1);
            }
                
            if (match2.Success)
                Console.WriteLine("El texto es: {0} y la coincidencia es: {1}", texto2, match2.Value);


            /* CUARTA SOBRECARGA (3 parámetros) */
            /* Match(String input, int begining, int lenght) */
            /* Parámetros:
             * input            : Texto a comparar.
             * begining         : Posición del caracter más a la izquierda en la que se va a inicar la búsqueda.
             * lenght           : Número de caracteres de la subcadena que se van a incluir en la búsqueda
             */
        }

        static void ClaseRegex_Matches()
        {
            /* Busca en una cadena de caracteres todas las apariciones de una expresión 
             * regular y devuelve todas las coincidencias.
             * 
             * Devuelve un MatchCollection, una colección de objetos Match
             * encontrados en la búsqueda. Si no se encuentran coincidencias, el método devuelve
             * un objeto de colección vacía.
             * 
             * Es similar al método Match, solo que devuelve información sobre todas las coincidencias
             * encontradas en la cadena de entrada, en lugar de una sola coincidencia.
             * 
             */

            /* PRIMERA SOBRECARGA (4 parámetros)*/
            /* Matches(String input, String pattern, RegexOptions options, TimeSpan matchTimeout)    */
            /* Parámetros:
             * input            : Texto a comparar.
             * pattern          : Patrón de expresión regular.
             * options          : Proporciona opciones de coincidencias.
             * matchTimeout     : Intervalo de tiempo de espera para encontrar la coincidencia.
             */

            string sentence = "NOTES: Any notes or comments are optional.";

            string pattern = @"\b\w+es\b";
            /* PATRON       : EXPLICACION                                                       POSICION DE CARACTER
             * \b           : Inicia la búsqueda en un límete de palabras.                      INICIO
             * \w+          : Busca coincidencias con uno o más caracteres alfabéticos.         (1° a n° caracteres)
             * es           : Coincide con la cadena literal "es".                              (n+1° y n+2° caracteres)
             * \b           : Finaliza la búsqueda en un límete de palabras.                    FINAL                                           FINAL
             */

            try
            {
                
                foreach (Match match in 
                    //Crea cada match de la colección de coincidencias que se obtiene de Matches
                    Regex.Matches(sentence, pattern, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(500)))
                    //Imprime todas las coincidencias, el valor (texto) y el Index (posición en la cadena).
                    Console.WriteLine("Encontrado '{0}' en la posición {1} del texto: {2}", match.Value, match.Index, sentence);
            }
            catch (RegexMatchTimeoutException) { }

            Console.WriteLine("");
            /* SEGUNDA SOBRECARGA (3 parámetros)*/
            /* Matches(String input, String pattern, RegexOptions options)    */
            /* Parámetros:
             * input            : Texto a comparar.
             * pattern          : Patrón de expresión regular.
             * options          : Proporciona opciones de coincidencias.
             */


            /* TERCERA SOBRECARGA (2 parámetros)*/
            /* Matches(String input, int int32)    */
            /* Parámetros:
             * input            : Texto a comparar.
             * int32            : Posición de carácter de la cadena de entrada en la que se va a iniciar la búsqueda.
             */


            /* CUARTA SOBRECARGA (1 parámetros)*/
            /* Matches(String input)    */
            /* Parámetros:
             * input            : Texto a comparar.
             */

            string patron = @"\b\w+as\b";
            /* PATRON       : EXPLICACION                                                       POSICION DE CARACTER
             * \b           : Inicia la búsqueda en un límete de palabras.                      INICIO
             * \w+          : Busca coincidencias con uno o más caracteres alfabéticos.         (1° a n° caracteres)
             * as           : Coincide con la cadena literal "as".                              (n+1° y n+2° caracteres)
             * \b           : Finaliza la búsqueda en un límete de palabras.                    FINAL                                           FINAL
             */

            Regex rgx = new Regex(patron);
            string oracion = "Quien escribe estas notas?";

            foreach (Match match in rgx.Matches(oracion))
                Console.WriteLine("Encontrado '{0}' en la posición {1} del texto: " +
                    "{2}", match.Value, match.Index, oracion);
        }

        static void ClaseRegex_Replace()
        {
            /* En una cadena de entrada especificada, reemplaza las cadenas que 
             * coinciden con un modelo de expresión regular por una cadena de 
             * reemplazo especificada.
             * 
             * Si no se encuentran coincidencias del patrón de expresión 
             * regular en la instancia actual, el método devuelve la instancia sin modificar.
             * 
             */


            /* PRIMERA SOBRECARGA (3 parámetros)*/
            /* Replace(string input, string pattern, string replacement) */
            /* Parámetros:
             * input            : Cadena en la que se va a buscar una coincidencia.
             * pattern          : Patrón de expresión regular del que van a buscarse coincidencias.
             * replacement      : La cadena de reemplazo.
             */
            string texto = "este es   un texto  con   demasiados    espacios     en      blanco.";

            string patron = @"\s+";
            /* PATRON       : EXPLICACION                           POSICION DE CARACTER
             * \s+          : busca de uno a más espacios.          (1° a n° caracteres)                                         FINAL
             */

            string reemplazo = " "; //Lo va a reemplazar por solo 1 espacio.
            
            string result = Regex.Replace(texto, patron, reemplazo);

            Console.WriteLine("Cadena Original: {0}", texto);
            Console.WriteLine("Cadena Reemplazada: {0}", result);


            Console.WriteLine("");
            /* SEGUNDA SOBRECARGA (4 parámetros)*/
            /* Replace(String input, String pattern,MatchEvaluator evaluator) */
            /* Parámetros:
             * input            : Cadena en la que se va a buscar una coincidencia.
             * pattern          : Patrón de expresión regular del que van a buscarse coincidencias.
             * evaluator        : Un método personalizado que examina cada coincidencia y devuelve 
                                  la cadena coincidente original o una cadena de reemplazo.
             */

            string frase2 = "Las letras de cada palabra de este texto apareceran desordenadas por " +
                "el método.";
            
            string patron2 = @"\w+"; //Obtiene cada caracter alfabetico.
            /* Instancia un objeto de la clase MatchEvaluator que recibe como parámetro
             * un método que contiene el cambio que recibirá el texto               */
            MatchEvaluator evaluator = new MatchEvaluator(ClaseRegex_Replace_2);

            Console.WriteLine("Palabras Originales:");
            Console.WriteLine(frase2);
            Console.WriteLine();
            Console.WriteLine("Palabras Mezcladas:");
            Console.WriteLine(Regex.Replace(frase2, patron2, evaluator));

        }
        /* Método del segundo ejemplo del método ClaseReges_Replace() */
        //Recibe como parámetro un objeto de la clase Match
        //Esta clase se repite en un bucle hasta que se acaben todas las coincidencias encotnradas
        public static string ClaseRegex_Replace_2(Match match)
        {
            //Guarda el número de letras de la coincidencia que se evalúa
            int arraySize = match.Value.Length;

            // Define dos arrays que tiene con tamaño igual al número de letras de la coincidencia.
            double[] keys = new double[arraySize];
            char[] letters = new char[arraySize];

            // Se instancia un generador de números aleatorios.
            Random rnd = new Random();


            for (int i = 0; i < match.Value.Length; i++)
            {
                //LLena el array de claves con números random
                keys[i] = rnd.NextDouble();

                //Asigna las letras al array de letras (se asigna de forma ordenadas)
                letters[i] = match.Value[i];
            }
            //Combina las letras del array letters según el número que se encuentra en el array de keys.
            Array.Sort(keys, letters, 0, arraySize, Comparer.Default);
            /* Explicación del método Sort (Array keys, Array? items, int index, int length, IComparer? comparer) {
             * ---------Parámetros-----------
             * keys         : Contiene las claves para sortear.
             * items        : Contiene los items que corresponde a cada uno de las llaves
             * index        : El index desde donde se comenzará a sortear.
             * length       : El número de elementos en el rango a sortear.
             * comparer     : Esta implementado para usar con cada elemento.
             */
            //Se regresa la palabra desordenada y se pasa a la siguiente coincidencia
            return new String(letters);
        }

        static void ClaseRegex_Split()
        {
            /* Divide una cadena de entrada en una matriz de subcadenas en las posiciones 
             * definidas por una coincidencia de expresión regular.
             * 
             * Devuelve una matriz de cadenas (String[]).
             * 
             * Divide una cadena según las coincidencias encontradas por una expresión regular,
             * las partes en las que se divide se guardan en una matriz de cadenas.
             * 
             * Si se encuentran dos coincidencias adyacentes, se guarda una cadena 
             * vacía en la matriz.
             * 
             * Si se encuentra una coincidencia al inicio o al final de la cadena, se crea una cadena vacía
             * al inicio o al final de la matriz devuelta.
             * 
             * Si se usa un paréntesis en la expresión regular, cualquier coincidencia encontrada tambien
             * se incluye en la matriz de cadenas resultante. Por ejemplo, si divide la cadena "plum-pear" 
             * en un guión colocado entre paréntesis, la matriz devuelta incluye un elemento de cadena que 
             * contiene el guión. (Si se usa el parámetro Count se muestra la coincidencia encontrada pero 
             * no se cuenta por ejemplo si se puede dividr en un máximo de cuatro subcadenas da como resultado 
             * una matriz de siete elementos).
             * 
             * Sin embargo, cuando el patrón de expresión regular incluye varios conjuntos de paréntesis de captura,
             * todo el texto capturado también se agrega a la matriz devuelta.
             * 
             * Si la expresión regular es una cadena vacía (""), el método Split dividirá la cadena
             * en una matriz de cadenas de un solo caracter porque el delimitador vacío se encuentra en 
             * cada ubicación (También incluírá una cadena vacía al inicio y al final).
             * 
             * La diferencia de Regex.Split con String.Split es que divide por una expresión regular en vez de un
             * conjunto de caracteres.
             * 
             */

            /* PRIMERA SOBRECARGA (1 parámetro)*/
            /* Split(String input)    */
            /* Parámetros:
             * input            : Cadena que se va a dividir.
             */
            string patron = "-";

            string texto = "platano--manzana-uvas-";

            Regex regex = new Regex(patron);  // Split on hyphens.
            string[] substrings = regex.Split(texto);
            foreach (string match in substrings)
            {
                Console.WriteLine("partes divididas: '{0}'", match);
            }


            Console.WriteLine("");
            /* SEGUNDA SOBRECARGA (2 parámetros)*/
            /* Matches(String input, int Count)    */
            /* Parámetros:
             * input            : Cadena que se va a dividir.
             * count            : Número máximo de veces que puede llevarse a cabo la división.
             */
            /* La útima cadena en la matriz devuelta contiene el resto sin dividir de la cadena */
            string pattern2 = "(-)";
            string input2 = "apple-apricot-plum-pear-banana";
            Regex regex2 = new Regex(pattern2);         // Split on hyphens.
            string[] substrings2 = regex2.Split(input2, 4);
            foreach (string match in substrings2)
            {
                Console.WriteLine("'{0}'", match);
            }


            /* TERCERA SOBRECARGA (3 parámetros)*/
            /* Matches(String input, String pattern)    */
            /* Parámetros:
             * input            : Cadena que se va a dividir.
             * pattern          : Patrón de expresión regular del que van a buscarse coincidencias.
             */


            /* CUARTA SOBRECARGA (3 parámetros)*/
            /* Matches(String input, int Count, int startat)    */
            /* Parámetros:
             * input            : Cadena que se va a dividir.
             * count            : Número máximo de veces que puede llevarse a cabo la división.
             * startat          : Posición de carácter de la cadena de entrada donde comenzará la búsqueda.
             */


            /* QUINTA SOBRECARGA (3 parámetros)*/
            /* Matches(String input, string pattern, RegexOptions options)    */
            /* Parámetros:
             * input            : Cadena que se va a dividir.
             * pattern          : Patrón de expresión regular del que van a buscarse coincidencias.
             * options          : Proporciona opciones de coincidencia.
             */


            /* SEXTA SOBRECARGA (4 parámetros)*/
            /* Matches(String input, string pattern, RegexOptions options, TimeSpan matchTimeout)    */
            /* Parámetros:
             * input            : Cadena que se va a dividir.
             * pattern          : Patrón de expresión regular del que van a buscarse coincidencias.
             * options          : Proporciona opciones de coincidencia.
             * matchtimeout     : Un intervalo de tiempo de espera.
             */
        }


        static void Delimitadores_o_Aserciones()
        {
            /* Especifican la posición de la cadena en la que se debe producir una coincidencia
             *
             *Un delimitador no consume caracteres ni avanza en la cadena, solo busca coincidencias 
             * en la posicion especificada.
             * 
             */

            string texto;
            string patron;

            /* '^' o Circumflejo */
            //Principio de cadena o línea
            //Permite usarse en multilínea
            //Se puede usar multilinea con la sobrecarga Matches(String, String, RegexOptions);
            //con el parámetro RegexOptions establecido en RegexOptions.Multiline.
            texto = "amor de vida"; //Es correcto ya que la 'a' de 'amor' se encuentra al inicio de la cadena
            patron = "^(a)";
            Validacion(texto, patron);


            Console.WriteLine("");
            /* '$' o Símbolo del Dolar */
            //l patrón que le precede debe aparecer al final de la cadena de entrada
            //o antes de \n al final de la cadena de entrada.
            //Igual que el circumflejo se puede usar multilinea con la sobrecarga
            //Matches(String, String, RegexOptions);
            texto = "la cadena termina con e"; //Es correcto porque la cadena termina con una 'e'.
            patron = "e$";
            Validacion(texto, patron);



            //ObtenerCoincidencias();


            Console.ReadLine();
        }

        static void Validacion(String texto, String patron)
        {
            Regex regex = new Regex(patron);
            if (regex.IsMatch(texto))
            {
                Console.WriteLine("El patron ( {0} )  es correcto en el texto: {1}", patron, texto);
            }
            else
            {
                Console.WriteLine("El patron ( {0} ) es incorrecto en el texto: {1}", patron, texto);
            }
        }

    }
}

