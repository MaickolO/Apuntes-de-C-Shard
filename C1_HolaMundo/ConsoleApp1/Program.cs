/* Tipos de Datos */
//Integrados Simples:
//sbyte: de -128 a 127 con signo. Entero de 8bits con signo
//byte: de 0 a 255 sin signo. Entero de 8bits sin signo
short entero_pequeno = 0; // de -32768 a 32767. Peso de 16 bits con signo
ushort menos_pequeno = 0; // de 0 a 65535. Peso de 16 bits sin signo.
int entero = 0; // de -2147483648 a 2147483647. Peso de 32 bits con signo.
uint entero_sin_signo = 0; //de 0 a 4294967295. Peso de 32 bits sin signo.
long entero_largo = 0; //Entero de 64 bits con signo
ulong entero_largo_positivo = 0; //Entero de 64 bits sin signo
float flotante = 0.0f; //Posee una presición de 7 dígitos y tiene el indicador 'f' al final.
double doble = 0.22; //Posee una presición de entre 15-16 dígitos y no tiene indicador.
decimal dec = 0.0m;//Posee una presición de 28-29 dígitos y tiene el indicador 'M' al final.
char character = 'M'; //Caracter Unicode de 16bits (Es entre 1 comilla)
Boolean binario = false; //Caracter binario (True o False).
bool binario_2 = true; //Otra forma de usar Boolean.

//Integrados No Simples:
Object objeto; //Puede representar otro tipo de objetos.
String cadena = "Hola Mundo"; //Secuencia básica de carácteres Unicode.
string cadena_2 = "Michael"; //Otra forma de usar String.
dynamic dinamico; //Usando con assemblies escritos en lenguaje dinamico. (No corresponde a .Net)


int year = 22;
var suma = year + doble;
String nombre = "Maickol";

Console.WriteLine("Hola Mundo de C#, mi nombre es " + nombre + " y tengo "+year+ " años.");
Console.WriteLine("Hola Mundo mi nombre es {0} y tengo {1} años.", flotante, dec);
Console.WriteLine("La suma de {0} y {1} es {2}", year, doble, suma);
//Si se usa el segundo método y se coloca {2} (no definido como parámetro, entonces salta un error)
Console.ReadLine();

String num_letra = "3";
int letra_convertido = Convert.ToInt32(num_letra);
String numero_convertido = Convert.ToString(letra_convertido+2);

Console.WriteLine("El numero es {0} y la letra es {1}", letra_convertido, numero_convertido);
Console.ReadLine();

int valor1 = 10;
int valor2 = 5;
var data = valor1 == valor2;