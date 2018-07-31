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
            mc.armarCorreos();
            Console.Write("Terminar?");
            Console.ReadKey();
        }
    }
}
