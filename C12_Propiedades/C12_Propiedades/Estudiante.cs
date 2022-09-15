using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C12_Propiedades
{
    //Pubic para invocar a esa clase fuera de ese archivo
    public class Estudiante
    {
        /*public para poder asignar información fuera de esa clase. Si quiero que solo la clase
         * actual tenga acceso se usa el modificador private */
        /* GET nos permite obtener el valor de la propiedad
         * SET nos permite establecer el valor de la propiedad */
        
        public int Edad { get; set; }
        public String Nombre { get; set; } = "Alex";
        //public String Nombre { get; set; } -> No es necesario inicializar la propiedad
        private double calificacion;

        public double Calificacion
        {
            get { return calificacion; }
            set { calificacion = value; }
        }




        /* USAR SET SIN GET */
        //Para darle valor es necesario crear otra variable
        private String Only_set;
        public String only_set
        { //Asignamos la propiedad only_set para darle nombre a Only_set
            set { Only_set = value; }
            //set => Only_set = value; -> Usando codigo lambda
        }

        /* USAR GET SIN SET */
        private String Only_get;
        public String only_get
        {
            get { return Only_get; }
            //get => Only_get;  -> Usando codigo lambda
        }


    }
}
