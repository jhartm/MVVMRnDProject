using MVVMRnDProject.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMRnDProject.Tasks
{
    public static class PingTask
    {
        private static readonly Random random = new Random();

        public static string Ping(string portName)
        {
            return Constants.PORT_STATUS[random.Next(0,4)];
        }
    }
}
