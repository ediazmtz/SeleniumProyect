using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProyectNew.Handler
{
    public class ScreenShotHandler
    {
        private static string DirectoryPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string TakeScreenShot(IWebDriver driver)
        { 
            long milliseconds = DateTime.Now.Ticks/ TimeSpan.TicksPerMillisecond;
            string imagenPath = DirectoryPath + "//img" + milliseconds + ".png";
            Screenshot image = ((ITakesScreenshot)driver).GetScreenshot();
            image.SaveAsFile(imagenPath, ScreenshotImageFormat.Png);
            return imagenPath;
        }
    }
}
