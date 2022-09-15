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

namespace C25_Dependency_Properties
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //Creamos la propiedad
        public int  MiProperty
        {   
            //Establecemos y obtenemos la dependency property registrada
            get { return (int)GetValue(miDependencyProperty); }
            
            set { SetValue(miDependencyProperty, value); }

        }

        //Registrar la dependency property
        public static readonly DependencyProperty miDependencyProperty =
            DependencyProperty.Register("MiProperty", typeof(int), typeof(MainWindow), new PropertyMetadata(0));
            //Nombre de la propiedad, tipo de dato, clase donde se declaro la propiedad y los metadatos
            //(0 o false significa que no tiene metadatos)

        public MainWindow()
        {
            InitializeComponent();
            Button btn = new Button();

        }
    }
}
