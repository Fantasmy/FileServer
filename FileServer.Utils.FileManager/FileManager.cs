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
            }
            catch (Exception ex)
            {
                Console.WriteLine("write error: " + ex.StackTrace);
                throw;
            }
        }

        public string getJsonContent()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    return File.ReadAllText(filePath); // loads alumnos list
                }

                catch (Exception ex)
                {
                    Console.WriteLine("load error: " + ex.StackTrace);
                }
            }
            return null;
        }
    }
}
