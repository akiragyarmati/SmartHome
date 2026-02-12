using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome
{

    public delegate void LogEventHandler(string message);

    public class SystemLogger
    {
        public event LogEventHandler LogEvent;
        public void Log(string message) 
        { 
            LogEvent?.Invoke($"[{DateTime.Now}] {message}");
        }

        public void LogToConsole(string message) 
        { Console.WriteLine(message); }

        public void LogToFile(string message) 
        { 
            string logFilePath = "system_log.txt"; 

            try
            {

                string path = "system_log.txt";
                File.AppendAllText(path, message + Environment.NewLine);

            }
            catch (Exception ex) 
            { 
                Console.WriteLine($"Hiba a naplófájl írásakor: {ex.Message}"); 
            } 

        }


    }
}
