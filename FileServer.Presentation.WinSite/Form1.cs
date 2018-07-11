using FileServer.Common.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileServer.Infrastructure.Repository.Repositories;

namespace FileServer.Presentation.WinSite
{
    public partial class Form1 : Form
    {
        AlumnoRepository alumnoRepository = new AlumnoRepository();

        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            // recoge datos alumno
            var alumno = new Alumno()
            {
                Nombre = nameBox.Text,
                Apellidos = surnameBox.Text,
                Dni = dniBox.Text,
            };

            var alumnoSaved = alumnoRepository.Add(alumno);

            if (alumnoSaved != null)
            {
                // clear fields after saved data
                nameBox.Text = "";
                surnameBox.Text = "";
                dniBox.Text = "";
                MessageBox.Show("Alumno guardado correctamente");
            }
            else
            {
                MessageBox.Show("Error!!!");
            }

            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            alumnoRepository.ChangeOrigin(origin.Text);
        }

        private void nameBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
