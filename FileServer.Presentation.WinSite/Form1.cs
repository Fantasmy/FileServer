﻿using FileServer.Common.Model;
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

namespace FileServer.Presentation.WinSite
{
    public partial class Form1 : Form
    {
        AlumnoRepository alumnoRepository = new AlumnoRepository();

        private static readonly log4net.ILog log = LogHelper.GetLogger();

        //ResourceManager rm = new ResourceManager("FileServer.Presentation.WinSite.Resource", Assembly.GetExecutingAssembly());

        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    int p = 0;
            //    var num = 5 / p;
            //}
            //catch (VuelingException ex)
            //{
            //    LogManager.GetLogger(Resource.eLogger).Error(ex);
            //    throw new VuelingException(Resource.err);

            //}

            log.Debug(Resource.addBtn);

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
                MessageBox.Show(Resource.saveAlum);
            }
            else
            {
                MessageBox.Show(Resource.err3);
            }


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            alumnoRepository.ChangeOrigin(origin.Text);
        }
    }
}
