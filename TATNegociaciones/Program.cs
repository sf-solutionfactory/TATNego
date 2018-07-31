using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TATNegociaciones.Services;

namespace TATNegociaciones
{
    public class Program
    {
        static void Main(string[] args)
        {
            MandarCorreos mc = new MandarCorreos();
            List<string> err = mc.armarCorreos();
            if (err.Count > 1)
            {
                MailErrores me = new MailErrores();
                me.enviarErrores(err);
            }

        }
    }
}
