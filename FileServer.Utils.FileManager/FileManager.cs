using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Resources;
using FileServer.Common.Model;

namespace FileServer.Utils.FileManager
{
    public class FileManager
    {
        private static readonly log4net.ILog log = LogHelper.LogHelper.GetLogger();

        private string filePath;

        public virtual string FileExtension { get; set; } // los declara virtual, sobreescribible (en VB es overreadable)

        public virtual string FilePath { get; set; }

        //public void setFilePath(string filePath)
        //{
        //    this.filePath = filePath;
        //}

        public virtual void CreateFile()
        {
        }

        public virtual bool FileExists()
        {
            return true;
        }

        public virtual Alumno ProcessAlumnoData(Alumno alumno)
        {
            return alumno;
        }

        public virtual string RetrieveData()
        {
            return null;
        }

        public virtual void WriteToFile(string fileData)
        {
        }

        //    public void createJsonToFile(string Json)
        //    {
        //        try
        //        {
        //            File.WriteAllText(filePath, Json);
        //            log.Debug(Resource2.writJson);
        //        }

        //        //catch (Exception ex)
        //        //{
        //        //    Console.WriteLine("write error: " + ex.StackTrace);
        //        //    log.Error("Couldn't write alumno info");
        //        //    throw;
        //        //}
        //        catch (UnauthorizedAccessException ex)
        //        {
        //            throw ex;
        //        }
        //        catch (ArgumentException ex)
        //        {
        //            throw ex;
        //        }
        //        catch (DirectoryNotFoundException ex)
        //        {
        //            throw ex;
        //        }
        //        catch (IOException ex)
        //        {
        //            throw ex;
        //        }
        //        catch (System.Security.SecurityException ex)
        //        {
        //            throw ex;
        //        }
        //    }

        public string getJsonContent()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    log.Debug(Resource2.loadAlumL);
                    return File.ReadAllText(filePath); // loads alumnos list


                }

                catch (Exception ex)
                {
                    Console.WriteLine(Resource2.loadEr + ex.StackTrace);
                    log.Error(Resource2.err);
                }
            }
            return null;
        }
    }
    }
