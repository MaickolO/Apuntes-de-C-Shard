using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C27_INotifyPropertyChanged
{
    public class AddNombreApellido : INotifyPropertyChanged
    {

        private string nombre, apellido, nombreCompleto;

        //Evento para utilizar INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        //Metodo que se desencadene cada vez que cambie la propiedad de los componentes
        private void OnPropertyChanged(String property)
        {
            //Si "ProtertyChanged" detecta un cambio, invoca esto:
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public string Nombre
        {
            get { return nombre; }

            set 
            { 
                nombre = value;
                OnPropertyChanged("Nombre_Completo");
            }
        }

        public string Apellido
        {
            get { return apellido; }

            set 
            { 
                apellido = value;
                OnPropertyChanged("Nombre_Completo");
            }
        }

        public string Nombre_Completo
        {
            get 
            { 
                nombreCompleto =  nombre + " " + apellido;
                return nombreCompleto;
            }
                
            set {  }
        }

    }
}
