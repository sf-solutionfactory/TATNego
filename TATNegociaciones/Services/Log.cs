using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TATNegociaciones.Services
{
    public class Log
    {
        public string ruta { get; set; }
        public Log()
        {
            ruta = "";
        }
        public Log(string r)
        {
            ruta = r;
        }
        public void escribeLog(string text)
        {
            //File.OpenWrite(DateTime.Now.ToShortDateString() + ".txt");
            using (StreamWriter w = File.AppendText(ruta + DateTime.Now.Year.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Day.ToString() + ".txt"))
            {
                w.WriteLine(DateTime.Now.ToString() + "-" + text);
            }
        }

    }
}
