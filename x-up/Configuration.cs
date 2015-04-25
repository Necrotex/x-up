using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace x_up
{
    public static class Configuration
    {
        
        public static int interval = 1000;
        public static string logDir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "EVE", "logss", "Chatlogs");
        public static string searchString = "x";
    }
}
