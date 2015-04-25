using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace x_up
{
    class Logs
    {
        public static int xCoutner = 0;
        public static int lastLine = 0;

        private static DirectoryInfo dirInfo;

        private static List<FileInfo> fleetLogList;
        private static FileInfo fleetLog;
        private static bool fileLock = false;


        public static void getLatestFleetLog()
        {
            dirInfo = new DirectoryInfo(Configuration.logDir);

            fleetLogList = new List<FileInfo>(dirInfo.GetFiles("Fleet_*"));
            fleetLogList.OrderBy(x => x.CreationTime).ToList<FileInfo>();
            fleetLog = fleetLogList.Last<FileInfo>();

            readLog();

            Form1.label2.text = xCoutner;

        }

        public static void readLog()
        {
      
            using(StreamReader log = new StreamReader(Path.Combine(Configuration.logDir, fleetLog.Name)))
            {
                string logLine;
                int lineNum = 0;

                while ((logLine = log.ReadLine()) != null)
                {
                    lineNum++;

                    // Magic number 13: The first 13 lines of a log are only meta data.
                    if (lineNum <= 13) continue;

                    if (lineNum > lastLine)
                    {
                        logLine = logLine.Remove(0, logLine.IndexOf(">") + 2);

                        if (logLine == Configuration.searchString)
                        {
                            xCoutner++;
                        }

                        lastLine = lineNum;
                    }                    
                }

                
            }


        }

    }
}
