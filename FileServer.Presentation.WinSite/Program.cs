using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileServer.Utils.LogHelper;
using log4net;
using log4net.Config;
using System.Resources;

namespace FileServer.Presentation.WinSite
{
    static class Program
    {
        private static readonly ILog log = LogHelper.GetLogger();

        [STAThread]
        static void Main()
        {
            //XmlConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            log.Debug(Resource.start);

        }
    }
}
