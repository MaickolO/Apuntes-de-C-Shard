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

namespace C22_WPF1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window //Heredamos de la clase windows
    {
        public MainWindow()
        {
            InitializeComponent();

        /* CODIGO COMENTADO PARA TRABAJAR CON XAML
        
            Grid grid = new Grid(); //Instanciamos un grid
            this.Content = grid; //Metemos el Grid dentro de la venta
            
            Button btn = new Button(); //Instanciamos un boton
            btn.Width = 150;
            btn.Height = 75;
            btn.Background = Brushes.Red; ///Cambiamos el color de fondo

            WrapPanel wrapPanel = new WrapPanel();

            TextBlock txt1 = new TextBlock();
            txt1.Text = "hola";
            Color color = (Color)ColorConverter.ConvertFromString("#000fff");
            txt1.Foreground = new SolidColorBrush(color); //Cambiar color segun codigo hexadecimal
            wrapPanel.Children.Add(txt1);

            btn.Content = wrapPanel;

            grid.Children.Add(btn); //Agregamos el boton al grid

        */

            //El diseño programado en C# tiene prioridad en comparacion al realizado con xaml
            //Para observar el diseño de XAML es necesario ocultar o eliminar el grid y los
            //elementos en su interior.
        }
    }
}
