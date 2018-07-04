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

namespace FileServer.Infrastructure.Repository.Repositories
{

    public class AlumnoRepository : IAlumnoRepository
    {
        private FileManager fileManager = new FileManager();

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
                    return JsonConvert.DeserializeObject<List<Alumno>>(alumnosStr);
                }

                catch (Exception)
                {
                    return new List<Alumno>();
                }
            }
        }

        public Alumno Add(Alumno alumno)
        {
            try
            {
                alumno.IdAlumno = Guid.NewGuid().ToString();

                var alumnos = GetAll();
                alumnos.Add(alumno);

                string Json = JsonConvert.SerializeObject(alumnos, Formatting.Indented);
                fileManager.createJsonToFile(Json);

                Console.WriteLine(alumno.Nombre);
                return alumno;
            }

            catch (Exception ex)
            {
                Console.WriteLine("load error: " + ex.StackTrace);
                return null;
            }
        }

        public void ChangeOrigin(string origin)
        {
            string filePath = "";
            if ("App.config".Equals(origin))
            {
                filePath = ConfigurationManager.AppSettings["fileName"];
            }
            else if ("Variable de entorno".Equals(origin))
            {
                filePath = Environment.GetEnvironmentVariable("fileName");
            }
            this.fileManager.setFilePath(filePath);
        }
    }
}
