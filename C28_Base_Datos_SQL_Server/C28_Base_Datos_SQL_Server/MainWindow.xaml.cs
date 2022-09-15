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
using System.Data.SqlClient;
using System.Data;

namespace C28_Base_Datos_SQL_Server
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        SqlConnection miConexionSql;

        public MainWindow()
        {
            InitializeComponent();

            string miConexion = ConfigurationManager.ConnectionStrings
                ["C28_Base_Datos_SQL_Server.Properties.Settings.GestionPedidosConnectionString"].
                ConnectionString;
            miConexionSql = new SqlConnection(miConexion);
            MostrarClientes();

        }

        private void MostrarClientes()
        {
            //Donde se almacenara la conexion sql
            string consulta = "SELECT * FROM cliente";
            //Unir l consulta con la conexion
            SqlDataAdapter adaptador = new SqlDataAdapter(consulta, miConexionSql);
            //Usando este adaptador vas a hacer...
            using (adaptador)
            {   
                //Instanciamos una tabla
                DataTable tablaClientes = new DataTable();
                //Rellenamos el resultado de la consulta en la tabla
                adaptador.Fill(tablaClientes);
                //Especificar que solo muestra el campo nombre de la tabla cliente en ListBox 
                ListaClientes.DisplayMemberPath = "nombre";
                //Especificar el campo clave de la tabla
                ListaClientes.SelectedValuePath = "Id";
                //Especificar el origen de los datos
                ListaClientes.ItemsSource = tablaClientes.DefaultView;
            }
        }

        private void MostrarPedidos()
        {
            //Consulta Paramétrica -> @ClienteId es el parámetro a ingresar.
            string consulta = "SELECT * FROM PEDIDO P INNER JOIN CLIENTE C ON C.ID = P.IDCLIENTE where C.ID = @ClienteId";
            //Nos permite ejecutar una instrucción SQL con parámetro
            SqlCommand sqlComando = new SqlCommand(consulta, miConexionSql);
            //Se le debe pasar SQLCommand ahora al ser una consulta paramétrica
            SqlDataAdapter adaptador = new SqlDataAdapter(sqlComando);

            using (adaptador)
            {   
                //Le decimos que valor tendrá el parámetro que se ingresará en la consulta
                sqlComando.Parameters.AddWithValue("@ClienteId", ListaClientes.SelectedValue);

                DataTable tablaPedidos = new DataTable();

                adaptador.Fill(tablaPedidos);

                ListaPedidos.DisplayMemberPath = "fechaPedido";
                ListaPedidos.SelectedValuePath = "id";
                ListaPedidos.ItemsSource = tablaPedidos.DefaultView;
            }
        }

        private void ListaClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MostrarPedidos();
        }
    }
}
