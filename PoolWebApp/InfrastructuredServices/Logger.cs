using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructuredServices
{
    public class Logger
    {
        #region Constants for Logger

        private const string filePathInfo = @"C:\Temp\PoolAppInfoLog.txt";
        private const string filePathError = @"C:\Temp\PoolAppErrorLog.txt";

        #endregion

        #region LogInfo

        public void LogInfo(DateTime dateTime, string log)
        {
            using (StreamWriter streamWriterInfo = new StreamWriter(filePathInfo, true))
            {
                streamWriterInfo.WriteLine(dateTime.ToString() + " " + log);
            }
        }

        #endregion

        #region LogError
        public void LogError(DateTime dateTime, string log)
        {
            using (StreamWriter streamWriterError = new StreamWriter(filePathError, true))
            {
                streamWriterError.WriteLine(dateTime.ToString() + " " + log);
            }
        }
        #endregion
    }
}
