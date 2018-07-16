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
        //ResourceManager rm = new ResourceManager(Resource1.FilePresentWinReso, Assembly.GetExecutingAssembly());
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
                    log.Debug(Resource1.DesObj);
                    return JsonConvert.DeserializeObject<List<Alumno>>(alumnosStr);
                }

                catch (VuelingException ex)
                {
                    return new List<Alumno>();
                    throw new VuelingException(Resource1.err);

                }
            }
        }

        public Alumno Add(Alumno alumno)
        {
            try
            {
                alumno.IdAlumno = Guid.NewGuid().ToString();
                log.Debug(Resource1.newGui);

                var alumnos = GetAll();
                alumnos.Add(alumno);
                log.Debug(Resource1.newAlum);

                string Json = JsonConvert.SerializeObject(alumnos, Formatting.Indented);
                fileManager.createJsonToFile(Json);

                Console.WriteLine(alumno.Nombre);
                log.Debug(Resource1.reAlum);
                return alumno;
            }

            catch (Exception ex)
            {
                Console.WriteLine(Resource1.loadEr + ex.StackTrace);
                log.Error(Resource1.erWrite);
                return null;
            }
        }

        public void ChangeOrigin(string origin)
        {
            string filePath = "";
            if (Resource1.AppConf.Equals(origin))
            {
                filePath = ConfigurationManager.AppSettings[Resource1.fileN];
                log.Debug(Resource1.path1);
            }
            else if (Resource1.varEnt.Equals(origin))
            {
                filePath = Environment.GetEnvironmentVariable(Resource1.fileN);
                log.Debug(Resource1.path2);

            }
            this.fileManager.setFilePath(filePath);
        }
    }
}
