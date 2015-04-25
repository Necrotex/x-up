using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace x_up
{
    public class Logs
    {
        private int lastLine;

        private List<FileInfo> fleetLogList;
        private FileInfo fleetLog;

        private int xCounter;
        private bool firstRun = true;
        private bool fileLock = false;

        public string ReadLog()
        {

            if (fileLock)
                return xCounter.ToString();

            fileLock = true;

            string path = Path.Combine(Configuration.logDir, fleetLog.Name);

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))      
            using(StreamReader log = new StreamReader(fs))
            {
                string logLine;
                int lineNum = 0;

                while ((logLine = log.ReadLine()) != null)
                {
                    lineNum++;

                    // Magic number 12: The first 13 lines of a log are only meta data.
                    if (lineNum <= 12) continue;

                    if (lineNum > lastLine)
                    {
                        logLine = logLine.Remove(0, logLine.IndexOf(">") + 2);

                        if (logLine == Configuration.searchString)
                        {
                            if(! firstRun)
                                xCounter++;
                        }

                        lastLine = lineNum;
                    }                    
                }
            }

            if (firstRun) firstRun = false;
            fileLock = false;

            return xCounter.ToString();
        }

        private void GetLatestFleetLog()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(Configuration.logDir);
            fleetLogList = new List<FileInfo>(dirInfo.GetFiles("Fleet_*"));
            fleetLogList.OrderBy(x => x.CreationTime).ToList<FileInfo>();
            fleetLog = fleetLogList.Last<FileInfo>();
            
            Debug.WriteLine(fleetLog.Name);
        }

        public void refresh()
        {
            xCounter = 0;
            GetLatestFleetLog();
        }
    }
}
