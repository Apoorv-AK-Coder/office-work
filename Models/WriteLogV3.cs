using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;
using log4net.Appender;

namespace TravelSite.Models
{
    public class WriteLogV3
    {
        public void LogWrite(string FileName, string FilePath, string Message)
        {

            try
            {
                string path = FilePath;
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string str2 = FileName + ".log";
                Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
                hierarchy.Root.RemoveAllAppenders(); /*Remove any other appenders*/

                RollingFileAppender rollappender = new RollingFileAppender();
                rollappender.AppendToFile = true;
                rollappender.File = str2;
                log4net.Layout.PatternLayout pl = new log4net.Layout.PatternLayout();
                pl.ConversionPattern = "%date{HH:mm:ss,fff} [%2%t] %n%m%n%n";
                pl.ActivateOptions();
                rollappender.Layout = pl;
                rollappender.MaxSizeRollBackups = 9;
                rollappender.MaximumFileSize = "10MB";
                string filePath = string.Format(FilePath + str2, GetType().Assembly.GetName().Name);
                // Assign the value to the appender
                rollappender.File = filePath;
                rollappender.ActivateOptions();
                log4net.Config.BasicConfigurator.Configure(rollappender);
                ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
                log.Info(Message);


            }
            catch (Exception ex)
            {

            }
        }
    }
}