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
        ResourceManager rm = new ResourceManager("FileServer.Presentation.WinSite.Resource", Assembly.GetExecutingAssembly());
        private FileManager fileManager = new FileManager();
        private static readonly ILog log = LogHelper.GetLogger();
        public List<Alumno> GetAll()
        {
            string alumnosStr = fileManager.getJsonContent();
            if (alumnosStr == null)
            {
                return new List<Alumno>();
            }
            else
            {
                try
                {
                    log.Debug("Trying to deserialize object");
                    return JsonConvert.DeserializeObject<List<Alumno>>(alumnosStr);
                }

                catch (VuelingException ex)
                {
                    return new List<Alumno>();
                    //throw new VuelingException(string.Format(rm.GetString("error")));
                    
                }
            }
        }

        public Alumno Add(Alumno alumno)
        {
            try
            {
                alumno.IdAlumno = Guid.NewGuid().ToString();
                log.Debug("Created a new guid");

                var alumnos = GetAll();
                alumnos.Add(alumno);
                log.Debug("Added new alumno to the alumnos list");

                string Json = JsonConvert.SerializeObject(alumnos, Formatting.Indented);
                fileManager.createJsonToFile(Json);

                Console.WriteLine(alumno.Nombre);
                log.Debug("Returned alumno");
                return alumno;
            }

            catch (Exception ex)
            {
                Console.WriteLine("load error: " + ex.StackTrace);
                log.Error("Error cannot werite line");
                return null;
            }
        }

        public void ChangeOrigin(string origin)
        {
            string filePath = "";
            if ("App.config".Equals(origin))
            {
                filePath = ConfigurationManager.AppSettings["fileName"];
                log.Debug("App.Config path chosen");
            }
            else if ("Variable de entorno".Equals(origin))
            {
                filePath = Environment.GetEnvironmentVariable("fileName");
                log.Debug("Environment path chosen");

            }
            this.fileManager.setFilePath(filePath);
        }
    }
}
