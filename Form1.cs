using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repaso1D
{
    public partial class Form1 : Form
    {
        //Lista de Empleados
        List<Empleado> empleados = new List<Empleado>();
        //Lista de Asistencias
        List<Asistencia> asistencias = new List<Asistencia>();
        //Lista de Sueldos
        List<Sueldo> sueldos = new List<Sueldo>();

        public Form1()
        {
            InitializeComponent();
        }

        private void cargarEmpleado()
        {
            //Abrimos el archivo, en este caso lo abrimos para lectura
            FileStream stream = new FileStream("Empleado.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            //Un ciclo para leer el archivo hasta el final del archivo
            while (reader.Peek() > -1)
            
            {
                //cada una de las linea las va ir guardando en la lista empleados
                Empleado empleado = new Empleado();
                empleado.noEmpleado = Convert.ToInt16(reader.ReadLine());
                empleado.Nombre = reader.ReadLine();
                empleado.sueldoHora = Convert.ToDecimal(reader.ReadLine());

                //se agrega un empleado a la lista
                empleados.Add(empleado);
            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error
            //de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();
        }

        private void cargarAsistencia()
        {
            //Abrimos el archivo, en este caso lo abrimos para lectura
            FileStream stream = new FileStream("Asistencia.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            //Un ciclo para leer el archivo hasta el final del archivo
            while (reader.Peek() > -1)
            {
                //cada una de las linea las va ir guardando en la lista empleados
                Asistencia asistencia = new Asistencia();
                asistencia.noEmpleado = Convert.ToInt16(reader.ReadLine());
                asistencia.horasMes = Convert.ToUInt16(reader.ReadLine());
                asistencia.Mes = reader.ReadLine();

                //se agrega una asistencia a la lista
                asistencias.Add(asistencia);
            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error
            //de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();
        }

        void cargarGrid()
        {
            //carga los datos de los empleados en el datagridview1
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            dataGridView1.DataSource = empleados;
            dataGridView1.Refresh();

            //carga los datos de las asistencias en el datagridview2
            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            dataGridView2.DataSource = asistencias;
            dataGridView2.Refresh();
        }

        private void buttonCargarDatos_Click(object sender, EventArgs e)
        {
            cargarAsistencia();
            cargarEmpleado();
            cargarGrid();
        }

        private void buttonCalcular_Click(object sender, EventArgs e)
        {
            for (int i = 0; i< empleados.Count; i++) //recorre a los empleados
            {
                for (int j = 0; j<asistencias.Count; j++) //recorre a las asistencias
                {
                    if(empleados[i].noEmpleado == asistencias[j].noEmpleado) //verifica que ambos esten en la misma posicion y mismo dato
                    {
                        Sueldo sueldo = new Sueldo();
                        sueldo.noEmpleado = empleados[i].noEmpleado;
                        sueldo.Nombre = empleados[i].Nombre;
                        sueldo.sueldoMes = empleados[i].sueldoHora * asistencias[j].horasMes;
                        sueldo.Mes = asistencias[j].Mes;

                        sueldos.Add(sueldo);

                    }

                }
            }
            //carga los datos de los sueldos por mes en el datagridview3
            dataGridView3.DataSource = sueldos;
            dataGridView3.Refresh();
        }
    }
}
