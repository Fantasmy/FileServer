using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileServer.Common.Model;
using Newtonsoft.Json;
using FileServer.Utils.FileManager;
using System.Configuration;
using log4net;
using FileServer.Utils.LogHelper;
using log4net.Config;
using FileServer.Utils.CustomException;
using System.Resources;
using System.Reflection;

namespace FileServer.Infrastructure.Repository.Repositories
{
    public class AlumnoRepository : IAlumnoRepository
    {
        private FileManager fileManager = new FileManager();

        private static readonly ILog log = LogHelper.GetLogger();

        public FileManager FManager { get; set; }

        public AlumnoRepository(AbstractFileFactory factory, int fileType, int filePathType)
        {
            //log4net.Config.XmlConfigurator.Configure();
            FManager = factory.GetFileManager(fileType, filePathType);
        }

        public AlumnoRepository()
        {
        }

        public Alumno Add(Alumno alumno)
        {
            try
            {
                return FManager.ProcessAlumnoData(alumno);
            }
            catch (Exception ex)
            {
                Console.WriteLine(Resource1.loadEr + ex.StackTrace);
                log.Error(Resource1.erWrite);
                return null;
            }
        }
    }
}
