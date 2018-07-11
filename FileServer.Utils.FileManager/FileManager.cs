using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Utils.FileManager
{
    public class FileManager
    {
        private static readonly log4net.ILog log = LogHelper.LogHelper.GetLogger();

        private string filePath;

        public void setFilePath(string filePath)
        {
            this.filePath = filePath;
        }

        public void createJsonToFile(string Json)
        {
            try
            {
                File.WriteAllText(filePath, Json);
                log.Debug("Info written in json");
            }

            catch (Exception ex)
            {
                Console.WriteLine("write error: " + ex.StackTrace);
                log.Error("Couldn't write alumno info");
                throw;
            }
        }

        public string getJsonContent()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    log.Debug("Loaded alumnos list");
                    return File.ReadAllText(filePath); // loads alumnos list

                   
                }

                catch (Exception ex)
                {
                    Console.WriteLine("load error: " + ex.StackTrace);
                    log.Error("This is an error");
                }
            }
            return null;
        }
    }
}
