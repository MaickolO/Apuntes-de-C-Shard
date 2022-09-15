using System;
using System.Collections.Generic;
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

/* Interfaz INotifyPropertyChanged
 * Sirve para detectar los cambios en las propiedades de objetos
 * 
 * Reune todos los eventos que pueden desencadenar eventos en uno solo
 * 
 * Objeto (Text, Background, Color => Evento por cada uno de las propiedades)
 * En vez de notificar los cambios uno por uno en cada propiedad del objeto, se puede agrupar el cambio para 
 * todas las propiedades.
 * 
 * 
 * 
 */

namespace C27_INotifyPropertyChanged
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            AgregarNombreApellido = new AddNombreApellido() { Nombre = "Michael", Apellido = "Orizano" };
            //DataContext Para usar el DataBiding
            this.DataContext = AgregarNombreApellido;

        }

        public AddNombreApellido AgregarNombreApellido;
    }


}
