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
            //Lo leído se va guardando en un control richTextBox
            while (reader.Peek() > -1)
            //Esta linea envía el texto leído a un control richTextBox, se puede cambiar para que
            //lo muestre en otro control por ejemplo un combobox
            {
                Empleado empleado = new Empleado();
                empleado.noEmpleado = Convert.ToInt16(reader.ReadLine());
                empleado.Nombre = reader.ReadLine();
                empleado.sueldoHora = Convert.ToDecimal(reader.ReadLine());

                
            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();
        }

        private void cargarAsistencia()
        {
            //Abrimos el archivo, en este caso lo abrimos para lectura
            FileStream stream = new FileStream("Aistencia.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);

            //Un ciclo para leer el archivo hasta el final del archivo
            //Lo leído se va guardando en un control richTextBox
            while (reader.Peek() > -1)
            //Esta linea envía el texto leído a un control richTextBox, se puede cambiar para que
            //lo muestre en otro control por ejemplo un combobox
            {
                Asistencia asistencia = new Asistencia();
                asistencia.noEmpleado = Convert.ToInt16(reader.ReadLine());
                asistencia.horasMes = Convert.ToUInt16(reader.ReadLine());
                asistencia.Mes = reader.ReadLine();


            }
            //Cerrar el archivo, esta linea es importante porque sino despues de correr varias veces el programa daría error
            //de que el archivo quedó abierto muchas veces. Entonces es necesario cerrarlo despues de terminar de leerlo.
            reader.Close();
        }

        private void buttonCargarDatos_Click(object sender, EventArgs e)
        {

        }

        private void buttonCalcular_Click(object sender, EventArgs e)
        {
            for (int i = 0; i<)
        }
    }
}
