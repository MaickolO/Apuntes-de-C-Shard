using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace C32_LINQ_SQLServer
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //El archivo dbml nos permite el mapeo de la base de datos con ORM (Object Database Mapper)
        //ENtity Framework utiliza ORM para .NET    
        //Se obtiene creando un nuevo elemento y poniendo en el buscador linq
        //El elemento se llama DataClasses1.dbml
        DataClasses1DataContext dataContext;

        public MainWindow()
        {
            InitializeComponent();

            //Cadena de conexion
            string conexion = ConfigurationManager.ConnectionStrings
                ["C32_LINQ_SQLServer.Properties.Settings.GestionPedidosConnectionString"].
                ConnectionString;
            //Mapeo de los datos con los vamos a conectarnos
            dataContext = new DataClasses1DataContext(conexion);

            //InsertEmpresas();
            //InsertEmpleado();
            //InsertCargos();
            //InsertEmpleadoCargo();
            //UpdateEmpleado();
            DeleteEmpleado();
        }

        public void InsertEmpresas()
        {
            /* Para que no se repita la empresa al volver a ejecutar la consola, le podemos decir
             * que borre toda la informacion de la tabla y luego los inserte. 
             * Sin embargo no se reinician los IDs. */
            dataContext.ExecuteCommand("delete from Empresa");

            //Reconoce en el mapeo de LINQ (Se arrastra la tabla desde el explorador de servidores)
            Empresa empresaGoogle = new Empresa();
            //Dar un nombre al campo empresa
            empresaGoogle.nombre = "Google";
            //Agregamos el objeto a la base de datos como registro
            dataContext.Empresa.InsertOnSubmit(empresaGoogle);

            /* CREAR MAS EMPRESAS */
            Empresa empresaApple = new Empresa();
            empresaApple.nombre = "Apple";
            dataContext.Empresa.InsertOnSubmit(empresaApple);

            //Guardar cambios en el datContext
            dataContext.SubmitChanges();

            //Mostramos lo insertado en el Grid
            Principal.ItemsSource = dataContext.Empresa;
        }

        public void InsertEmpleado()
        {
            //Creamos un objeto de Empresa porque en la tabla Empleado se pide idEmpresa
            //Se pide mediante expresion lambda obtener una empresa segun su nombre
            Empresa empresaGoogle = dataContext.Empresa.First(em => em.nombre.Equals("Google"));
            Empresa empresaApple = dataContext.Empresa.First(em => em.nombre.Equals("Apple"));

            //Hacemos una lista donde agregaremos los empleados
            List<Empleado> listaEmpleado = new List<Empleado>();
            
            listaEmpleado.Add(new Empleado { 
                nombre="Michael", 
                apellido="Orizano", 
                idEmpresa=empresaGoogle.id 
            });
            
            listaEmpleado.Add(new Empleado { 
                nombre = "Ana", 
                apellido = "Martinez", 
                idEmpresa = empresaApple.id 
            });
            
            listaEmpleado.Add(new Empleado
            {
                nombre = "Ricardo",
                apellido = "Gomez",
                idEmpresa = empresaGoogle.id
            });

            listaEmpleado.Add(new Empleado
            {
                nombre = "Maria",
                apellido = "Sanchez",
                idEmpresa = empresaApple.id
            });

            //Insertamos todos los elementos de la lista
            dataContext.Empleado.InsertAllOnSubmit(listaEmpleado);

            //Guardamos los cambios
            dataContext.SubmitChanges();

            //Mostramos lo insertado en el Grid
            Principal.ItemsSource = dataContext.Empleado;
        }

        public void InsertCargos()
        {
            //Introducir nuevos registros a la tabla
            dataContext.Cargo.InsertOnSubmit(new Cargo { nombre = "Director"} );
            dataContext.Cargo.InsertOnSubmit(new Cargo { nombre = "Administrativo" });

            //Guardamos los cambios
            dataContext.SubmitChanges();

            //Mostramos lo insertado en el Grid
            Principal.ItemsSource = dataContext.Cargo;
        }

        public void InsertEmpleadoCargo()
        {

            Empleado empleadoMichael = dataContext.Empleado.First(e => e.nombre.Equals("Michael"));

            Cargo cargoDirector = dataContext.Cargo.First(e => e.nombre.Equals("Director"));

            List<CargoEmpleado> lista = new List<CargoEmpleado>();


            //FORMAS PARA AGREGAR UN NUEVO CARGOEMPLEADO A LA LISTA

            //Agregar creando primero los objetos del empleado y del cargo y luego unirlos en el objeto
            //CargoEmpleado
            lista.Add(new CargoEmpleado { Empleado = empleadoMichael, Cargo = cargoDirector });

            //En el objeto CargoEmpleado obtener los campos sin necesidad de crear objetos de Empleado y Cargo
            lista.Add(new CargoEmpleado {
                Empleado = dataContext.Empleado.First(em => em.nombre.Equals("Ana")),
                Cargo  = dataContext.Cargo.First(cg => cg.nombre.Equals("Director"))
            });

            //Dar los valores de idCargo e idEmpleado (Solo si se tiene los valores, no hace una 
            //busqueda dinámica)
            lista.Add(new CargoEmpleado { idCargo = 2, idEmpleado = 3 });

            lista.Add(new CargoEmpleado { idCargo = 2, idEmpleado = 4 });

            dataContext.CargoEmpleado.InsertAllOnSubmit(lista);

            //Guardamos los cambios
            dataContext.SubmitChanges();

            //Mostramos lo insertado en el Grid
            Principal.ItemsSource = dataContext.CargoEmpleado;
            
        }


        private void UpdateEmpleado() 
        {
            Empleado Maria = dataContext.Empleado.First(e => e.nombre.Equals("Maria"));

            Maria.nombre = "Mariana";

            dataContext.SubmitChanges();

            Principal.ItemsSource = dataContext.Empleado;

        }


        private void DeleteEmpleado()
        {
            Empleado Ana = dataContext.Empleado.First(e => e.nombre.Equals("Ana"));

            dataContext.Empleado.DeleteOnSubmit(Ana);

            dataContext.SubmitChanges();

            Principal.ItemsSource = dataContext.Empleado;

        }

    }
}
