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
using log4net.Config;
using log4net;
using FileServer.Utils.LogHelper;
using FileServer.Utils.CustomException;
using System.Resources;
using System.Reflection;
using FileServer.Utils.FileManager;

namespace FileServer.Presentation.WinSite
{
    public partial class Form1 : Form
    {
        private static readonly log4net.ILog log = LogHelper.GetLogger();

        public Form1()
        {
            InitializeComponent();
            origin.SelectedIndex = 0;
            comboBox1.SelectedIndex = 1;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AbstractFileFactory fFactory = new FileManagerFactory();
            var alumnoRepository = new AlumnoRepository(fFactory, comboBox1.SelectedIndex, origin.SelectedIndex);

            log.Debug(Resource.addBtn);

            // recoge datos alumno
            Alumno alumno = new Alumno(nameBox.Text, surnameBox.Text, dniBox.Text);

            var alumnoSaved = alumnoRepository.Add(alumno);

            if (alumnoSaved.Equals(alumno))
            {
                MessageBox.Show(Resource.saveAlum);
            }
            else
            {
                MessageBox.Show(Resource.err3);
            }
            nameBox.Clear(); surnameBox.Clear(); dniBox.Clear();
        }
    }
}
