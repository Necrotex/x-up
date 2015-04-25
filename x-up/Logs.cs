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
        private DirectoryInfo dirInfo;
        private List<FileInfo> fleetLogList;
        private FileInfo fleetLog;

        public string ReadLog()
        {
            GetLatestFleetLog();

            int count = 0;
            
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
                            count++;
                        }

                        lastLine = lineNum;
                    }                    
                }
            }

            return count.ToString();
        }

        private void GetLatestFleetLog()
        {
            dirInfo = new DirectoryInfo(Configuration.logDir);
            fleetLogList = new List<FileInfo>(dirInfo.GetFiles("Fleet_*"));
            fleetLogList.OrderBy(x => x.CreationTime).ToList<FileInfo>();
            fleetLog = fleetLogList.Last<FileInfo>();
        }
    }
}
