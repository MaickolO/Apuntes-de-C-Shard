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

namespace C23_WPF_StackPanel_Eventos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    /// 

    /*Eventos
     * Los eventos son considerados objetos. (Por ejemplo el evento de tipo click)
     * Los tipos de evento sirven para definir el orden de ejecución de eventos de los diferentes elementos.
     * 
     * Eventos Enrutados -> Los eventos siguen una ruta. Segun la ruta hay 3 tipos de evtos:
     * 
     *  Directos -> Sin propagación.
     *  
     *  Burbuja (bubbling) -> Se propagan hacia arriba (desde contenido hacia contenedores)
     *      Si el evento ocurre en un btn, sigue hacia su contenedor y asi hasta llegar a window.
     *      ButtonBase.Click es un evento de tipo bubbling
     *      
     *  Tunelados (Tunneling) -> Se propaga hacia abajo (llevan la palabra "preview" delante del nombre del evento)
     *      Si tenemos un evento en un btn, ese evento se propaga hacia su contenido como su texto.
     *      Preview... se usa para eventos de tipo tunneling (PreviewMouseLeftButtonDown)
     *      
     *      Cuando se da click a eventos tunneling y bubbling, el evento tunneling se ejecuta primero.
     *      
     */

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Click_btn2(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Diste click al btn2");
            //MessageBox.Show("Mensaje de evento click en btn2")
        }

        private void panel1_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Diste click al panel4");
        }

        private void panel1_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Diste click al panel1");
        }
    }
}
