using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace C29_SQL_Server_Crud
{
    /// <summary>
    /// Lógica de interacción para WPFActualizarCliente.xaml
    /// </summary>
    public partial class WPFActualizarCliente : Window
    {
        SqlConnection miConexionSql;
        private int idCliente;
        public WPFActualizarCliente(int id)
        {
            idCliente = id;
            InitializeComponent();
            string miConexion = ConfigurationManager.ConnectionStrings
                //NombreProyecto.Properties.Settings.ValorOrigenDatos
                ["C29_SQL_Server_Crud.Properties.Settings.GestionPedidosConnectionString"].
                ConnectionString;
            miConexionSql = new SqlConnection(miConexion);
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            
            string consulta = "UPDATE cliente SET nombre=@Nombre WHERE Id=" + idCliente;

            SqlCommand sqlCommand = new SqlCommand(consulta, miConexionSql);

            miConexionSql.Open();

            sqlCommand.Parameters.AddWithValue("@Nombre", txtActualizar.Text);

            sqlCommand.ExecuteNonQuery();

            miConexionSql.Close();
            //Cierra la ventana actual
            this.Close();

        }
    }
}
