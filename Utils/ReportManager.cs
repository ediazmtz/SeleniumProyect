using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProyectNew.Utils
{
    public class ReportManager
    {
        private static ExtentReports _extent = null;
        public static string FilePath = "";
        public static string FileName = "Employee_Report.html";
        public const string ReportFolderName = "Reports";
        

        static ReportManager() { }

        private ReportManager() { }

        public static ExtentReports Extent
        {
            get
            { 
                if(_extent ==null)
                {
                    var ReportPath = GetReportPath();
                    var htmlReporter = new ExtentHtmlReporter(ReportPath);
                    string configPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    _extent = new ExtentReports();
                    
                    _extent.AttachReporter(htmlReporter);
                }
           
                return _extent;
            }
        }
        public static string GetReportPath()
        {
            var path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            var projectPath = path.Substring(0, path.LastIndexOf("bin", StringComparison.Ordinal));
            FilePath = new Uri(projectPath).LocalPath;
            Directory.CreateDirectory(FilePath + "\\" + ReportFolderName + "\\");
            return FilePath + "\\" + ReportFolderName + "\\" + FileName;

        }

    }
}
