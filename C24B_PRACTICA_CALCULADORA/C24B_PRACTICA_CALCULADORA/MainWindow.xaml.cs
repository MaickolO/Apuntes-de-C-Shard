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

namespace C24B_PRACTICA_CALCULADORA
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double valor1, valor2 = 0;
        string signo = "+";
        public MainWindow()
        {
            InitializeComponent();
            num_0.Click += Num_0_Click;
            num_1.Click += Num_1_Click;
            num_2.Click += Num_2_Click;
            num_3.Click += Num_3_Click;
            num_4.Click += Num_4_Click;
            num_5.Click += Num_5_Click;
            num_6.Click += Num_6_Click;
            num_7.Click += Num_7_Click;
            num_8.Click += Num_8_Click;
            num_9.Click += Num_9_Click;
            btn_ac.Click += Btn_ac_Click;
            btn_retro.Click += Btn_retro_Click;
            btn_div.Click += Btn_div_Click;
            btn_multi.Click += Btn_multi_Click;
            btn_resta.Click += Btn_resta_Click;
            btn_suma.Click += Btn_suma_Click;
            btn_punto.Click += Btn_punto_Click;
            btn_igual.Click += Btn_igual_Click;
        }
        
        private void operaciones(int dato)
        {
            var resultado = txtResultado.Text;
            valor1 = Convert.ToDouble(resultado);

            switch(dato)
            {
                case 1:
                    txtResultado.Text = "+";
                    break;
                case 2:
                    txtResultado.Text = "-";
                    break;
                case 3:
                    txtResultado.Text = "x";
                    break;
                case 4:
                    txtResultado.Text = "/";
                    break;
            }
        }

        private void respuesta()
        {
            double solucion;
            var resultado = txtResultado.Text;
            valor2 = Convert.ToDouble(resultado);
            switch (signo)
            {
                case "+":
                    solucion = valor1 + valor2;
                    break;
                case "-":
                    solucion = valor1 - valor2;
                    break;
                case "x":
                    solucion = valor1 * valor2;
                    break;
                case "/":
                    solucion = valor1 / valor2;
                    break;
                default:
                    solucion = 0;
                    break;
            }
            txtResultado.Text = Convert.ToString(solucion);
        }

        private void agregar_numero(int num)
        {
            var resultado = txtResultado.Text;
            if (resultado.Equals("0"))
            {
                txtResultado.Text = Convert.ToString(num);
            } 
            else if (resultado.Equals("+") || resultado.Equals("-") 
                || resultado.Equals("x") || resultado.Equals("/"))
            {
                signo = txtResultado.Text;
                txtResultado.Text = Convert.ToString(num);
            } 
            else
            {
                txtResultado.Text = resultado + Convert.ToString(num);
            }
            
        }

        private void Num_0_Click(object sender, RoutedEventArgs e)
        {
            agregar_numero(0);
        }

        private void Num_1_Click(object sender, RoutedEventArgs e)
        {
            agregar_numero(1);
        }

        private void Num_2_Click(object sender, RoutedEventArgs e)
        {
            agregar_numero(2);
        }

        private void Num_3_Click(object sender, RoutedEventArgs e)
        {
            agregar_numero(3);
        }

        private void Num_4_Click(object sender, RoutedEventArgs e)
        {
            agregar_numero(4);
        }

        private void Num_5_Click(object sender, RoutedEventArgs e)
        {
            agregar_numero(5);
        }

        private void Num_6_Click(object sender, RoutedEventArgs e)
        {
            agregar_numero(6);
        }

        private void Num_7_Click(object sender, RoutedEventArgs e)
        {
            agregar_numero(7);
        }

        private void Num_8_Click(object sender, RoutedEventArgs e)
        {
            agregar_numero(8);
        }

        private void Num_9_Click(object sender, RoutedEventArgs e)
        {
            agregar_numero(9);
        }

        private void Btn_ac_Click(object sender, RoutedEventArgs e)
        {
            valor1 = 0;
            valor2 = 0;
            signo = "+";
            txtResultado.Text = "0";
        }

        private void Btn_retro_Click(object sender, RoutedEventArgs e)
        {
            var numeros = txtResultado.Text;

            if (numeros.Length == 1)
            {
                txtResultado.Text = "0";
            } else
            {
                numeros = numeros.Remove(numeros.Length - 1);
                txtResultado.Text = numeros;
            }
        }

        private void Btn_suma_Click(object sender, RoutedEventArgs e)
        {
            operaciones(1);
        }

        private void Btn_resta_Click(object sender, RoutedEventArgs e)
        {
            operaciones(2);
        }

        private void Btn_multi_Click(object sender, RoutedEventArgs e)
        {
            operaciones(3);
        }

        private void Btn_div_Click(object sender, RoutedEventArgs e)
        {
            operaciones(4);
        }

        private void Btn_igual_Click(object sender, RoutedEventArgs e)
        {
            respuesta();
        }

        private void Btn_punto_Click(object sender, RoutedEventArgs e)
        {
            txtResultado.Text += ".";
        }

    }
}
