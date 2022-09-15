using System;
using System.Linq;

namespace C31_Linq_Objetos
{
    class Program
    {
        static void Main(string[] args)
        {
            ControlEmpresasEmpleados c = new ControlEmpresasEmpleados();
            c.getCeo();
            Console.WriteLine("");
            c.getEmpleadosOrdenados();
            Console.WriteLine("");
            c.getEmpleadosGoogle();
            Console.WriteLine("");
            Console.WriteLine("Introduce la Id de la empresa: ");
            int valor = Convert.ToInt32(Console.ReadLine());
            c.getEmpleadosEmpresa(valor);   
        }
    }


    class Empresa
    {
        public int id { get; set; }
        public string name { get; set; }

        public void DatosEmpresa()
        {
            Console.WriteLine("Empresa {0} con id {1}", name, id);
        }
    }


    class Empleado
    {
        public int id { get; set; }
        public string name { get; set; }
        public string cargo { get; set; }
        public double salario { get; set; }
        //Clave Foránea
        public int idEmpresa { get; set; }

        public void DatosEmpleado()
        {
            Console.WriteLine("Empleado {0} con id {1}, cargo {2}, " +
                "salario {3} e id de la empresa {4}", name, id, cargo, salario, idEmpresa);
        }

    }

    //Clase donde podamos almacenar empresas y empleados
    class ControlEmpresasEmpleados
    {
        public List<Empresa> ListaEmpresas;
        public List<Empleado> ListaEmpleados;

        public ControlEmpresasEmpleados()
        {
            ListaEmpresas = new List<Empresa>();
            ListaEmpleados = new List<Empleado>();

            ListaEmpresas.Add(new Empresa { id = 1, name = "Google" });
            ListaEmpresas.Add(new Empresa { id = 2, name = "Apple" });
            ListaEmpresas.Add(new Empresa { id = 3, name = "Samsung" });


            ListaEmpleados.Add(new Empleado
            {
                id = 1,
                name = "Michael",
                cargo = "CEO",
                salario = 5234.31,
                idEmpresa = 1
            });

            ListaEmpleados.Add(new Empleado
            {
                id = 2,
                name = "Orlando",
                cargo = "Programador",
                salario = 3245.31,
                idEmpresa = 1
            });

            ListaEmpleados.Add(new Empleado
            {
                id = 3,
                name = "Luis",
                cargo = "CEO",
                salario = 1532.4,
                idEmpresa = 2
            });

            ListaEmpleados.Add(new Empleado
            {
                id = 4,
                name = "Richard",
                cargo = "Analista",
                salario = 86332.3,
                idEmpresa = 3

            });
        }

        public void getCeo()
        {
            //Filtrar a los empleados segun su cargo con LINQ.
            IEnumerable<Empleado> ceos = from empleado in ListaEmpleados where 
                                         empleado.cargo == "CEO" select empleado;

            foreach (Empleado item in ceos)
            {
                item.DatosEmpleado();
            }

        }


        public void getEmpleadosOrdenados()
        {
            //descending para que sea de z-a
            IEnumerable<Empleado> empleados = from empleado in ListaEmpleados orderby empleado.name descending
                                              select empleado;

            foreach (Empleado item in empleados)
            {
                item.DatosEmpleado();
            }
        }


        public void getEmpleadosGoogle()
        {
            IEnumerable<Empleado> empleados = from empleado in ListaEmpleados
                                              join Empresa in ListaEmpresas
                                              on empleado.idEmpresa equals Empresa.id
                                              where Empresa.id == 1
                                              select empleado;
                                              

            foreach (Empleado item in empleados)
            {
                item.DatosEmpleado();
            }
        }


        public void getEmpleadosEmpresa(int Id)
        {
            IEnumerable<Empleado> empleados = from empleado in ListaEmpleados
                                              join Empresa in ListaEmpresas
                                              on empleado.idEmpresa equals Empresa.id
                                              where Empresa.id == Id
                                              select empleado;


            foreach (Empleado item in empleados)
            {
                item.DatosEmpleado();
            }
        }

    }

}