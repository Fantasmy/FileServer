using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileServer.Utils.FileManager
{
    public abstract class AbstractFileFactory // tiene un método abstracto (GetFileManager) que devuelve un Filemanager. 
    {
        public abstract FileManager GetFileManager(int fileType, int filePathType);  // El FileManager podrá manipular cualquier tipo json, txt, xml
    }
}
