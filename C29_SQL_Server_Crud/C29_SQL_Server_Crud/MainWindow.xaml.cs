using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace C29_SQL_Server_Crud
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
                //NombreProyecto.Properties.Settings.ValorOrigenDatos
                ["C29_SQL_Server_Crud.Properties.Settings.GestionPedidosConnectionString"].
                ConnectionString;
            miConexionSql = new SqlConnection(miConexion);
            MostrarClientes();
            MostrarPedidosCompleto();
        }

        /* READ */
        private void MostrarClientes()
        {
            try
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
            } catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        /* READ SEGUN OTRA TABLA */
        private void MostrarPedidos()
        {
            try
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
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void MostrarPedidosCompleto()
        {
            try
            {
                //Concadenamos los tres campos en uno solo
                //(*, para poder obtener cualquier dato y no solo el concat)
                string consulta = "SELECT *, CONCAT(idCliente, ' ', fechaPedido, ' ', formaPago) AS " +
                    " InformacionPedido FROM pedido";
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, miConexionSql);
                using (adaptador)
                {
                    //Instanciamos una tabla
                    DataTable tablePedidos = new DataTable();
                    //Rellenamos el resultado de la consulta en la tabla
                    adaptador.Fill(tablePedidos);
                    //Especificar que solo muestra el campo nombre de la tabla cliente en ListBox 
                    //DisplayMemberPath no admite concadenar varios campos
                    PedidosCompleto.DisplayMemberPath = "InformacionPedido";
                    //Especificar el campo clave de la tabla
                    PedidosCompleto.SelectedValuePath = "Id";
                    //Especificar el origen de los datos
                    PedidosCompleto.ItemsSource = tablePedidos.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        /* DELETE */
        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            string consulta = "DELETE FROM pedido WHERE ID=@PEDIDOID";

            SqlCommand sqlCommand = new SqlCommand(consulta, miConexionSql);

            miConexionSql.Open();
            sqlCommand.Parameters.AddWithValue("@PEDIDOID", PedidosCompleto.SelectedValue);

            sqlCommand.ExecuteNonQuery();

            miConexionSql.Close();
            //Actualizar la tabla
            MostrarPedidosCompleto();
        }
        /* CREATE */
        private void InsertarCliente_Click(object sender, RoutedEventArgs e)
        {
            string consulta = "INSERT INTO cliente (nombre) VALUES (@nombreCliente)";

            SqlCommand sqlCommand = new SqlCommand(consulta, miConexionSql);

            miConexionSql.Open();
            sqlCommand.Parameters.AddWithValue("@nombreCliente", txtCliente.Text);

            sqlCommand.ExecuteNonQuery();

            miConexionSql.Close();
            //Actualizar la tabla
            MostrarClientes();
        }

        private void BorrarCliente_Click(object sender, RoutedEventArgs e)
        {
            string consulta = "DELETE FROM cliente WHERE ID=@CLIENTEID";

            SqlCommand sqlCommand = new SqlCommand(consulta, miConexionSql);

            miConexionSql.Open();
            sqlCommand.Parameters.AddWithValue("@CLIENTEID", ListaClientes.SelectedValue);

            sqlCommand.ExecuteNonQuery();

            miConexionSql.Close();
            //Actualizar la tabla
            MostrarClientes();
            txtCliente.Text = "";
        }

        private void ListaClientes_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MostrarPedidos();
        }

        private void ActualizarCliente_Click(object sender, RoutedEventArgs e)
        {
            //Se envia como parámetro el ID del cliente que se va a actualizar
            WPFActualizarCliente wpfactualizar = new WPFActualizarCliente((int)ListaClientes.SelectedValue);

            wpfactualizar.Show();
            try
            {
                string consulta = "SELECT nombre FROM cliente WHERE id=@ClId";

                SqlCommand sqlCommand = new SqlCommand(consulta, miConexionSql);


                SqlDataAdapter adaptador = new SqlDataAdapter(sqlCommand);

                using (adaptador)
                {

                    sqlCommand.Parameters.AddWithValue("@ClId", ListaClientes.SelectedValue);
                    DataTable tblClientes = new DataTable();
                    
                    adaptador.Fill(tblClientes);
                    //Llevo el valor de la columna 0 al cuadro de texto en el otro WPF
                    //(la tabla solo recibe un dato asi que solo tiene una columna)
                    wpfactualizar.txtActualizar.Text = tblClientes.Rows[0]["nombre"].ToString();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }

            //Show -> Ventana no modal
            //ShowDialog -> Ventana modal
            //Modal significa que no se va a poder interactuar con la ventana anterior mientras
            //que la ventana que se abrió no se cierre (no se pondrá en primer plano).
            //Sin embargo se debe ejecutar la instruccion al final porque no se ejecutará 
            //cualquier codigo posterior en la ventana.
            //Una vez se cierre la ventana mostrada se ejecuta el codigo posterior


            //wpfactualizar.ShowDialog();
            //MostrarClientes();

        }

        //Evento que se ejecutará cuando la venta entre a primer plano
        private void Window_Activated(object sender, EventArgs e)
        {
            MostrarClientes();
        }
    }
}